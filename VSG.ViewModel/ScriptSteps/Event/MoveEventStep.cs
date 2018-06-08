using ScriptPortal.Vegas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VSG.ViewModel.ElementSelectors;
using VSG.ViewModel.Enums;

namespace VSG.ViewModel.ScriptSteps.Event
{
    public class MoveEventStep : ElementStep<EventSelector>
    {
        public MoveType MoveType { get; set; }
        public Timecode Timecode { get; set; }
    }
}
