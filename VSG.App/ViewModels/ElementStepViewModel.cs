using System.Collections.Generic;
using System.Linq;

namespace VSG.App.ViewModels
{
    public class ElementStepViewModel
    {
        public string TypeDescription { get; set; }
        public string SelectorDescription { get; set; }
        public Dictionary<string, object> Data { get; set; }
        public string DataDescription
        {
            get
            {
                return "{" + string.Join(";", Data.Select(x => x.Key + " = " + x.Value)) + "}";
            }
        }
    }
}
