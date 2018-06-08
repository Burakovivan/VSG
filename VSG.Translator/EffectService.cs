using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VSG.Assembler;
using VSG.ViewModel;

namespace VSG.Translator
{
    public class EffectService
    {
        public EffectTreeModel GetEffectTree()
        {
            return EffectRepository.GetPlugInsTree();
        }
        public List<string> GetPlugInsByParentName(string parentName)
        {
            return EffectRepository.GetPlugInsByParentName(parentName);
        }
    }
}
