using ScriptPortal.Vegas;
using System;

namespace VSG.Extensions
{
    public static class TimelineExtensions
    {
        public static void RemoveSelection(this Vegas vegas)
        {
            vegas.Cursor += Timecode.FromMilliseconds(1);
            vegas.Cursor -= Timecode.FromMilliseconds(1);
            vegas.Project.ForEachEvent((tEvent) => tEvent.Selected = false);
        }

        public static void ForEachEvent(this Project proj, Action<TrackEvent> action)
        {
            foreach (var track in proj.Tracks)
            {
                foreach (var tEvent in track.Events)
                {
                    action(tEvent);
                }
            }
        }

        public static void ForEachTrack(this Project proj, Action<Track> action)
        {
            foreach (var track in proj.Tracks)
            {
                action(track);
            }
        }

    }
}
