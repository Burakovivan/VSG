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
    public static class AddElementService
    {
        public static void AddElement(ElementStep elementStep)
        {
            if(!elementStep.Selector.IsValid() || elementStep.Selector.ElementType == ElementType.None)
            {
                return;
            }

            if(elementStep.Selector.ElementType == ElementType.Event)
            {
                var track = SelectorService.GetTrack(new ViewModel.ElementSelector { SelectorType = SelectorType.BySelection });
                var media = MainContainer.Vegas.Project.MediaPool.Cast<Media>().FirstOrDefault(x => Path.GetFileName(x.FilePath) == elementStep.DataPropertyList[DataPropertyHolder.RESOURCE_NAME].Value);
                TrackEvent trackEvent = null;
                if(elementStep.Selector.IsAudio())
                {
                    trackEvent = new AudioEvent(
                    Timecode.FromString(elementStep.DataPropertyList[DataPropertyHolder.POSITION].Value),
                    media.Length,
                    elementStep.DataPropertyList[DataPropertyHolder.RESOURCE_NAME].Value);
                }
                if(elementStep.Selector.IsVideo())
                {
                    trackEvent = new VideoEvent(Timecode.FromString(elementStep.DataPropertyList[DataPropertyHolder.POSITION].Value),
                    media.Length,
                    elementStep.DataPropertyList[DataPropertyHolder.RESOURCE_NAME].Value);
                }
                if(trackEvent == null)
                {
                    return;
                }
                track.Events.Add(trackEvent);
                trackEvent.AddTake(media.Streams[0], true, elementStep.DataPropertyList[DataPropertyHolder.RESOURCE_NAME].Value);
            }
            if(elementStep.Selector.ElementType == ElementType.Track)
            {
                if(elementStep.Selector.IsAudio())
                {
                    MainContainer.Vegas.Project.AddAudioTrack().Name = elementStep.DataPropertyList[DataPropertyHolder.RESOURCE_NAME].Value;
                }
                if(elementStep.Selector.IsVideo())
                {
                    MainContainer.Vegas.Project.AddVideoTrack().Name = elementStep.DataPropertyList[DataPropertyHolder.RESOURCE_NAME].Value;
                }
            }
        }
    }
}
