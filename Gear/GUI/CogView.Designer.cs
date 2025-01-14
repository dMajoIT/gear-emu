/* --------------------------------------------------------------------------------
 * Gear: Parallax Inc. Propeller P1 Emulator
 * Copyright 2007-2022 - Gear Developers
 * --------------------------------------------------------------------------------
 * CogView.Designer.cs
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

namespace Gear.GUI
{
    partial class CogView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            this._monoFont.Dispose();
            this._monoFontBold.Dispose();

            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.decodedPanel = new System.Windows.Forms.Panel();
            this.positionScroll = new System.Windows.Forms.VScrollBar();
            this.actionsToolStrip = new System.Windows.Forms.ToolStrip();
            this.memoryViewButton = new System.Windows.Forms.ToolStripButton();
            this.followPCButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.displayUnitsBtn = new System.Windows.Forms.ToolStripDropDownButton();
            this.decimalUnits = new System.Windows.Forms.ToolStripMenuItem();
            this.hexadecimalUnits = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.OpCodeSize = new System.Windows.Forms.ToolStripDropDownButton();
            this.longOpcodes = new System.Windows.Forms.ToolStripMenuItem();
            this.shortOpcodes = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
            this.frameBreakMode = new System.Windows.Forms.ToolStripDropDownButton();
            this.breakNone = new System.Windows.Forms.ToolStripMenuItem();
            this.breakMiss = new System.Windows.Forms.ToolStripMenuItem();
            this.breakAll = new System.Windows.Forms.ToolStripMenuItem();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.valuesToolStrip = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.cogStateLabel = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.programCursorLabel = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel5 = new System.Windows.Forms.ToolStripLabel();
            this.frameCountLabel = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel3 = new System.Windows.Forms.ToolStripLabel();
            this.zeroFlagLabel = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel4 = new System.Windows.Forms.ToolStripLabel();
            this.carryFlagLabel = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.actionsToolStrip.SuspendLayout();
            this.valuesToolStrip.SuspendLayout();
            this.SuspendLayout();
            //
            // decodedPanel
            //
            this.decodedPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.decodedPanel.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.decodedPanel.Location = new System.Drawing.Point(0, 50);
            this.decodedPanel.Name = "decodedPanel";
            this.decodedPanel.Size = new System.Drawing.Size(548, 396);
            this.decodedPanel.TabIndex = 1;
            this.decodedPanel.SizeChanged += new System.EventHandler(this.DecodedPanel_SizeChanged);
            this.decodedPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.DecodedPanel_Paint);
            this.decodedPanel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.DecodedPanel_MouseClick);
            this.decodedPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.DecodedPanel_MouseDown);
            this.decodedPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.DecodedPanel_MouseMove);
            //
            // positionScroll
            //
            this.positionScroll.Dock = System.Windows.Forms.DockStyle.Right;
            this.positionScroll.Location = new System.Drawing.Point(548, 50);
            this.positionScroll.Name = "positionScroll";
            this.positionScroll.Size = new System.Drawing.Size(17, 396);
            this.positionScroll.TabIndex = 2;
            this.positionScroll.TabStop = true;
            this.positionScroll.Scroll += new System.Windows.Forms.ScrollEventHandler(this.PositionScroll_Scroll);
            //
            // actionsToolStrip
            //
            this.actionsToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.memoryViewButton,
            this.followPCButton,
            this.toolStripSeparator7,
            this.displayUnitsBtn,
            this.toolStripSeparator8,
            this.OpCodeSize,
            this.toolStripSeparator9,
            this.frameBreakMode});
            this.actionsToolStrip.Location = new System.Drawing.Point(0, 0);
            this.actionsToolStrip.Name = "actionsToolStrip";
            this.actionsToolStrip.Size = new System.Drawing.Size(565, 25);
            this.actionsToolStrip.TabIndex = 0;
            this.actionsToolStrip.Text = "Actions";
            //
            // memoryViewButton
            //
            this.memoryViewButton.CheckOnClick = true;
            this.memoryViewButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.memoryViewButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.memoryViewButton.Name = "memoryViewButton";
            this.memoryViewButton.Size = new System.Drawing.Size(88, 22);
            this.memoryViewButton.Text = "Show Memory";
            this.memoryViewButton.Click += new System.EventHandler(this.MemoryViewButton_Click);
            //
            // followPCButton
            //
            this.followPCButton.Checked = true;
            this.followPCButton.CheckOnClick = true;
            this.followPCButton.CheckState = System.Windows.Forms.CheckState.Checked;
            this.followPCButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.followPCButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.followPCButton.Name = "followPCButton";
            this.followPCButton.Size = new System.Drawing.Size(64, 22);
            this.followPCButton.Text = "Follow PC";
            this.followPCButton.Click += new System.EventHandler(this.FollowPCButton_Click);
            //
            // toolStripSeparator7
            //
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(6, 25);
            //
            // displayUnitsBtn
            //
            this.displayUnitsBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.displayUnitsBtn.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.decimalUnits,
            this.hexadecimalUnits});
            this.displayUnitsBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.displayUnitsBtn.Name = "displayUnitsBtn";
            this.displayUnitsBtn.Size = new System.Drawing.Size(73, 22);
            this.displayUnitsBtn.Text = "Units: Dec";
            //
            // decimalUnits
            //
            this.decimalUnits.Name = "decimalUnits";
            this.decimalUnits.Size = new System.Drawing.Size(143, 22);
            this.decimalUnits.Text = "Decimal";
            this.decimalUnits.Click += new System.EventHandler(this.DecimalUnits_Click);
            //
            // hexadecimalUnits
            //
            this.hexadecimalUnits.Name = "hexadecimalUnits";
            this.hexadecimalUnits.Size = new System.Drawing.Size(143, 22);
            this.hexadecimalUnits.Text = "Hexadecimal";
            this.hexadecimalUnits.Click += new System.EventHandler(this.HexadecimalUnits_Click);
            //
            // toolStripSeparator8
            //
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(6, 25);
            //
            // OpCodeSize
            //
            this.OpCodeSize.AutoSize = false;
            this.OpCodeSize.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.OpCodeSize.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.longOpcodes,
            this.shortOpcodes});
            this.OpCodeSize.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.OpCodeSize.Name = "OpCodeSize";
            this.OpCodeSize.Size = new System.Drawing.Size(101, 22);
            this.OpCodeSize.Text = "Opcodes: Short";
            //
            // longOpcodes
            //
            this.longOpcodes.Name = "longOpcodes";
            this.longOpcodes.Size = new System.Drawing.Size(152, 22);
            this.longOpcodes.Text = "Long Opcodes";
            this.longOpcodes.Click += new System.EventHandler(this.LongOpCodes_Click);
            //
            // shortOpcodes
            //
            this.shortOpcodes.Checked = true;
            this.shortOpcodes.CheckState = System.Windows.Forms.CheckState.Checked;
            this.shortOpcodes.Name = "shortOpcodes";
            this.shortOpcodes.Size = new System.Drawing.Size(152, 22);
            this.shortOpcodes.Text = "Short Opcodes";
            this.shortOpcodes.Click += new System.EventHandler(this.ShortOpCodes_Click);
            //
            // toolStripSeparator9
            //
            this.toolStripSeparator9.Name = "toolStripSeparator9";
            this.toolStripSeparator9.Size = new System.Drawing.Size(6, 25);
            //
            // frameBreakMode
            //
            this.frameBreakMode.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.frameBreakMode.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.breakNone,
            this.breakMiss,
            this.breakAll});
            this.frameBreakMode.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.frameBreakMode.Name = "frameBreakMode";
            this.frameBreakMode.Size = new System.Drawing.Size(117, 22);
            this.frameBreakMode.Text = "Video Break: None";
            this.frameBreakMode.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.frameBreakMode.ToolTipText = "Enable break on end of video frame";
            //
            // breakNone
            //
            this.breakNone.AutoToolTip = true;
            this.breakNone.Checked = true;
            this.breakNone.CheckOnClick = true;
            this.breakNone.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.breakNone.Name = "breakNone";
            this.breakNone.Size = new System.Drawing.Size(134, 22);
            this.breakNone.Text = "None";
            this.breakNone.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.breakNone.Click += new System.EventHandler(this.VideoBreak_Click);
            //
            // breakMiss
            //
            this.breakMiss.AutoToolTip = true;
            this.breakMiss.CheckOnClick = true;
            this.breakMiss.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.breakMiss.Name = "breakMiss";
            this.breakMiss.Size = new System.Drawing.Size(134, 22);
            this.breakMiss.Text = "Frame Miss";
            this.breakMiss.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.breakMiss.ToolTipText = "Break if frame end misses WAIT_VID";
            this.breakMiss.Click += new System.EventHandler(this.VideoBreak_Click);
            //
            // breakAll
            //
            this.breakAll.AutoToolTip = true;
            this.breakAll.CheckOnClick = true;
            this.breakAll.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.breakAll.Name = "breakAll";
            this.breakAll.Size = new System.Drawing.Size(134, 22);
            this.breakAll.Text = "Frame End";
            this.breakAll.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.breakAll.ToolTipText = "Break on end of video frame";
            this.breakAll.Click += new System.EventHandler(this.VideoBreak_Click);
            //
            // toolTip1
            //
            this.toolTip1.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.toolTip1.ToolTipTitle = "PASM Source and Destination Values/Registers";
            //
            // valuesToolStrip
            //
            this.valuesToolStrip.BackColor = System.Drawing.SystemColors.ControlLight;
            this.valuesToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.valuesToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator1,
            this.toolStripLabel1,
            this.cogStateLabel,
            this.toolStripSeparator2,
            this.toolStripLabel2,
            this.programCursorLabel,
            this.toolStripSeparator3,
            this.toolStripLabel5,
            this.frameCountLabel,
            this.toolStripSeparator4,
            this.toolStripLabel3,
            this.zeroFlagLabel,
            this.toolStripSeparator5,
            this.toolStripLabel4,
            this.carryFlagLabel,
            this.toolStripSeparator6});
            this.valuesToolStrip.Location = new System.Drawing.Point(0, 25);
            this.valuesToolStrip.Name = "valuesToolStrip";
            this.valuesToolStrip.Size = new System.Drawing.Size(565, 25);
            this.valuesToolStrip.TabIndex = 3;
            this.valuesToolStrip.Text = "toolStrip1";
            //
            // toolStripSeparator1
            //
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            //
            // toolStripLabel1
            //
            this.toolStripLabel1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(61, 22);
            this.toolStripLabel1.Text = "Cog State:";
            //
            // cogStateLabel
            //
            this.cogStateLabel.AutoSize = false;
            this.cogStateLabel.AutoToolTip = true;
            this.cogStateLabel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.cogStateLabel.Name = "cogStateLabel";
            this.cogStateLabel.Size = new System.Drawing.Size(122, 22);
            this.cogStateLabel.Text = "Interpreter Processing";
            this.cogStateLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cogStateLabel.ToolTipText = "Cog state.";
            //
            // toolStripSeparator2
            //
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            //
            // toolStripLabel2
            //
            this.toolStripLabel2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(56, 22);
            this.toolStripLabel2.Text = "Exec Pos:";
            //
            // programCursorLabel
            //
            this.programCursorLabel.AutoSize = false;
            this.programCursorLabel.AutoToolTip = true;
            this.programCursorLabel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.programCursorLabel.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.programCursorLabel.Name = "programCursorLabel";
            this.programCursorLabel.Size = new System.Drawing.Size(42, 22);
            this.programCursorLabel.Text = "$0000";
            this.programCursorLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.programCursorLabel.ToolTipText = "Program cursor: line number at execution.";
            //
            // toolStripSeparator3
            //
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            //
            // toolStripLabel5
            //
            this.toolStripLabel5.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripLabel5.Name = "toolStripLabel5";
            this.toolStripLabel5.Size = new System.Drawing.Size(76, 22);
            this.toolStripLabel5.Text = "Video Frame:";
            //
            // frameCountLabel
            //
            this.frameCountLabel.AutoSize = false;
            this.frameCountLabel.AutoToolTip = true;
            this.frameCountLabel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.frameCountLabel.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.frameCountLabel.Name = "frameCountLabel";
            this.frameCountLabel.Size = new System.Drawing.Size(98, 22);
            this.frameCountLabel.Text = "None/0000/000";
            this.frameCountLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.frameCountLabel.ToolTipText = "State / Number of Video Frames / Clock number";
            //
            // toolStripSeparator4
            //
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            //
            // toolStripLabel3
            //
            this.toolStripLabel3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripLabel3.Name = "toolStripLabel3";
            this.toolStripLabel3.Size = new System.Drawing.Size(34, 22);
            this.toolStripLabel3.Text = "Zero:";
            //
            // zeroFlagLabel
            //
            this.zeroFlagLabel.AutoSize = false;
            this.zeroFlagLabel.AutoToolTip = true;
            this.zeroFlagLabel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.zeroFlagLabel.Name = "zeroFlagLabel";
            this.zeroFlagLabel.Size = new System.Drawing.Size(33, 22);
            this.zeroFlagLabel.Text = "False";
            this.zeroFlagLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.zeroFlagLabel.ToolTipText = "Zero flag register value.";
            //
            // toolStripSeparator5
            //
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 25);
            //
            // toolStripLabel4
            //
            this.toolStripLabel4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripLabel4.Name = "toolStripLabel4";
            this.toolStripLabel4.Size = new System.Drawing.Size(38, 15);
            this.toolStripLabel4.Text = "Carry:";
            //
            // carryFlagLabel
            //
            this.carryFlagLabel.AutoSize = false;
            this.carryFlagLabel.AutoToolTip = true;
            this.carryFlagLabel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.carryFlagLabel.Name = "carryFlagLabel";
            this.carryFlagLabel.Size = new System.Drawing.Size(33, 22);
            this.carryFlagLabel.Text = "False";
            this.carryFlagLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.carryFlagLabel.ToolTipText = "Carry flag register value.";
            //
            // toolStripSeparator6
            //
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 25);
            //
            // CogView
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.decodedPanel);
            this.Controls.Add(this.positionScroll);
            this.Controls.Add(this.valuesToolStrip);
            this.Controls.Add(this.actionsToolStrip);
            this.Name = "CogView";
            this.Size = new System.Drawing.Size(565, 446);
            this.actionsToolStrip.ResumeLayout(false);
            this.actionsToolStrip.PerformLayout();
            this.valuesToolStrip.ResumeLayout(false);
            this.valuesToolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel decodedPanel;
        private System.Windows.Forms.VScrollBar positionScroll;
        private System.Windows.Forms.ToolStrip actionsToolStrip;
        private System.Windows.Forms.ToolStripButton memoryViewButton;
        private System.Windows.Forms.ToolStripButton followPCButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripDropDownButton displayUnitsBtn;
        private System.Windows.Forms.ToolStripMenuItem decimalUnits;
        private System.Windows.Forms.ToolStripMenuItem hexadecimalUnits;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.ToolStripDropDownButton OpCodeSize;
        private System.Windows.Forms.ToolStripMenuItem longOpcodes;
        private System.Windows.Forms.ToolStripMenuItem shortOpcodes;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ToolStripDropDownButton frameBreakMode;
        private System.Windows.Forms.ToolStripMenuItem breakNone;
        private System.Windows.Forms.ToolStripMenuItem breakMiss;
        private System.Windows.Forms.ToolStripMenuItem breakAll;
        private System.Windows.Forms.ToolStrip valuesToolStrip;
        private System.Windows.Forms.ToolStripLabel programCursorLabel;
        private System.Windows.Forms.ToolStripLabel zeroFlagLabel;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator9;
        private System.Windows.Forms.ToolStripLabel cogStateLabel;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripLabel toolStripLabel3;
        private System.Windows.Forms.ToolStripLabel toolStripLabel4;
        private System.Windows.Forms.ToolStripLabel toolStripLabel5;
        private System.Windows.Forms.ToolStripLabel frameCountLabel;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripLabel carryFlagLabel;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
    }
}
