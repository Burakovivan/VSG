using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using VSG.ViewModel.ElementSteps;

namespace VSG.Translator
{
    public static class Renderer
    {
        public static void StartRender(List<ElementStep> stepList, string name = "vsg_script.dll")
        {
            var sourceCode = Assembler.Renderer.Render(stepList);
            CodeDomProvider provider = null;
            String exeName = name;

            var prodiders = CodeDomProvider.GetAllCompilerInfo();
            provider = CodeDomProvider.CreateProvider("cs");

            if(CompileCode(provider, sourceCode, exeName))
                Console.WriteLine("VegScript.dll executable.");

            foreach(var f in Directory.GetFiles(Directory.GetCurrentDirectory()).Where(f => new string[] { "tmp", "cmdline", "out", "err" }.Any(ext => f.Contains(ext))))
            {
                File.Delete(f);
            }
            Console.ReadLine();
        }
        private static bool CompileCode(CodeDomProvider provider,
           String sourceFile,
           String exeFile)
        {

            CompilerParameters cp = new CompilerParameters();

            // Generate an executable instead of 
            // a class library.
            //cp.GenerateExecutable = false;


            // Set the assembly file name to generate.
            cp.OutputAssembly = exeFile;

            // Generate debug information.
            cp.IncludeDebugInformation = true;

            //Add an assembly reference.
            cp.ReferencedAssemblies.Add("System.dll");
            cp.ReferencedAssemblies.Add("ScriptPortal.Vegas.dll");
            cp.ReferencedAssemblies.Add("VSG.Core.dll");
            cp.ReferencedAssemblies.Add("VSG.ViewModel.dll");
            cp.ReferencedAssemblies.Add("System.Windows.Forms.dll");

            // Save the assembly as a physical file.
            cp.GenerateInMemory = false;

            // Set the level at which the compiler 
            // should start displaying warnings.
            cp.WarningLevel = 3;

            // Set whether to treat all warnings as errors.
            cp.TreatWarningsAsErrors = false;

            // Set compiler argument to optimize output.
            cp.CompilerOptions = "/optimize /langversion:5";

            // Set a temporary files collection.
            // The TempFileCollection stores the temporary files
            // generated during a build in the current directory,
            // and does not delete them after compilation.
            cp.TempFiles = new TempFileCollection(".", true);



            //if (Directory.Exists("Resources"))
            //{
            //    if (provider.Supports(GeneratorSupport.Resources))
            //    {
            //        // Set the embedded resource file of the assembly.
            //        // This is useful for culture-neutral resources,
            //        // or default (fallback) resources.
            //        cp.EmbeddedResources.Add("Resources\\Default.resources");

            //        // Set the linked resource reference files of the assembly.
            //        // These resources are included in separate assembly files,
            //        // typically localized for a specific language and culture.
            //        cp.LinkedResources.Add("Resources\\nb-no.resources");
            //    }
            //}

            // Invoke compilation.
            CompilerResults cr = provider.CompileAssemblyFromSource(cp, sourceFile);

            if(cr.Errors.Count > 0)
            {
                // Display compilation errors.
                var errorString = $"Errors building into {cr.PathToAssembly}";
                foreach(CompilerError ce in cr.Errors)
                {
                    errorString += $"\n  {ce}";
                }
                System.Windows.MessageBox.Show(errorString, "Compilation Error!");
            }
            else
            {
                System.Windows.MessageBox.Show($"Source built into {cr.PathToAssembly} successfully.", "Success!");
            }

            // Return the results of compilation.
            if(cr.Errors.Count > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
