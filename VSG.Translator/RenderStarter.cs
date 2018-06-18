using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using VSG.ViewModel.ElementSteps;

namespace VSG.Translator
{
    public static class Renderer
    {
        public static void StartRender(
            List<ElementStep> stepList, string folderPath,
            string outputScriptName = "vsg_script.dll")
        {
            outputScriptName = outputScriptName.Contains(".dll") ? outputScriptName : outputScriptName + ".dll";
            var sourceCode = Assembler.Renderer.Render(stepList);
            CodeDomProvider provider = CodeDomProvider.CreateProvider("cs");
            CompileCode(provider, sourceCode, outputScriptName, folderPath);
            Directory.GetFiles(
                Directory.GetCurrentDirectory())
                    .Where(f =>
                        new string[] { "tmp", "cmdline", "out", "err" }
                            .Any(ext => f.Contains(ext))).ToList()
                                .ForEach(file => File.Delete(file));
        }

        private static bool CompileCode(CodeDomProvider provider,
           String sourceCode,
           String outputAssemblyName, String folderPath)
        {
            CompilerParameters cp = new CompilerParameters
            {
                OutputAssembly = outputAssemblyName,
                IncludeDebugInformation = false,
                GenerateInMemory = false,
                TreatWarningsAsErrors = false,
                WarningLevel = 3,
                CompilerOptions = "/optimize /langversion:5",
                TempFiles = new TempFileCollection(".", true),
            };
            cp.ReferencedAssemblies.AddRange(new string[]{
            "System.dll","ScriptPortal.Vegas.dll","VSG.Core.dll",
            "VSG.ViewModel.dll" ,"System.Windows.Forms.dll" });
            CompilerResults cr = provider.CompileAssemblyFromSource(cp, sourceCode);
            if(cr.Errors.Count > 0)
            {
                var errorString = $"Errors building into {cr.PathToAssembly}";
                foreach(CompilerError ce in cr.Errors)
                {
                    errorString += $"\n  {ce}";
                }
                MessageBox.Show(errorString, "Compilation Error!");
            }
            else
            {
                File.Move(outputAssemblyName, Path.Combine(folderPath, outputAssemblyName));
                MessageBox.Show($"Source built into {cr.PathToAssembly} successfully.", "Success!");
            }
            return cr.Errors.Count == 0;
        }

    }
}
