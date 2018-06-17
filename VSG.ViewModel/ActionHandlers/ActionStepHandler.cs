using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using VSG.ViewModel.ElementSteps;
using VSG.ViewModel.Enums;

namespace VSG.ViewModel.ActionHandlers
{
    public class ActionStepHandler
    {
        public ElementStep ElementStep { get; set; }
        private Dictionary<string, TextBox> TextBoxDict { get; set; }
        private ActionStepHandler() { }
       
        public ActionStepHandler(ElementSelector elementSelector, int actionType)
        {
            TextBoxDict = new Dictionary<string, TextBox>();

            if(actionType == (int)EventAction.Add)
            {
                ElementStep = new AddStep(elementSelector);
            }
            if(actionType == (int)EventAction.Remove)
            {
                ElementStep = new RemoveStep(elementSelector);
            }
            if(actionType == (int)EventAction.SetEffect)
            {
                ElementStep = new SetEffectStep { Selector = elementSelector };
            }
            if(actionType == (int)EventAction.Move)
            {
                ElementStep = new MoveStep { Selector = elementSelector };
            }

        }


        public void HandleAction(Grid container, RoutedEventHandler applyClickHandler)
        {
            container.RowDefinitions.Clear();
            container.ColumnDefinitions.Clear();
            container.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            container.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });

            int i = 0;
            container.Children.Clear();
            if(ElementStep.DataPropertyList != null)
            {
                foreach(var element in ElementStep.DataPropertyList)
                {
                    container.RowDefinitions.Add(new RowDefinition { Height = new GridLength(36) });
                    var label = new Label
                    {
                        Margin = new Thickness(5),
                        HorizontalAlignment = HorizontalAlignment.Stretch,
                        Content = element.Value.DisplayName
                    };
                    label.SetValue(Grid.RowProperty, i);
                    label.SetValue(Grid.ColumnProperty, 0);

                    var textBox = new TextBox
                    {
                        Margin = new Thickness(5),
                        HorizontalAlignment = HorizontalAlignment.Stretch
                    };
                    textBox.SetValue(Grid.RowProperty, i);
                    textBox.SetValue(Grid.ColumnProperty, 1);

                    TextBoxDict[element.Key] = textBox;
                    container.Children.Add(label);
                    container.Children.Add(textBox);
                    i++;
                }
            }

            container.RowDefinitions.Add(new RowDefinition { Height = new GridLength(32) });

            var applyBtn = new Button
            {
                Content = "Apply",
            };
            applyBtn.Click += ApplyBtn_Click;
            applyBtn.Click += applyClickHandler;
            applyBtn.SetValue(Grid.RowProperty, i + 1);
            applyBtn.SetValue(Grid.ColumnProperty, 1);
            container.Children.Add(applyBtn);

        }
        private void ApplyBtn_Click(object sender, RoutedEventArgs e)
        {
            foreach(var element in TextBoxDict)
            {
                ElementStep.DataPropertyList[element.Key].Value = element.Value?.Text;
            }
        }

        public ActionStepHandler Clone()
        {
            var newObj = new ActionStepHandler()
            {
                ElementStep = new ElementStep
                {
                    Selector = new ElementSelector
                    {
                        ElementMediaType = this.ElementStep.Selector.ElementMediaType,
                        ElementType = this.ElementStep.Selector.ElementType,
                        Name = this.ElementStep.Selector.Name,
                        SelectorType = this.ElementStep.Selector.SelectorType
                    }
                },
                TextBoxDict = TextBoxDict
            };
            if(ElementStep.DataPropertyList != null)
            {

                newObj.ElementStep.DataPropertyList = new Dictionary<string, DataProperty>();
                foreach(KeyValuePair<string, DataProperty> e in ElementStep.DataPropertyList)
                {
                    newObj.ElementStep.DataPropertyList.Add(e.Key, e.Value);
                }
            }

            return newObj;
        }
    }
}
