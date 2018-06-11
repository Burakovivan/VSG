using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VSG.ViewModel.ElementSteps;

namespace VSG.Translator
{
    public class RenderStarter
    {
        public void StartRender(List<ElementStep> stepList)
        {
            Assembler.Rederer.Render(stepList);
        }
    }
}
