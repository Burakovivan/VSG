using VegasWrapper = ScriptPortal.Vegas.Vegas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VSG.Assembler;
using VSG.App;

public class EntryPoint
{
    public void FromVegas(VegasWrapper vegas) => VSG.Bootstrapper.Bootsrpapper.Bootsrpapp(vegas);
}

