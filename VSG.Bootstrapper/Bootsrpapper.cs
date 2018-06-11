using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using VSG.Assembler;
using VegasWrapper = ScriptPortal.Vegas.Vegas;

namespace VSG.Bootstrapper
{
    public class Bootsrpapper
    {
        public static void Bootsrpapp(VegasWrapper vegas)
        {
            var process = System.Diagnostics.Process.GetProcesses().Where(x => x.ProcessName.ToLower().Contains("vegas")).First();
            GC.Collect();
            if(vegas != null)
            {
                VegasHandler.Initialize(vegas);
            }
            vegas.UnloadScriptDomainOnScriptExit = true;
            Application app = new Application();
            app.Run(new App.MainWindow());
        }
    }
}
