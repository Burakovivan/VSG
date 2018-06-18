using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VSG.ViewModel.Enums;

namespace VSG.ViewModel.ElementSteps
{
    public class MoveStep : ElementStep
    {
        public MoveStep(ElementSelector selector, Dictionary<string, DataProperty> data = null)
        {

            Selector = selector;
            DataPropertyList = data;
            if(DataPropertyList == null)
            {
                if(Selector.ElementType == Enums.ElementType.Event)
                {
                    DataPropertyList = new Dictionary<string, DataProperty>{
                        {DataPropertyHolder.TIMECODE, new DataProperty { DisplayName = "Postion :" } },
                    };
                }
            }
        }
    }
}
