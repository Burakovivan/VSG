using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VSG.ViewModel.ElementSteps
{
    public class AddStep : ElementStep
    {

        public AddStep(ElementSelector selector, Dictionary<string, DataProperty> data = null)
        {
            Selector = selector;
            DataPropertyList = data;
            if(DataPropertyList == null)
            {
                if(Selector.ElementType == Enums.ElementType.Event)
                {
                    DataPropertyList = new Dictionary<string, DataProperty>{
                    {DataPropertyHolder.TIMECODE, new DataProperty { DisplayName = "Position:" } },
                    {DataPropertyHolder.RESOURCE_NAME, new DataProperty { DisplayName = "Resource name:" } }
                };
                }
                if(Selector.ElementType == Enums.ElementType.Track)
                {
                    DataPropertyList = new Dictionary<string, DataProperty>{
                    {DataPropertyHolder.RESOURCE_NAME, new DataProperty { DisplayName = "Track name:" } }
                };
                }
            }
        }
    }
}
