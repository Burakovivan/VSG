using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VSG.Assembler;
using VegasWrapper = ScriptPortal.Vegas.Vegas;

namespace VSG.Bootstrapper
{
    public class Bootsrpapper
    {
        public static void Bootsrpapp(VegasWrapper  vegas)
        {
            var process = System.Diagnostics.Process.GetProcesses().Where(x => x.ProcessName.ToLower().Contains("vegas")).First();
            VegasHandler.Initialize(vegas);
            var app = new App.App();
            app.Run(new App.MainWindow());
        }
    }
}
