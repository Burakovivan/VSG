using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VSG.App.ActionHandlers;
using VSG.ViewModel.ActionHandlers;
using VSG.ViewModel.Enums;
using VSG.ViewModel.ElementSteps;
using VSG.ViewModel;

namespace VSG.Translator.HandlerResolvers
{
    public static class HandlerResolve
    {
        
        public static ActionStepHandler GetActionStepHandler(ElementSelector selector, int actionType)
        {
            if(selector.ElementType == ElementType.Event)
            {
                var actionTypeEnum = (EventAction)actionType;

                if(actionTypeEnum == EventAction.Add)
                {
                    return null;
                }
                if(actionTypeEnum == EventAction.Move)
                {
                    return null;
                }
                if(actionTypeEnum == EventAction.Remove)
                {
                    return null;
                }
                if(actionTypeEnum == EventAction.SetEffect)
                {
                    return null;
                }

            }
            if(selector.ElementType == ElementType.Track)
            {
                var actionTypeEnum = (TrackAction)actionType;

                if(actionTypeEnum == TrackAction.Add)
                {
                    return new AddTrackActionStepHandler();
                }
                if(actionTypeEnum == TrackAction.Remove)
                {
                    return null;
                }
                if(actionTypeEnum == TrackAction.SetEffect)
                {
                    return null;
                }
            }
            return null;
        }
    }

}
