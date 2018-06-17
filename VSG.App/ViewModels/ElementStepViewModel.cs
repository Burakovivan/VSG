using System.Collections.Generic;
using System.Linq;
using VSG.ViewModel;

namespace VSG.App.ViewModels
{
    public class ElementStepViewModel
    {
        public string TypeDescription { get; set; }
        public string SelectorDescription { get; set; }
        public Dictionary<string, DataProperty> Data { get; set; }
        public string DataDescription
        {
            get
            {
                return "{" + string.Join(";", Data.Select(x => x.Value.DisplayName + " = " + x.Value.Value)) + "}";
            }
        }
    }
}
