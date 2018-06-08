using ScriptPortal.Vegas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VSG.ViewModel.ScriptSteps.Event
{
    public class AddEventStep: ScriptStep
    {
        public string ResourceName { get; set; }
        public Timecode Position { get; set; }
    }
}
