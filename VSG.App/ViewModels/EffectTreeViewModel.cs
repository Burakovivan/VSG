using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VSG.App.ViewModel
{
    public class EffectTreeViewModel
    {
        public bool IsContainer { get; set; }
        public ObservableCollection<EffectTreeViewModel> Items{ get; set; }
        public string Name { get; set; }
        public EffectTreeViewModel(){
            Items = new ObservableCollection<EffectTreeViewModel>();
        }
    }
}
