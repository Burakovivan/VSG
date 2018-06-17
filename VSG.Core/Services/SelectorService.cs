using ScriptPortal.Vegas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VSG.ViewModel;
using VSG.ViewModel.Enums;

namespace VSG.Core.Services
{
    public static class SelectorService
    {
        public static Track GetTrack(ElementSelector elementSelector)
        {

            if(elementSelector.SelectorType == SelectorType.None)
            {
                return null;
            }
            if(elementSelector.SelectorType == SelectorType.ByName)
            {
                string trackName = (string)elementSelector.Name;
                return MainContainer.Vegas.Project.Tracks.FirstOrDefault(x => x.Name == trackName && x.IsAudio() == elementSelector.IsAudio());
            }
            if(elementSelector.SelectorType == SelectorType.BySelection)
            {
                return MainContainer.Vegas.Project.Tracks.FirstOrDefault(x => x.Selected && x.IsAudio() == elementSelector.IsAudio());
            }
            return null;
        }
        public static TrackEvent GetEvent(ElementSelector elementSelector)
        {
            if(elementSelector.SelectorType == SelectorType.None)
            {
                return null;
            }
            if(elementSelector.SelectorType == SelectorType.ByName)
            {
                string trackName = (string)elementSelector.Name;
                return MainContainer.Vegas.Project.Tracks.SelectMany(x => x.Events).FirstOrDefault(x => x.Name == trackName && x.IsAudio() == elementSelector.IsAudio());
            }
            if(elementSelector.SelectorType == SelectorType.BySelection)
            {
                string trackName = (string)elementSelector.Name;
                return MainContainer.Vegas.Project.Tracks.SelectMany(x => x.Events).FirstOrDefault(x => x.Selected && x.IsAudio() == elementSelector.IsAudio());
            }
            return null;
        }
    }
}
