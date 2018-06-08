using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VegasWrapper = ScriptPortal.Vegas.Vegas;
using VegasProject = ScriptPortal.Vegas.Project;
using ScriptPortal.Vegas;

namespace VSG.Assembler
{
    public static class VegasHandler
    {
        public static VegasWrapper Vegas { get; set; }
        public static void Initialize(VegasWrapper vegas)
        {
            Vegas = vegas;
        }

       
    }
}
