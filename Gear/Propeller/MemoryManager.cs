﻿/* --------------------------------------------------------------------------------
 * Gear: Parallax Inc. Propeller Debugger
 * Copyright 2007 - Robert Vandiver
 * --------------------------------------------------------------------------------
 * MemoryManager.cs
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

namespace Gear.Propeller
{
    public class DirectMemory
    {
        protected byte[] Memory;

        public byte this[int offset]
        {
            get
            {
                if (offset >= Memory.Length)
                    return 0x55;
                return Memory[offset];
            }
        }

        public byte DirectReadByte(uint address)
        {
            return Memory[address & 0xFFFF];
        }

        public ushort DirectReadWord(uint address)
        {
            address &= 0xFFFFFFFE;
            return (ushort)(Memory[(address++) & 0xFFFF] | (Memory[(address++) & 0xFFFF] << 8));
        }

        public uint DirectReadLong(uint address)
        {
            address &= 0xFFFFFFFC;
            return (uint)Memory[(address++) & 0xFFFF]
                | (uint)(Memory[(address++) & 0xFFFF] << 8)
                | (uint)(Memory[(address++) & 0xFFFF] << 16)
                | (uint)(Memory[(address++) & 0xFFFF] << 24);
        }

        public void DirectWriteByte(uint address, byte value)
        {
            if ((address & 0x8000) != 0)
                return;
            Memory[(address++) & 0x7FFF] = value;
        }

        public void DirectWriteWord(uint address, ushort value)
        {
            address &= 0xFFFFFFFE;
            DirectWriteByte(address++, (byte) value);
            DirectWriteByte(address++, (byte)(value >> 8));
        }

        public void DirectWriteLong(uint address, uint value)
        {
            address &= 0xFFFFFFFC;
            DirectWriteByte(address++, (byte)value);
            DirectWriteByte(address++, (byte)(value >> 8));
            DirectWriteByte(address++, (byte)(value >> 16));
            DirectWriteByte(address++, (byte)(value >> 24));
        }
    }

    public class MemoryManager
    {
        private DirectMemory Memory;
        public uint Address { get; protected set; }

        public MemoryManager(DirectMemory Memory, uint Address = 0)
        {
            this.Memory = Memory;
            this.Address = Address;
        }
        public byte ReadByte()
        {
            return this.Memory.DirectReadByte(this.Address++);
        }

        public ushort ReadWord()
        {
            this.Address &= 0xFFFFFFFE;
            ushort read = this.Memory.DirectReadWord(this.Address);
            this.Address += 2;
            return read;
        }

        public uint ReadLong()
        {
            this.Address &= 0xFFFFFFFC;
            uint read = this.Memory.DirectReadLong(this.Address);
            this.Address += 4;
            return read;
        }

        public void WriteByte(byte value)
        {
            if ((this.Address & 0x8000) != 0)
                return;
            this.Memory.DirectWriteByte(this.Address++, value);
        }

        public void WriteWord(ushort value)
        {
            this.Address &= 0xFFFFFFFE;
            this.Memory.DirectWriteWord(this.Address, value);
            this.Address += 2;
        }

        public void WriteLong(uint value)
        {
            this.Address &= 0xFFFFFFFC;
            this.Memory.DirectWriteLong(this.Address, value);
            this.Address += 4;
        }
    }
}
