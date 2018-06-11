using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ScriptPortal.Vegas;

namespace VegasScriptGenerator.Effects.Services
{
    public class VideoEffectService : IEffectService<VideoEvent>
    {
        public VideoEvent AddEffect(VideoEvent videoEvent, string effectName, string preset = null)
        {

            var pin = Getters.EffectsGetter.GetPlugIn(effectName);
            var effect = new Effect(pin);
            return AddEffect(videoEvent, effect, preset);
        }

        public VideoEvent AddEffect(VideoEvent videoEvent, Effect effect, string preset = null)
        {

            videoEvent.Effects.Add(effect);
            if (!string.IsNullOrEmpty(preset) && effect.PlugIn.Presets.Select(p => p.Name).Contains(preset))
            {
                effect.Preset = preset;
            }
            else
            {
                System.Windows.Forms.MessageBox.Show($"Effect {effect.PlugIn.Name} does not have '{preset?? preset : ''}' preset. Will be used Default.", "Warning");
            }
            return videoEvent;
        }

        public void RemoveEffect(VideoEvent tEvent, string effectName)
        {
            var effect = tEvent.Effects.SingleOrDefault(e => e.PlugIn.Name == effectName);
            if (effect != null)
                RemoveEffect(tEvent, effect);
        }

        public void RemoveEffect(VideoEvent tEvent, Effect effect)
        {
            tEvent.Effects.Remove(effect);
        }
    }
}
