﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System.ComponentModel;

namespace Gear.Properties {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "16.10.0.0")]
    public sealed partial class Settings : global::System.Configuration.ApplicationSettingsBase {
        
        public static Settings defaultInstance = ((Settings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new Settings())));
        
        public static Settings Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("5E-05")]
        [CategoryAttribute("Logic Probe")]
        [DescriptionAttribute("Time interval for the logic probe grid.")]
        [DisplayNameAttribute("Last Tick mark grid")]
        public double LastTickMarkGrid {
            get {
                return ((double)(this["LastTickMarkGrid"]));
            }
            set {
                this["LastTickMarkGrid"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("0.0001")]
        [CategoryAttribute("Logic Probe")]
        [DescriptionAttribute("Width of time frame for the logic probe window.")]
        [DisplayNameAttribute("Last Time Frame")]
        public double LastTimeFrame {
            get {
                return ((double)(this["LastTimeFrame"]));
            }
            set {
                this["LastTimeFrame"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("s")]
        [CategoryAttribute("Logic Probe")]
        [DescriptionAttribute("Unit of measure for elapsed time label in logic probe.")]
        [DisplayNameAttribute("Unit for time frame and time interval.")]
        public global::Gear.Utils.TimeUnitsEnum LogicViewTimeUnit {
            get {
                return ((global::Gear.Utils.TimeUnitsEnum)(this["LogicViewTimeUnit"]));
            }
            set {
                this["LogicViewTimeUnit"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("True")]
        [CategoryAttribute("Plugin Editor")]
        [DescriptionAttribute("Flag to embed the C# code of the plugin into XML file, or to " + 
            "create in a separated .CS file.")]
        [DisplayNameAttribute("Embedded code?")]
        public bool EmbeddedCode {
            get {
                return ((bool)(this["EmbeddedCode"]));
            }
            set {
                this["EmbeddedCode"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute(".\\Plugins\\")]
        [CategoryAttribute("Plugin Editor")]
        [DescriptionAttribute("Last plugin loaded or edited (with full path).")]
        [DisplayNameAttribute("Last Plugin loaded")]
        public string LastPlugin {
            get {
                return ((string)(this["LastPlugin"]));
            }
            set {
                this["LastPlugin"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("4")]
        [CategoryAttribute("Plugin Editor")]
        [DescriptionAttribute("Tabulation size in editor")]
        [DisplayNameAttribute("Tab size")]
        public uint TabSize {
            get {
                return ((uint)(this["TabSize"]));
            }
            set {
                this["TabSize"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("ParallaxSpin")]
        [CategoryAttribute("Hub View")]
        [DescriptionAttribute("Format of counter and frequency labels in Hub view.")]
        [DisplayNameAttribute("Frequency and Time format")]
        public global::Gear.Utils.NumberFormatEnum FreqFormat {
            get {
                return ((global::Gear.Utils.NumberFormatEnum)(this["FreqFormat"]));
            }
            set {
                this["FreqFormat"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("s")]
        [CategoryAttribute("Hub View")]
        [DescriptionAttribute("Unit of measure for elapsed time label in Hub view.")]
        [DisplayNameAttribute("Unit for elapsed time")]
        public global::Gear.Utils.TimeUnitsEnum HubTimeUnit {
            get {
                return ((global::Gear.Utils.TimeUnitsEnum)(this["HubTimeUnit"]));
            }
            set {
                this["HubTimeUnit"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        [CategoryAttribute("Propeller Emulator")]
        [DescriptionAttribute("Last Propeller binary loaded (with full path).")]
        [DisplayNameAttribute("Last Binary loaded")]
        public string LastBinary {
            get {
                return ((string)(this["LastBinary"]));
            }
            set {
                this["LastBinary"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("1024")]
        [CategoryAttribute("Propeller Emulator")]
        [DescriptionAttribute("How many clock steps will pass between screen repaint of emulator and plugins.")]
        [DisplayNameAttribute("Update screen each steps")]
        public uint UpdateEachSteps {
            get {
                return ((uint)(this["UpdateEachSteps"]));
            }
            set {
                this["UpdateEachSteps"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("True")]
        [CategoryAttribute("Propeller Emulator")]
        [DescriptionAttribute("Use animations on splitters.")]
        [DisplayNameAttribute("Use animations")]
        public bool UseAnimations {
            get {
                return ((bool)(this["UseAnimations"]));
            }
            set {
                this["UseAnimations"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("True")]
        [CategoryAttribute("Propeller Emulator")]
        [DescriptionAttribute("Decoded program values are shown as hexadecimals in Cog View.")]
        [DisplayNameAttribute("Values shown as hexadecimals")]
        public bool ValuesShownAsHex {
            get {
                return ((bool)(this["ValuesShownAsHex"]));
            }
            set {
                this["ValuesShownAsHex"] = value;
            }
        }
    }
}
