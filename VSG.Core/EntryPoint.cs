using ScriptPortal.Vegas;
using VegasScriptGenerator.Effects.Services;
using VegasScriptGenerator.Selectors;
using VegasScriptGenerator;
using VegasScriptGenerator.Extensions;
using System.Linq;
using System;

public class EntryPoint
{
    public void FromVegas(Vegas vegas)
    {
        try
        {
            MainContainer.Vegas = vegas;

            var vidEffService = new VideoEffectService();
            vidEffService.AddEffect(videoEvent: TrackEventSelector.GetSelectedEvent().AsVideoEvent(),
                                    effectName: "VEGAS Color Corrector",
                                    preset: "Green Highligh123t");
        }
        catch (Exception ex)
        {
            System.Windows.Forms.MessageBox.Show(ex.Message, $"Error: {ex.GetType().Name}");
        }

    }
}


