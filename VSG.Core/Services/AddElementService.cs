using ScriptPortal.Vegas;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
                Track track = SelectorService.GetTrack(elementStep.Selector);
                var trackRegEx = new Regex(elementStep.DataPropertyList[DataPropertyHolder.RESOURCE_NAME].Value);
                Media media = MainContainer.Vegas.Project.MediaPool.Cast<Media>().FirstOrDefault(x =>
                    trackRegEx.IsMatch(Path.GetFileName(x.FilePath)));
                if(elementStep.Selector.IsAudio() && media.Streams.Any(x => x.MediaType == MediaType.Audio))
                {
                    TrackEvent trackEvent = new AudioEvent(
                    Timecode.FromString(elementStep.DataPropertyList[DataPropertyHolder.TIMECODE].Value),
                    media.Length,
                    elementStep.DataPropertyList[DataPropertyHolder.RESOURCE_NAME].Value);
                    track.Events.Add(trackEvent);
                    trackEvent.AddTake(media.Streams[0], true, elementStep.DataPropertyList[DataPropertyHolder.RESOURCE_NAME].Value);
                }
                if(elementStep.Selector.IsVideo() && media.Streams.Any(x => x.MediaType == MediaType.Video))
                {
                    TrackEvent trackEvent = new VideoEvent(Timecode.FromString(elementStep.DataPropertyList[DataPropertyHolder.TIMECODE].Value),
                    media.Length,
                    elementStep.DataPropertyList[DataPropertyHolder.RESOURCE_NAME].Value);
                    if(media.Streams.Any(x => x.MediaType == MediaType.Audio))
                    {
                        elementStep.Selector.ElementMediaType = ElementMediaType.Audio;
                        AudioTrack syncAudioTrack = SelectorService.GetTrack(elementStep.Selector) as AudioTrack;
                        MediaStream audioStream = media.Streams.FirstOrDefault(x => x.MediaType == MediaType.Audio);
                        MediaStream videoStream = media.Streams.FirstOrDefault(x => x.MediaType == MediaType.Video);
                        var audioEvent = new AudioEvent(
                            Timecode.FromString(elementStep.DataPropertyList[DataPropertyHolder.TIMECODE].Value),
                            media.Length,
                            elementStep.DataPropertyList[DataPropertyHolder.RESOURCE_NAME].Value);
                        track.Events.Add(trackEvent);
                        trackEvent.AddTake(videoStream, true, elementStep.DataPropertyList[DataPropertyHolder.RESOURCE_NAME].Value);
                        syncAudioTrack.Events.Add(audioEvent);
                        audioEvent.AddTake(audioStream, true, elementStep.DataPropertyList[DataPropertyHolder.RESOURCE_NAME].Value);
                    }
                    else
                    {
                        track.Events.Add(trackEvent);
                        trackEvent.AddTake(media.Streams[0], true, elementStep.DataPropertyList[DataPropertyHolder.RESOURCE_NAME].Value);
                    }
                }

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
