using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VSG.ViewModel
{
    public class EffectTreeModel
    {
        public bool IsContainer { get; set; }
        public ObservableCollection<EffectTreeModel> Items{ get; set; }
        public string Name { get; set; }
        public EffectTreeModel(){
            Items = new ObservableCollection<EffectTreeModel>();
        }
    }
}
