using ScriptPortal.Vegas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VegasScriptGenerator.Selectors
{
    public static class TrackEventSelector
    {
        private static Vegas vegas = MainContainer.Vegas;
        public static TrackEvent GetEventByName(string trackEventName)
        {
            try
            {
                return vegas.Project.Tracks.SelectMany(t=>t.Events).Single(tEvent => tEvent.Name == trackEventName);
            }
            catch (InvalidOperationException)
            {
                throw new ArgumentException($"There is no Track with name '{trackEventName}'", nameof(trackEventName));
            }
        }

        public static TrackEvent GetSelectedEvent()
        {
            try
            {
                return GetAllTrackEvent().Single(tEvent => tEvent.Selected);
            }
            catch (InvalidOperationException)
            {
                throw new ArgumentException($"There is no selected Track");
            }
        }
        public static IEnumerable<TrackEvent> GetAllTrackEvent()
        {
            return vegas.Project.Tracks.SelectMany(t => t.Events);
        }

        public static IEnumerable<VideoEvent> GetAllVideoEvent()
        {
            return vegas.Project.Tracks.SelectMany(t => t.Events).Where(t=>t.IsVideo()).Cast<VideoEvent>();
        }
        public static IEnumerable<AudioEvent> GetAllAudioEvent()
        {
            return vegas.Project.Tracks.SelectMany(t => t.Events).Where(t => t.IsVideo()).Cast<AudioEvent>();
        }
    }
}
