using VegasWrapper = ScriptPortal.Vegas.Vegas;
//using VegasWrapperOld = Sony.Vegas.Vegas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VSG.Assembler;
using VSG.App;
using System.Windows.Forms;

public class EntryPoint
{
    public void FromVegas(VegasWrapper vegas)
    {

        //MessageBox.Show("Vegas new");
        VSG.Bootstrapper.Bootsrpapper.Bootsrpapp(vegas);
        //MessageBox.Show("Exit");
    }
    //public void FromVegas(VegasWrapperOld vegas)
    //{
    //    //MessageBox.Show("Vegas old");
    //    VSG.Bootstrapper.Bootsrpapper.Bootsrpapp(null);
    //    //MessageBox.Show("Exit");
    //    //VSG.Bootstrapper.Bootsrpapper.Bootsrpapp(vegas);
    //}
}

