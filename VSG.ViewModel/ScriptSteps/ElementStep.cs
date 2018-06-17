using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VSG.ViewModel.Enums;

namespace VSG.ViewModel.ElementSteps
{
    public class ElementStep
    {

        public ElementSelector Selector { get; set; }
        public Dictionary<string,DataProperty> DataPropertyList { get; set; }

        public ElementStep()
        {
            Selector = new ElementSelector();
        }

    }
}
