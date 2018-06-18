using ScriptPortal.Vegas;
using VSG.ViewModel;
using VSG.ViewModel.ElementSteps;
using VSG.ViewModel.Enums;

namespace VSG.Core.Services
{
    public static class MoveElementService
    {
        public static void MoveElement(ElementStep elementStep)
        {
            if(!elementStep.Selector.IsValid() || elementStep.Selector.ElementType == ElementType.None || elementStep.Selector.ElementType == ElementType.Track)
            {
                return;
            }
            TrackEvent eventToMove = SelectorService.GetEvent(elementStep.Selector);
            Timecode timecode = Timecode.FromString(elementStep.DataPropertyList[DataPropertyHolder.TIMECODE].Value);
            eventToMove.Start = timecode;
        }
    }
}
