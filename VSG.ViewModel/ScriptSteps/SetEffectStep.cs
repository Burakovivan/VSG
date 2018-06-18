using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VSG.ViewModel.ElementSteps
{
    public class SetEffectStep : ElementStep
    {
        public SetEffectStep(ElementSelector selector, Dictionary<string, DataProperty> data = null)
        {
            Selector = selector;
            DataPropertyList = data;
            if(DataPropertyList == null)
            {
                DataPropertyList = new Dictionary<string, DataProperty>{
                    {DataPropertyHolder.EFFECT_NAME, new DataProperty { DisplayName = "Effect Name:" } },
                    {DataPropertyHolder.EFFECT_PRESET_NAME, new DataProperty { DisplayName = "Preset name:",Value ="" } }
                };
            }
        }
    }
}
