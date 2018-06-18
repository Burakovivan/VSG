using ScriptPortal.Vegas;
using System.Linq;
using VSG.ViewModel;
using VSG.ViewModel.ElementSteps;
using VSG.ViewModel.Enums;

namespace VSG.Core.Services
{
    public static class SetEffectService
    {
        public static void SetEffectToElement(ElementStep elementStep)
        {
            if(!elementStep.Selector.IsValid() || elementStep.Selector.ElementType == ElementType.None)
            {
                return;
            }

            if(elementStep.Selector.ElementType == ElementType.Event)
            {
                TrackEvent trackEvent = SelectorService.GetEvent(elementStep.Selector);
                PlugInNode pin = SelectorService.GetPlugIn(elementStep.DataPropertyList[DataPropertyHolder.EFFECT_NAME].Value);
                string effectPrest = string.IsNullOrEmpty(elementStep.DataPropertyList[DataPropertyHolder.EFFECT_PRESET_NAME].Value)
                    ? SelectorService.GetPresets(pin)[0]
                    : elementStep.DataPropertyList[DataPropertyHolder.EFFECT_PRESET_NAME].Value;
                Effect effect = new Effect(pin);
                if(elementStep.Selector.IsAudio())
                {
                    (trackEvent as AudioEvent).Effects.Add(effect);
                }
                if(elementStep.Selector.IsVideo())
                {
                    (trackEvent as VideoEvent).Effects.Add(effect);
                }
                effect.Preset = effectPrest;
            }
            if(elementStep.Selector.ElementType == ElementType.Track)
            {
                Track track = SelectorService.GetTrack(elementStep.Selector);
                PlugInNode pin = SelectorService.GetPlugIn(elementStep.DataPropertyList[DataPropertyHolder.EFFECT_NAME].Value);
                string effectPrest = string.IsNullOrEmpty(elementStep.DataPropertyList[DataPropertyHolder.EFFECT_PRESET_NAME].Value)
                    ? SelectorService.GetPresets(pin)[0]
                    : elementStep.DataPropertyList[DataPropertyHolder.EFFECT_PRESET_NAME].Value;
                Effect effect = new Effect(pin);
                track.Effects.Add(effect);
                effect.Preset = effectPrest;
            }
        }
    }
}
