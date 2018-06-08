using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VSG.ViewModel.ElementSelectors;
using VSG.ViewModel.Enums;

namespace VSG.ViewModel.ScriptSteps
{
    public abstract class ElementStep<TSelector> : ScriptStep  where TSelector : ElementSelector
    {
        public TSelector Selector { get; set; }
        
    }
}
