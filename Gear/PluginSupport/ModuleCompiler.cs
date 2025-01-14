/* --------------------------------------------------------------------------------
 * Gear: Parallax Inc. Propeller P1 Emulator
 * Copyright 2007-2022 - Gear Developers
 * --------------------------------------------------------------------------------
 * ModuleCompiler.cs
 * Provides the reflection base and compiler components for plugins
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

using Microsoft.CSharp;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Reflection;
using System.Windows.Forms;

namespace Gear.PluginSupport
{
    /// <summary></summary>
    /// <param name="compErr"></param>
    public delegate void ErrorEnumProc(CompilerError compErr);

    /// <summary>Compile a PluginBase Module, keeping the errors if they
    /// appears.</summary>
    public static class ModuleCompiler
    {
        /// <summary>Error list generated when compiling a dynamic plugin.</summary>
        /// @version v22.06.02 - Changed member name to clarify its meaning.
        private static CompilerErrorCollection _errorList;

        /// <summary>Enumerate errors from the compiling process.</summary>
        /// @param proc Method to invoke for each error.
        /// <exception cref="InvalidOperationException">If the collection of
        /// compiler errors is null.</exception>
        /// <exception cref="ArgumentNullException">If delegate <c>proc</c>
        /// is null.</exception>
        /// @version v22.06.02 - Local variable name changed to clarify
        /// its meaning.
        public static void EnumerateErrors(ErrorEnumProc proc)
        {
            if (_errorList == null)
                throw new InvalidOperationException(
                    $"CompilerErrorCollection '{nameof(_errorList)}' is null. " +
                    "Had ModuleCompiler.LoadModule() successfully run?");
            if (proc == null)
                throw new ArgumentNullException(nameof(proc));
            foreach (CompilerError errorItem in _errorList)
                proc(errorItem);
        }

        /// <summary>Dynamic compiling & loading for a plugin.</summary>
        /// <remarks>Try to dynamically compile a className for the plugin,
        /// based on supplied C# code and other C# modules referenced. If the
        /// compiling fails, it gives a list of errors, intended to be showed
        /// in the plugin view.</remarks>
        /// @param code C# Source code based on PluginBase class, to implement your plugin.
        /// @param className Class name of the plugin.
        /// @param references String array with auxiliary references used by your plugin.
        /// See notes for defaults used.
        /// @param cpuHost Reference to a PropellerCPU of this instance, to be passed as a
        /// parameter to the constructor of the new plugin class instance.
        /// <returns>New Plugin class instance compiled (on success),
        /// or NULL (on fail).</returns>
        /// <exception cref="ArgumentNullException">If parameter references is
        /// null.</exception>
        /// @note There are some references already added, so you don't need
        /// to include on your plugins:
        /// @li `using System;` @li `using System.Data;` @li `using System.Drawing;`
        /// @li `using System.Windows.Forms;` @li `using System.Xml;`
        /// @version v22.05.02 - Changes as throw exception, changed parameter and
        /// local variable name for better comprehension, use string interpolation,
        /// and no need of use cast to return value.
        public static PluginBase LoadModule(string code, string className,
            string[] references, object cpuHost)
        {
            //set compiler version: is the maximum allowed by Microsoft.CSharp
            Dictionary<string, string> provOptions =
                new Dictionary<string, string> { { "CompilerVersion", "v4.0" } };
            //create new compiler version
            CodeDomProvider provider = new CSharpCodeProvider(provOptions);
            CompilerParameters compilerParameters = new CompilerParameters
            {
#if DEBUG
                IncludeDebugInformation = true,
#else
                IncludeDebugInformation = false,
#endif
                GenerateExecutable = false,
                GenerateInMemory = true,
                CompilerOptions = "/optimize"
            };

            compilerParameters.ReferencedAssemblies.Add(Application.ExecutablePath);
            compilerParameters.ReferencedAssemblies.Add("System.dll");
            compilerParameters.ReferencedAssemblies.Add("System.Data.dll");
            compilerParameters.ReferencedAssemblies.Add("System.Drawing.dll");
            compilerParameters.ReferencedAssemblies.Add("System.Xml.dll");
            compilerParameters.ReferencedAssemblies.Add("System.Windows.Forms.dll");

            if (references == null)
                throw new ArgumentNullException(nameof(references));
            foreach (string reference in references)
                compilerParameters.ReferencedAssemblies.Add(reference);

            CompilerResults results = provider.CompileAssemblyFromSource(compilerParameters, code);

            if (results.Errors.HasErrors | results.Errors.HasWarnings)
            {
                _errorList = results.Errors;
                return null;
            }

            //compile plugin with parameters
            object target = results.CompiledAssembly.CreateInstance(
                className,                                    //name of class
                false,                                        //=false: case sensitive
                BindingFlags.Public | BindingFlags.Instance,  //flags to delimit the candidates
                null,                                         //default binder object
                new[] { cpuHost },                            //parameter lists
                null,                                         //default culture
                null                                          //default activation object
            );

            if (target == null)
            {
                CompilerError c = new CompilerError(string.Empty, 0, 0, "CS0103",
                    $"The name '{className}' does not exist in the current context. Does the class name is the same that is declared in c# code?");
                _errorList = new CompilerErrorCollection(new[] { c });
                return null;
            }
            if (!(target is PluginBase pluginBase))
            {
                CompilerError c = new CompilerError(string.Empty, 0, 0, "CS0029",
                    $"Cannot implicitly convert type '{target.GetType().FullName}' to 'Gear.PluginSupport.PluginBase'");
                _errorList = new CompilerErrorCollection(new[] { c });
                return null;
            }
            _errorList = null;
            return pluginBase;
        }
    }
}
