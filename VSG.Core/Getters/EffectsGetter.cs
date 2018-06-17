using ScriptPortal.Vegas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using VSG.ViewModel.Attributes;
using VSG.ViewModel.Enums;

namespace VSG.Effects.Getters
{

    public static class EffectsGetter
    {
        private static Vegas vegas = MainContainer.Vegas;

        public static List<string> GetPlugIns()
        {
            var plugInsList = new List<string>();
            var plugInsSB = new StringBuilder();
            GetPlugInNodeList(vegas.PlugIns, plugInsList, plugInsSB);

            System.IO.File.WriteAllText("Effects.txt", plugInsSB.ToString());
            System.Diagnostics.Process.Start("Effects.txt");
            
            return plugInsList;
        }

        public static PlugInNode GetPlugIn(string plugInName)
        {
            var pin = vegas.PlugIns.GetChildByName(plugInName);

            if (pin != null && !pin.GetEnumerator().MoveNext())
                return pin;
            else
                throw new ArgumentException($"There is no PlugInNode (Effect) with name '{plugInName}'", nameof(plugInName));
        }

        public static void GetPlugInNodeList(PlugInNode pin, List<string> plugInsList, StringBuilder plugInsSB, int deep = 0)
        {

            var pinEnum = pin.GetEnumerator();
            if (pinEnum.MoveNext())
            {
                plugInsSB.Append($"{new string('\t', deep)}PlugInNode:'{pin.Name}'{Environment.NewLine}");
                //GetPresets(pin, deep + 1, plugInsList, plugInsSB);

                do { GetPlugInNodeList(pinEnum.Current, plugInsList, plugInsSB, deep + 1); }
                while (pinEnum.MoveNext());
            }
            else
            {
                plugInsList.Add($"{pin.Name}");
                plugInsSB.Append($"{new string('\t', deep)}PlugIn:'{pin.Name}'{Environment.NewLine}");
                GetPresets(pin, deep + 1, plugInsList, plugInsSB);

            }

        }

        public static List<string> GetPresets(PlugInNode pin, int deep, List<string> plugInsList, StringBuilder plugInsSB)
        {

            plugInsSB.AppendLine(pin.Presets.Count > 0 ? String.Join(Environment.NewLine, pin.Presets.Select(p => $"{new string('\t', deep)}Preset:[{p.Index}] '{p.Name}'").ToArray()) : $"{new string('\t', deep)}none presets");

            return pin.Presets.Select(p => $"{new string('\t', deep)}[{p.Index}] '{p.Name}'").ToList();

        }

    }
}
