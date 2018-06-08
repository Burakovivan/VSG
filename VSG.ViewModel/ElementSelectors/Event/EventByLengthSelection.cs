using ScriptPortal.Vegas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VSG.ViewModel.ElementSelectors
{
    public class EventByLengthSelection : EventSelector
    {
        public Timecode MinLength { get; set; }
        public Timecode MaxLength { get; set; }
    }
}
