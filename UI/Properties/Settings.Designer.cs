﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GpwEditor.Properties {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "14.0.0.0")]
    public sealed partial class Settings : global::System.Configuration.ApplicationSettingsBase {
        
        private static Settings defaultInstance = ((Settings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new Settings())));
        
        public static Settings Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("GPW Edit")]
        public string ApplicationName {
            get {
                return ((string)(this["ApplicationName"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Grand Prix World")]
        public string GameName {
            get {
                return ((string)(this["GameName"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("SOFTWARE\\MicroProse\\Grand Prix World\\1.00.000")]
        public string RegistryKey {
            get {
                return ((string)(this["RegistryKey"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("gpw.exe")]
        public string DefaultExecutableFileName {
            get {
                return ((string)(this["DefaultExecutableFileName"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("english.txt")]
        public string DefaultLanguageFileName {
            get {
                return ((string)(this["DefaultLanguageFileName"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("C:\\Program Files\\MicroProse\\Grand Prix World")]
        public string DefaultGameFolderPath {
            get {
                return ((string)(this["DefaultGameFolderPath"]));
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string ExecutableEditorMruGameExecutableFilePath {
            get {
                return ((string)(this["ExecutableEditorMruGameExecutableFilePath"]));
            }
            set {
                this["ExecutableEditorMruGameExecutableFilePath"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string ExecutableEditorMruLanguageFileFilePath {
            get {
                return ((string)(this["ExecutableEditorMruLanguageFileFilePath"]));
            }
            set {
                this["ExecutableEditorMruLanguageFileFilePath"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string UserGameFolderPath {
            get {
                return ((string)(this["UserGameFolderPath"]));
            }
            set {
                this["UserGameFolderPath"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string UserExecutableFilePath {
            get {
                return ((string)(this["UserExecutableFilePath"]));
            }
            set {
                this["UserExecutableFilePath"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("True")]
        public bool InitialRun {
            get {
                return ((bool)(this["InitialRun"]));
            }
            set {
                this["InitialRun"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string LanguageEditorMruLanguageFileFilePath {
            get {
                return ((string)(this["LanguageEditorMruLanguageFileFilePath"]));
            }
            set {
                this["LanguageEditorMruLanguageFileFilePath"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string LanguageEditorMruGameExecutableFilePath {
            get {
                return ((string)(this["LanguageEditorMruGameExecutableFilePath"]));
            }
            set {
                this["LanguageEditorMruGameExecutableFilePath"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string UpgradeGameMruLanguageFileFilePath {
            get {
                return ((string)(this["UpgradeGameMruLanguageFileFilePath"]));
            }
            set {
                this["UpgradeGameMruLanguageFileFilePath"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string UpgradeGameMruGameExecutableFilePath {
            get {
                return ((string)(this["UpgradeGameMruGameExecutableFilePath"]));
            }
            set {
                this["UpgradeGameMruGameExecutableFilePath"] = value;
            }
        }
    }
}
