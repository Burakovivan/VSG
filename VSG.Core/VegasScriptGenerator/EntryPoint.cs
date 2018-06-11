using ScriptPortal.Vegas;
using VegasScriptGenerator.Effects.Services;
using VegasScriptGenerator.Selectors;
using VegasScriptGenerator;
using VegasScriptGenerator.Extensions;
using System.Linq;

public class EntryPoint
{
    public void FromVegas(Vegas vegas)
    {
        MainContainer.Vegas = vegas;

        var vidEffService = new VideoEffectService();
        vidEffService.AddEffect(videoEvent: TrackEventSelector.GetSelectedEvent().AsVideoEvent(),
                                effectName: "VEGAS Color Corrector123",
                                preset: "Green Highlight");
        
    }
}


