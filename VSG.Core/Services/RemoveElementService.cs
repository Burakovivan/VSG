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
                TrackEvent eventToRemove = SelectorService.GetEvent(elementStep.Selector);
                if(eventToRemove != null)
                {
                    eventToRemove.Track.Events.Remove(eventToRemove);
                }
            }
            if(elementStep.Selector.ElementType == ElementType.Track)
            {
                Track track = SelectorService.GetTrack(elementStep.Selector);
                track.Project.Tracks.Remove(track);
            }
        }
    }
}
