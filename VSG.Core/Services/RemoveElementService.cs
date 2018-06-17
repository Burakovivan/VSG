using ScriptPortal.Vegas;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VSG.Core.Services;
using VSG.ViewModel;
using VSG.ViewModel.ElementSteps;
using VSG.ViewModel.Enums;

namespace VSG.Core.Services
{
    public static class RemoveElementService
    {
        public static void RemoveElement(ElementStep elementStep)
        {
            if(!elementStep.Selector.IsValid() || elementStep.Selector.ElementType == ElementType.None)
            {
                return;
            }

            if(elementStep.Selector.ElementType == ElementType.Event)
            {
                var eventToRemove = MainContainer.Vegas.Project.Tracks.SelectMany(x => x.Events).FirstOrDefault(x => x.IsAudio() == elementStep.Selector.IsAudio() && x.ActiveTake.Name == elementStep.Selector.Name);
                if(eventToRemove != null)
                {
                    eventToRemove.Track.Events.Remove(eventToRemove);
                }
            }
            if(elementStep.Selector.ElementType == ElementType.Track)
            {
                var track = new Selectors.TrackSelector().GetTrackByName(elementStep.Selector.Name);
                MainContainer.Vegas.Project.Tracks.Remove(track);
            }
        }
    }
}
