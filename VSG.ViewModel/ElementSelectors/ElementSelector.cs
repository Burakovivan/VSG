using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VSG.ViewModel.Enums;

namespace VSG.ViewModel.ElementSelectors
{
    public abstract class ElementSelector
    {
        public ElementMediaType ElementMediaType{ get; set; }
    }
}
