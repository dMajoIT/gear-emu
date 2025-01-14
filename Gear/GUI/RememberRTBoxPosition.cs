﻿/* --------------------------------------------------------------------------------
 * Gear: Parallax Inc. Propeller P1 Emulator
 * Copyright 2007-2022 - Gear Developers
 * --------------------------------------------------------------------------------
 * RememberRTBoxPosition.cs
 * Remember and restore displayed position and insert point for a RichTextBox.
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

using System;
using System.Drawing;
using System.Windows.Forms;

// ReSharper disable InconsistentNaming

namespace Gear.GUI
{
    /// <summary>Remember and restore displayed position and insert
    /// point (aka caret in MS documentation) for a RichTextBox.</summary>
    /// <remarks>Based on code from https://stackoverflow.com/a/20746931/10200101 </remarks>
    public class RememberRTBoxPosition
    {
        /// <summary>Object reference.</summary>
        private readonly RichTextBox _obj;

        /// <summary>Store first displayed character.</summary>
        private int _start;

        /// <summary>Store last displayed character.</summary>
        private int _end;

        /// <summary>Store cursor position.</summary>
        private int _cursorPosition;

        /// <summary>Store cursor length.</summary>
        private int _cursorLength;

        /// <summary>Default constructor, remembers current position of
        /// text displayed and selection.</summary>
        /// <param name="textBox">RichTextBox object to remember and
        /// restore state.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public RememberRTBoxPosition(RichTextBox textBox)
        {
            _obj = textBox ?? throw new ArgumentNullException(nameof(textBox));
            RememberNewPosition();
        }

        /// <summary>Remember position of text displayed and current
        /// selection.</summary>
        /// @version v22.09.02 - Changed visibility from `public`.
        private void RememberNewPosition()
        {
            // Get first and last displayed character
            _start = _obj.GetCharIndexFromPosition(new Point(0, 0));
            _end = _obj.GetCharIndexFromPosition(
                new Point(_obj.ClientSize.Width, _obj.ClientSize.Height));
            // Save cursor position
            _cursorPosition = _obj.SelectionStart;
            _cursorLength = _obj.SelectionLength;
        }

        /// <summary>Restore position of text displayed and last properties
        /// of selection.</summary>
        public void RestorePosition()
        {
            // Scroll to the last character and then to the first + line width
            _obj.SelectionLength = 0;
            _obj.SelectionStart = _end;
            _obj.ScrollToCaret();
            _obj.SelectionStart =
                _start + _obj.Lines[_obj.GetLineFromCharIndex(_start)].Length + 1;
            _obj.ScrollToCaret();
            // Finally, set cursor to original position
            _obj.SelectionStart = _cursorPosition;
            _obj.SelectionLength = _cursorLength;
        }
    }
}
