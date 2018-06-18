using System.Collections.Generic;
using System.Linq;
using VSG.ViewModel;
using VSG.ViewModel.ElementSteps;

namespace VSG.App.ViewModels
{
    public class ElementStepViewModel
    {
        public ElementStep ElementStep { get; set; }

        public string TypeDescription => ElementStep.GetType().Name;
        public string SelectorDescription => $"{ElementStep.Selector.ElementMediaType}{ElementStep.Selector.ElementType} {ElementStep.Selector.SelectorType} {(string.IsNullOrEmpty(ElementStep.Selector.Name)?"":$"'{ElementStep.Selector.Name}'")}";
        public string DataDescription => "{" + string.Join(";", ElementStep.DataPropertyList.Select(x => x.Value.DisplayName + " = " + x.Value.Value)) + "}";
    }
}
