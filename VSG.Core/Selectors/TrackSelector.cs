using System;
using System.Linq;
using ScriptPortal.Vegas;

namespace VegasScriptGenerator.Selectors
{
    public class TrackSelector
    {
        private static Vegas vegas = MainContainer.Vegas;
        public Track GetTrackByName(string trackName)
        {
            try
            {
               return vegas.Project.Tracks.Single(t => t.Name == trackName);
            }
            catch(InvalidOperationException)
            {
                throw new ArgumentException($"There is no Track with name '{trackName}'", nameof(trackName));
            }
        }

        public Track GetSelectedTrack()
        {
            try
            {
                return vegas.Project.Tracks.Single(t => t.Selected);
            }
            catch (InvalidOperationException)
            {
                throw new ArgumentException($"There is no selected Track");
            }
        }
    }
}
