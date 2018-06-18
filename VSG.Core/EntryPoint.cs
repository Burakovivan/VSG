using System;
using ScriptPortal.Vegas;
using VSG.Core.Services;
using VSG.ViewModel;

public class EntryPoint
{
    public void FromVegas(Vegas vegas)
    {
        try
        {
            VSG.MainContainer.Vegas = vegas;
            vegas.UnloadScriptDomainOnScriptExit = true;
            SetEffectService.SetEffectToElement(new VSG.ViewModel.ElementSteps.SetEffectStep(
                new ElementSelector
                {
                    ElementMediaType = VSG.ViewModel.Enums.ElementMediaType.Video,
                    ElementType = VSG.ViewModel.Enums.ElementType.Event,
                    SelectorType = VSG.ViewModel.Enums.SelectorType.BySelection,
                    Name = "21"
                }
, new System.Collections.Generic.Dictionary<string, DataProperty>{
                    {DataPropertyHolder.EFFECT_NAME, new DataProperty { Value ="VEGAS Glint" } },
                    {DataPropertyHolder.EFFECT_PRESET_NAME, new DataProperty { Value ="Sparkle" } },
            }));

        }
        catch(Exception ex)
        {
            System.Windows.Forms.MessageBox.Show(ex.Message, "Error: " + ex.GetType().Name);
            System.Windows.Forms.MessageBox.Show(ex.StackTrace, "Error: " + ex.GetType().Name);
        }

    }
}