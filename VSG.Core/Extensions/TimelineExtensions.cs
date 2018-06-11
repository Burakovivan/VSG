using ScriptPortal.Vegas;
using System;
using VSG.Model.Enums;

namespace VegasScriptGenerator.Extensions
{
    public static class TimelineExtensions
    {
        public static void RemoveSelection(this Vegas vegas)
        {
            vegas.Cursor += Timecode.FromMilliseconds(1);
            vegas.Cursor -= Timecode.FromMilliseconds(1);
            vegas.Project.ForEachEvent((tEvent) => tEvent.Selected = false);
        }

        [VSGMethodType(MethodType = MethodType.Modificator)]
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

        [VSGMethodType(MethodType = MethodType.Modificator)]
        public static void ForEachTrack(this Project proj, Action<Track> action)
        {
            foreach (var track in proj.Tracks)
            {
                action(track);
            }
        }

    }
}
