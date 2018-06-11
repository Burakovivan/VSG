using ScriptPortal.Vegas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VSG.ViewModel.Enums;

namespace VSG.ViewModel.ElementSteps
{
    public class MoveStep : ElementStep
    {
        public MoveType MoveType { get; set; }
        public Timecode Timecode { get; set; }
    }
}
