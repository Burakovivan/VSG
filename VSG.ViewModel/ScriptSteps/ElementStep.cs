using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VSG.ViewModel.Enums;

namespace VSG.ViewModel.ElementSteps
{
    public abstract class ElementStep
    {

        public ElementSelector Selector { get; set; }
        public Dictionary<string, object> Data { get; set; }

        public string TypeDescription => GetType().Name;
        public string SelectorDescription => Selector.ElementMediaType.ToString();
        public string DataDescription => "{" + string.Join(";", Data.Select(x => x.Key + " = " + x.Value)) + "}";

        public ElementStep()
        {
            Selector = new ElementSelector();
            Data = new Dictionary<string, object>();
        }

    }
}
