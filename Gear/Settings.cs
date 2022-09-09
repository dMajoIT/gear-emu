﻿/* --------------------------------------------------------------------------------
 * Gear: Parallax Inc. Propeller P1 Emulator
 * Copyright 2007-2022 - Gear Developers
 * --------------------------------------------------------------------------------
 * Settings.cs
 * --------------------------------------------------------------------------------
 *
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

/// @brief Transversal %Properties for the program.
namespace Gear.Properties
{
    /// @brief Controls events for configuration class.

    // Esta clase le permite controlar eventos específicos en la clase de configuración:
    //  El evento SettingChanging se desencadena antes de cambiar un valor de configuración.
    //  El evento PropertyChanged se desencadena después de cambiar el valor de configuración.
    //  El evento SettingsLoaded se desencadena después de cargar los valores de configuración.
    //  El evento SettingsSaving se desencadena antes de guardar los valores de configuración.
    public sealed partial class Settings {

        /// @brief Default constructor.
        public Settings() {
            //Para agregar los controladores de eventos para guardar y cambiar la configuración, quite la marca de comentario de las líneas:
            //
            // this.SettingChanging += this.SettingChangingEventHandler;
            //
            // this.SettingsSaving += this.SettingsSavingEventHandler;
            //
        }

        /// <summary></summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SettingChangingEventHandler(object sender, System.Configuration.SettingChangingEventArgs e) {
            // Agregar código para administrar aquí el evento SettingChangingEvent.
        }

        /// <summary></summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SettingsSavingEventHandler(object sender, System.ComponentModel.CancelEventArgs e) {
            // Agregar código para administrar aquí el evento SettingsSaving.
        }

        //This DOXYGEN documentation goes here, because Settings.Designer.cs is auto generated by MSVS
        //and the documentation will be lost if put there.
        //

        /// @property LastTickMarkGrid
        /// @brief Last value used as grid separation in the logic view plugin.
        /// @version v15.03.26 - Added as a User property of the program.

        /// @property LastTimeFrame
        /// @brief Last value used as a width in the logic view plugin.
        /// @version v15.03.26 - Added as a User property of the program.

        /// @property LogicViewTimeUnit
        /// @brief Unit of measure for elapsed time label in logic probe.
        /// @version v20.09.01 - Added as a User property of the program.

        /// @property EmbeddedCode
        /// @brief Determine if the code for the plugin is embedded in the XML file or resides on
        /// a separate file, on Plugin Editor.
        /// @version v15.03.26 - Added as a User property of the program.

        /// @property LastPlugin
        /// @brief Last plugin successfully opened or saved on Plugin Editor.
        /// @details Include complete path and name.
        /// @version v15.03.26 - Added as a User property of the program.

        /// @property TabSize
        /// @brief Tabulator size in characters, from Plugin Editor.
        /// @version v20.09.01 - Added as a User property of the program.

        /// @property FreqFormat
        /// @brief Format of frequency labels in %GUI.
        /// @version v20.06.01 - Added as a User property of the program.

        /// @property HubTimeUnit
        /// @brief Unit of measure for elapsed time label in Hub view.
        /// @version v20.06.01 - Added as a User property of the program.

        /// @property LastBinary
        /// @brief Last binary file successfully opened.
        /// @details Include complete path and name.
        /// @version v15.03.26 - Added as a User property of the program.

        /// @property UpdateEachSteps
        /// @brief Number of steps before update the windows and tabs.
        /// @version v15.03.26 - Added as a User property of the program.

        /// @property TabSize
        /// @brief Tabulator size in characters.
        /// @version v20.08.01 - Added as a User property of the program.

        /// @property UseAnimations
        /// @brief Use animations on splitters.
        /// @version v22.06.01 - Added as a User property of the program.

        /// @property ValuesShownAsHex
        /// @brief Values shown as hexadecimals as default initial setting on Cog View.
        /// @version v22.09.01 - Added as a User property of the program.
    }
}
