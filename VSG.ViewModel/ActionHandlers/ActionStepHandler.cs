using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using VSG.ViewModel.ElementSteps;

namespace VSG.ViewModel.ActionHandlers
{
    public abstract class ActionStepHandler
    {
        public ElementStep ElementStep { get; set; }
        public abstract void HandleAction(Grid container, RoutedEventHandler applyClickHandler);
    }
}
