using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ScriptPortal.Vegas;
using VSG.Model.Enums;

namespace VegasScriptGenerator.Effects.Services
{
    public interface IEffectService<T> where T : TrackEvent
    {
        [VSGMethodType(MethodType = MethodType.Add)]
        T AddEffect(T tEvent, string effectName, string preset = null);
        [VSGMethodType(MethodType = MethodType.Add)]
        T AddEffect(T tEvent, Effect effect, string preset = null);
        [VSGMethodType(MethodType = MethodType.Remove)]
        void RemoveEffect(T tEvent, Effect effect);
        [VSGMethodType(MethodType = MethodType.Remove)]
        void RemoveEffect(T tEvent, string effectName);
    }
}
