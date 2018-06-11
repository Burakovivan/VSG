using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using VSG.ViewModel.ActionHandlers;
using VSG.ViewModel.ElementSteps;

namespace VSG.App.ActionHandlers
{
    public class AddTrackActionStepHandler : ActionStepHandler
    {
        public AddTrackActionStepHandler()
        {
            ElementStep = new AddStep();
        }
        private TextBox tb;
        public override void HandleAction(Grid container, RoutedEventHandler applyClickHandler)
        {
            container.RowDefinitions.Clear();
            container.ColumnDefinitions.Clear();
            container.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            container.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            container.RowDefinitions.Add(new RowDefinition { Height = new GridLength(36) });
            container.RowDefinitions.Add(new RowDefinition { Height = new GridLength(32) });
            container.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            var label = new Label
            {
                Margin = new Thickness(5),
                HorizontalAlignment = HorizontalAlignment.Stretch,
                Content = "Track name:"
            };
            tb = new TextBox
            {
                Margin = new Thickness(5),
                HorizontalAlignment = HorizontalAlignment.Stretch
            };
            var applyBtn = new Button
            {
                Content = "Apply",
            };

            applyBtn.Click += ApplyBtn_Click;
            applyBtn.Click += applyClickHandler;
            applyBtn.SetValue(Grid.RowProperty, 1);
            applyBtn.SetValue(Grid.ColumnProperty,1);
            label.SetValue(Grid.RowProperty, 0);
            label.SetValue(Grid.ColumnProperty, 0);
            tb.SetValue(Grid.RowProperty, 1);
            tb.SetValue(Grid.ColumnProperty, 0);
            container.Children.Add(tb);
            container.Children.Add(label);
            container.Children.Add(applyBtn);
        }

        private void ApplyBtn_Click(object sender, RoutedEventArgs e)
        {
            ElementStep.Data["trackName"] = tb.Text;
        }
    }
}
