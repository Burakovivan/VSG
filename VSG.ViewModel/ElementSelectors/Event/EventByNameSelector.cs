using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VSG.ViewModel.ElementSelectors
{
    public class EventByNameSelector : EventSelector
    {
        public string NameMatch { get; set; }
    }
}
