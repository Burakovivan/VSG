using AutoMapper;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VSG.Translator;

namespace VSG.App.ViewModel
{
    public class EffectTreeViewModel
    {
        private static EffectService EffectService;
        static EffectTreeViewModel()
        {
            EffectService = new EffectService();
        }
        public bool IsContainer { get; set; }
        public ObservableCollection<EffectTreeViewModel> Items { get; set; }
        public string Name { get; set; }
        public EffectTreeViewModel()
        {
            Items = new ObservableCollection<EffectTreeViewModel>();
        }
        public static EffectTreeViewModel GetEffectTree()
        {
            return Mapper.Map<EffectTreeViewModel>(EffectService.GetEffectTree());
        }
    }
}
