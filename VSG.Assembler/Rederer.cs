using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using VSG.ViewModel.ElementSteps;
using VSG.ViewModel.Enums;

namespace VSG.Assembler
{
    public static class Renderer
    {
        public static string Render(List<ElementStep> list)
        {
            StringBuilder sb = new StringBuilder();
            var baseTab = 3;
            var baseT = new string(' ', baseTab * 4);
            var t = new string(' ', (baseTab + 1) * 4);
            var tt = new string(' ', (baseTab + 2) * 4);
            var ttt = new string(' ', (baseTab + 3) * 4);
            foreach(var step in list)
            {
                if(step is AddStep)
                {
                    sb.AppendLine($"{baseT}AddElementService.AddElement(new {step.GetType().FullName} (");
                }
                if(step is RemoveStep)
                {
                    sb.AppendLine($"{baseT}RemoveElementService.RemoveElement(new {step.GetType().FullName} (");
                }
                if(step is MoveStep)
                {
                    sb.AppendLine($"{baseT}MoveElementService.MoveElement(new {step.GetType().FullName} (");
                }
                if(step is SetEffectStep)
                {
                    sb.AppendLine($"{baseT}SetEffectService.SetEffectToElement(new {step.GetType().FullName} (");
                }
                sb.AppendLine($"{t}new ElementSelector{{");
                sb.AppendLine($"{tt}ElementMediaType = {typeof(ElementMediaType)}.{step.Selector.ElementMediaType.ToString()},");
                sb.AppendLine($"{tt}ElementType = {typeof(ElementType)}.{step.Selector.ElementType.ToString()},");
                sb.Append($"{tt}SelectorType = {typeof(SelectorType)}.{step.Selector.SelectorType.ToString()}");
                if(!string.IsNullOrEmpty(step.Selector.Name))
                {
                    sb.Append(",");
                    sb.AppendLine($"{tt}Name = \"{step.Selector.Name}\"}}");
                }else{
                    sb.Append("}");
                }

                if(step.DataPropertyList != null)
                {
                    sb.AppendLine($",{t}new System.Collections.Generic.Dictionary<string, DataProperty>{{");
                    foreach(var dp in step.DataPropertyList)
                    {
                        sb.AppendLine($"{tt}{{DataPropertyHolder.{dp.Key}, new DataProperty {{ Value =\"{dp.Value.Value}\" }} }},");
                    }
                    sb.AppendLine($"{baseT}}}));");
                }
                else
                {
                    sb.AppendLine($"{baseT}));");
                }
            }
            var codeTemplate = TemplateResources.NewVegasCodeTemplate;
            var codePlaceholder = TemplateResources.CodePlaceholder;
            var generatedCode = sb.ToString();
            generatedCode = codeTemplate.Replace(codePlaceholder, generatedCode);
            return generatedCode;
        }
    }
}

