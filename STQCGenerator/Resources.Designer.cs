﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace STQCGenerator {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "17.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("STQCGenerator.Resources", typeof(Resources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to About....
        /// </summary>
        public static string AboutMenu {
            get {
                return ResourceManager.GetString("AboutMenu", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Format.
        /// </summary>
        public static string FormatLabel {
            get {
                return ResourceManager.GetString("FormatLabel", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Incorrect format string.
        /// </summary>
        public static string FormatParseError {
            get {
                return ResourceManager.GetString("FormatParseError", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Input doesnt follow the format.
        /// </summary>
        public static string InputFormatError {
            get {
                return ResourceManager.GetString("InputFormatError", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Input.
        /// </summary>
        public static string InputLabel {
            get {
                return ResourceManager.GetString("InputLabel", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Output device.
        /// </summary>
        public static string OutputDeviceLabel {
            get {
                return ResourceManager.GetString("OutputDeviceLabel", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Output.
        /// </summary>
        public static string OutputLabel {
            get {
                return ResourceManager.GetString("OutputLabel", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Value over range in group .
        /// </summary>
        public static string OverrangeError {
            get {
                return ResourceManager.GetString("OverrangeError", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Play.
        /// </summary>
        public static string PlayAudioButton {
            get {
                return ResourceManager.GetString("PlayAudioButton", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to STQC Generator.
        /// </summary>
        public static string ProgramTitle {
            get {
                return ResourceManager.GetString("ProgramTitle", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Reset to default.
        /// </summary>
        public static string ResetToDefaultMenu {
            get {
                return ResourceManager.GetString("ResetToDefaultMenu", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Save audio.
        /// </summary>
        public static string SaveAudioButton {
            get {
                return ResourceManager.GetString("SaveAudioButton", resourceCulture);
            }
        }
    }
}
