/* --------------------------------------------------------------------------------
 * Gear: Parallax Inc. Propeller P1 Emulator
 * Copyright 2007-2022 - Gear Developers
 * --------------------------------------------------------------------------------
 * VideoGenerator.CS
 * Video Generator Circuit Base
 * --------------------------------------------------------------------------------
 *  This program is free software; you can redistribute it and/or modify
 *  it under the terms of the GNU General Public License as published by
 *  the Free Software Foundation; either version 2 of the License, or
 *  (at your option) any later version.
 *
 *  This program is distributed in the hope that it will be useful,
 *  but WITHOUT ANY WARRANTY; without even the implied warranty of
 *  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 *  GNU General Public License for more details.
 *
 *  You should have received a copy of the GNU General Public License
 *  along with this program; if not, write to the Free Software
 *  Foundation, Inc., 59 Temple Place, Suite 330, Boston, MA  02111-1307  USA
 * --------------------------------------------------------------------------------
 */

namespace Gear.EmulationCore
{
    /// @brief Video mode Field.
    /// The 2-bit VMode (video mode) field selects the type and orientation of video output.
    /// 
    /// Source: Table 8 - The Video Mode Field, %Propeller P8X32A Datasheet V1.4.0.
    public enum VMode : int
    {
        DISABLED    = 0x00000000,   //!< Disabled, no video generated.
        VGA_MODE    = 0x20000000,   //!< VGA mode; 8-bit parallel output on VPins 7:0
        COMPOSITE_1 = 0x40000000,   //!< Composite Mode 1; broadcast on VPins 7:4, baseband on VPins 3:0
        COMPOSITE_2 = 0x60000000    //!< Composite Mode 2; baseband on VPins 7:4, broadcast on VPins 3:0
    }

    public enum CMode : int
    {
        TWO_COLOR       = 0x00000000,
        FOUR_COLOR      = 0x10000000
    }

    /// @brief Video Generator Circuit emulation.
    public class VideoGenerator
    {
        private uint Scale;
        private uint Config;
        private uint frameCount;

        // Scale Registers

        private uint PixelClockStart;
        private uint PixelClocks;
        private uint FrameClocks;
        private bool ScaleDirty;

        // Configuration Registers

        private VMode VideoMode;
        private CMode ColorMode;

        private bool Chroma0;
        private bool Chroma1;

        private uint AuralSub;
        private int VGroup;
        private ulong VPins;

        // Serialization values

        private uint PixelLoad;
        private uint ColorLoad;
        private uint ShiftOut;
        /// <summary></summary>
        /// @version v22.03.01 - Added.
        private uint Discrete;

        private byte PhaseAccumulator;
        private bool VHFCarrier;

        private ulong OutputLoad;
        private ulong BroadcastUp;
        private ulong BroadcastDown;
        private ulong BasebandOut;
        private ulong AuralBit;
        private bool AuralOutput;

        // Misc Variables

        private readonly PropellerCPU Chip;
        private readonly Cog cog;

        public uint Frames
        {
            get
            {
                return frameCount;
            }
        }

        public void FrameCounters (out uint frameNo, out uint frameClk, out uint pixelClk)
        {
            frameNo = frameCount;
            frameClk = FrameClocks;
            pixelClk = PixelClocks;
        }

        public uint CFG
        {
            get
            {
                return Config;
            }
            set
            {
                Config = value;

                // Detach from our old aural hook
                if (Chip.GetPLL(AuralSub) != null)
                    Chip.GetPLL(AuralSub).RemoveHook(this);

                VideoMode = (VMode)(Config & 0x60000000);
                ColorMode = (CMode)(Config & 0x10000000);

                Chroma0 = (Config & 0x04000000) != 0;
                Chroma1 = (Config & 0x08000000) != 0;

                AuralSub = (Config >> 23) & 0x7;
                VGroup = (int)(Config >> 6) & 0x38;                 // VGroup is the first pin to output from
                VPins = (Config & 0xFF) << VGroup;                  // Pins becomes a 64bit pin mask

                // Attach to the new aural sub PLL
                if (Chip.GetPLL(AuralSub) != null)
                    Chip.GetPLL(AuralSub).AttachHook(this);

                // Reset counters
                PixelClockStart = (Scale >> 12) & 0xFF;
                FrameClocks = Scale & 0xFFF;    // Copy our frameclocks out of the scale register
                frameCount = 0;
            }
        }

        public uint SCL
        {
            get
            {
                return Scale;
            }
            set
            {
                if (Scale != value)
                {
                    ScaleDirty = true;
                    Scale = value;
                }
            }
        }

        public bool Ready
        {
            get
            {
                return (FrameClocks <= 0);
            }
        }

        public ulong Output
        {
            get
            {
                return OutputLoad & VPins;
            }
        }

        public VideoGenerator(PropellerCPU chip, Cog owner)
        {
            // Clear our phase accumulator
            PhaseAccumulator = 0;
            Chip = chip;
            cog = owner;

            // Scale is dirty
            ScaleDirty = true;
        }

        public void DetachAural()
        {
            if (Chip.GetPLL(AuralSub) != null)
                Chip.GetPLL(AuralSub).RemoveHook(this);
        }

        public void Feed(uint colors, uint pixels)
        {
            ColorLoad = colors;
            PixelLoad = pixels;

            if (ScaleDirty)
            {
                PixelClockStart = (Scale >> 12) & 0xFF;
                ScaleDirty = false;
            }

            FrameClocks = Scale & 0xFFF;    // Copy our frameclocks out of the scale register
            PixelClocks = PixelClockStart;  // update PixelClock, similar to verilog
        }

        private void FillComposite(uint color)
        {
            // The top four bits of the 'color' for the current pixel is added to this,
            // If bit 3 of the color is set, then the MSB signifies a +/- 1 offset on
            // the luma output.  (1/16 phase divider with a 16 entry shifter).  The
            // lower four bits are unused.

            // Output LUMA
            ulong baseband = color & 0x7;
            ulong broadcast = baseband;

            // Output Chroma
            if ((color & 0x08) != 0)
            {
                // We assume that the phase accumulator 4 LSBs are clear
                ulong shiftedPhase = (PhaseAccumulator + color) & 0x80;

                // --- BASEBAND MODE ---

                // Mix if necessary
                if (Chroma0)
                {
                    if (shiftedPhase != 0)
                        baseband = (baseband + 1) & 0x7;
                    else
                        baseband = (baseband - 1) & 0x7;
                }

                // Mix chroma on pin 3
                baseband |= shiftedPhase >> 4;

                // --- BROADCAST MODE ---

                // Mix if necessary
                if (Chroma1)
                {
                    if (shiftedPhase != 0)
                        broadcast = (broadcast + 1) & 0x7;
                    else
                        broadcast = (broadcast - 1) & 0x7;
                }
            }

            BasebandOut = baseband << VGroup;
            BroadcastUp = (7 - (broadcast >> 1)) << VGroup;
            BroadcastDown = ((broadcast + 1) >> 1) << VGroup;
        }

        private void UpdateCompositeOut()
        {
            if (VideoMode != VMode.COMPOSITE_1 && VideoMode != VMode.COMPOSITE_2)
                return;

            OutputLoad = BasebandOut | (VHFCarrier ? BroadcastUp : BroadcastDown);

            if (AuralOutput ^ VHFCarrier)
                OutputLoad |= AuralBit;
        }

        public void AuralTick(bool level)
        {
            AuralOutput = level;
            UpdateCompositeOut();
        }

        public void CarrierTick(bool level)
        {
            VHFCarrier = level;
            UpdateCompositeOut();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="level"></param>
        /// @version v22.03.01 - Improved accuracy of Video generator (pull request #29 from github/Sh1nyAnd3o3).
        public void ColorTick(bool level)
        {
            // Only tick color on rising edge
            if (level != true)
                return;

            // Avoid extra logic when video generator is disabled
            if (VideoMode == VMode.DISABLED)
            {
                OutputLoad = 0;
                return;
            }

            // Output the load to the pins
            switch (VideoMode)
            {
                case VMode.VGA_MODE:
                    OutputLoad = Discrete << VGroup;
                    break;
                case VMode.COMPOSITE_1: // 0..3 Baseband 4..7 Broadcast
                    FillComposite(ShiftOut);

                    BroadcastUp <<= 4;
                    BroadcastDown <<= 4;
                    AuralBit = (ulong)0x8 << 4 << VGroup;

                    UpdateCompositeOut();
                    break;
                case VMode.COMPOSITE_2: // 4..7 Baseband 0..3 Broadcast
                    FillComposite(ShiftOut);

                    BasebandOut <<= 4;
                    AuralBit = (ulong)0x8 << VGroup;

                    UpdateCompositeOut();
                    break;
            }

            // Composite Processes gets updated one tick later than VGA
            ShiftOut = Discrete;

            // Find the pixel color which will be processed by VGA Directly
            switch (ColorMode)
            {
                // Four color video
                case CMode.FOUR_COLOR:
                    Discrete = (ColorLoad >> (int)((PixelLoad & 3) << 3)) & 0xFF;
                    break;
                // Two color mode
                case CMode.TWO_COLOR:
                default:
                    Discrete = (ColorLoad >> (int)((PixelLoad & 1) << 3)) & 0xFF;
                    break;
            }

            // Decrement clocks
            --FrameClocks;
            FrameClocks &= 0xFFF;
            --PixelClocks;
            PixelClocks &= 0xFF;

            // Check to see if we are at the end of our frame clocks
            if (FrameClocks == 0)
            {
                cog.GetVideoData(out uint colours, out uint pixels);
                Feed(colours, pixels);
                ++frameCount;

            }
            // Clock up to our pixel accumulator (wait for pixel)
            else if (PixelClocks == 0)
            {
                // Find the pixel color we need to shift out
                switch (ColorMode)
                {
                    // Four color video
                    case CMode.FOUR_COLOR:
                        PixelLoad = (PixelLoad & 0xC0000000) | (PixelLoad >> 2);
                        break;
                    // Two color mode
                    case CMode.TWO_COLOR:
                    default:
                        PixelLoad = (PixelLoad & 0x80000000) | (PixelLoad >> 1);
                        break;
                }

                // Fill our pixel clock countdown using the scale register
                PixelClocks = PixelClockStart;
            }
            // Accumulate phase (/16 divider)
            PhaseAccumulator += 0x10;
        }
    }
}
