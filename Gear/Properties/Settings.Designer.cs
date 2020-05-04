﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34209
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System.ComponentModel;

namespace Gear.Properties {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "12.0.0.0")]
    internal sealed partial class Settings : global::System.Configuration.ApplicationSettingsBase {
        
        private static Settings defaultInstance = ((Settings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new Settings())));
        
        public static Settings Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        [CategoryAttribute("Plugin Editor")]
        [DescriptionAttribute("Last plugin loaded or edited (with full path).")]
        [DisplayNameAttribute("last Plugin loaded")]
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
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        [CategoryAttribute("Propeller Emulator")]
        [DescriptionAttribute("Last Propeller binary loaded (with full path).")]
        [DisplayNameAttribute("Last Binary loaded")]
        public string LastBinary
        {
            get {
                return ((string)(this["LastBinary"]));
            }
            set {
                this["LastBinary"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("False")]
        public bool UseNoTemplate {
            get {
                return ((bool)(this["UseNoTemplate"]));
            }
            set {
                this["UseNoTemplate"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("1024")]
        [CategoryAttribute("Propeller Emulator")]
        [DescriptionAttribute("How many clock steps will pass between screen repaint of emulator and plugins.")]
        [DisplayNameAttribute("Update screen each steps")]
        [DefaultValueAttribute(typeof(uint), "1024")]
        public uint UpdateEachSteps
        {
            get {
                return ((uint)(this["UpdateEachSteps"]));
            }
            set {
                this["UpdateEachSteps"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("1E-04")]
        [CategoryAttribute("Logic Probe")]
        [DescriptionAttribute("Width of time frame for the logic probe window.")]
        [DisplayNameAttribute("Last Time Frame")]
        [DefaultValueAttribute((double)1E-04)]
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
        [global::System.Configuration.DefaultSettingValueAttribute("5E-05")]
        [CategoryAttribute("Logic Probe")]
        [DescriptionAttribute("Time interval for the logic probe grid.")]
        [DisplayNameAttribute("Last Tick mark Grid")]
        [DefaultValueAttribute((double)5E-05)]
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
        [global::System.Configuration.DefaultSettingValueAttribute("True")]
        [CategoryAttribute("Plugin Editor")]
        [DescriptionAttribute("Flag to embed the C# code of the plugin into XML file, or to " + 
            "create in a separated .CS file.")]
        [DisplayNameAttribute("Embedded code?")]
        [DefaultValueAttribute(true)]
        public bool EmbeddedCode {
            get {
                return ((bool)(this["EmbeddedCode"]));
            }
            set {
                this["EmbeddedCode"] = value;
            }
        }
    }
}
