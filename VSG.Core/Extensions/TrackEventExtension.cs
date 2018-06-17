using ScriptPortal.Vegas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VSG.Extensions
{
    internal static class TrackEventExtension
    {
        internal static VideoEvent AsVideoEvent(this TrackEvent tEvent)
        {
            if (tEvent.IsVideo())
            {
                return tEvent as VideoEvent;
            }
            else
            {
                throw new InvalidCastException($"{tEvent.Name} is not VideoEvent");
            }
        }
        internal static AudioEvent AsAudioEvent(this TrackEvent tEvent)
        {
            if (tEvent.IsAudio())
            {
                return tEvent as AudioEvent;
            }
            else
            {
                throw new InvalidCastException($"{tEvent.Name} is not AudioEvent");
            }
        }
    }
}
