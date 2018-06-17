using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VSG.ViewModel.Enums;

namespace VSG.ViewModel
{
    public class ElementSelector
    {
        public ElementType ElementType { get; set; }
        public ElementMediaType ElementMediaType { get; set; }
        public SelectorType SelectorType { get; set; }
        public string Name { get; set; }
        
        public bool IsAudio()
        {
            return ElementMediaType == ElementMediaType.Audio;
        }
        public bool IsVideo()
        {
            return ElementMediaType == ElementMediaType.Video;
        }
        public bool IsValid()
        {
            return !(ElementMediaType == ElementMediaType.None || ElementType == ElementType.None || SelectorType == SelectorType.None);
        }
    }
}
