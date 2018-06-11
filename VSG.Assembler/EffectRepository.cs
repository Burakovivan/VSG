using ScriptPortal.Vegas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VSG.ViewModel;

namespace VSG.Assembler
{
    public class EffectRepository
    {
        public void GetEffectList()
        {
            throw new NotImplementedException();
        }

        public void GetPresetByEffectName(string name)
        {
            throw new NotImplementedException();
        }


        public static EffectTreeModel GetPlugInsTree()
        {
            var plugInsTree = new EffectTreeModel();
            var plugInsSB = new StringBuilder();
            GetPlugInNodeTree(VegasHandler.Vegas.PlugIns, plugInsTree, plugInsSB);
            plugInsTree = plugInsTree.Items?.FirstOrDefault();
            //System.IO.File.WriteAllText("Effects.txt", plugInsSB.ToString());
            //System.Diagnostics.Process.Start("Effects.txt");

            return plugInsTree;
        }
        public static List<string> GetPlugInsByParentName(string parentName)
        {
            IEnumerator<PlugInNode> pinEnum = GetPlugIn(parentName).GetEnumerator();
            var plugInsList = new List<string>();
            while(pinEnum.MoveNext())
            {
                plugInsList.Add($"{pinEnum.Current.Name}");
                //plugInsSB.Append($"{new string('\t', deep)}PlugIn:'{pin.Name}'{Environment.NewLine}");
                //GetPresets(pin, deep + 1, plugInsList, plugInsSB);
            }
            return plugInsList;
        }

        public static PlugInNode GetPlugIn(string plugInName)
        {
            PlugInNode pin = VegasHandler.Vegas.PlugIns.GetChildByName(plugInName);

            if(pin != null && pin.Any())
            {
                return pin;
            }
            else
            {
                throw new ArgumentException($"There is no PlugInNode (Effect) with name '{plugInName}'", nameof(plugInName));
            }
        }

        public static void GetPlugInNodeTree(PlugInNode pin, EffectTreeModel plugInsTree, StringBuilder plugInsSB = null, int deep = 0)
        {
            if(plugInsSB == null)
            {
                plugInsSB = new StringBuilder();
            }

            IEnumerator<PlugInNode> pinEnum = pin.GetEnumerator();
            if(pin.IsContainer)
            {
                var current = new EffectTreeModel
                {
                    Name = pin.Name,
                    IsContainer = false
                };
                plugInsSB.Append($"{new string('\t', deep)}{(pin.Any() ? "+" : "-")} PlugInNode:'{pin.Name}'{Environment.NewLine}");
                //GetPresets(pin, deep + 1, plugInsList, plugInsSB);
                while(pinEnum.MoveNext())
                {
                    GetPlugInNodeTree(pinEnum.Current, current, plugInsSB, deep + 1);
                }
                plugInsTree.Items.Add(current);
            }
            else
            {
                var current = new EffectTreeModel
                {
                    Name = pin.Name,
                    IsContainer = true
                };
                plugInsSB.Append($"{new string('\t', deep)}PlugIn:'{pin.Name}'{Environment.NewLine}");
                GetPresets(pin, deep + 1, current, plugInsSB);
                plugInsTree.Items.Add(current);
            }
        }

        public static List<string> GetPresets(PlugInNode pin, int deep, EffectTreeModel plugInsTree, StringBuilder plugInsSB)
        {

            plugInsSB.AppendLine(pin.Presets.Count > 0 ? String.Join(Environment.NewLine, pin.Presets.Select(p => $"{new string('\t', deep)}Preset:[{p.Index}] '{p.Name}'").ToArray()) : $"{new string('\t', deep)}none presets");

            return pin.Presets.Select(p => $"{new string('\t', deep)}[{p.Index}] '{p.Name}'").ToList();

        }
    }
}
