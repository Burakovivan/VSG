using AutoMapper;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using VSG.App.ViewModels;
using VSG.Translator;
using VSG.ViewModel.ActionHandlers;
using VSG.ViewModel.OptionsGetter;
using VSG.ViewModel.ElementSteps;
using VSG.ViewModel.Enums;
using VSG.ViewModel;
using System.Runtime.CompilerServices;
using System.ComponentModel;

namespace VSG.App
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string _currentSelecorDescription;

        public ActionStepHandler CurrentActionStepHandler { get; set; }
        public ObservableCollection<ElementStep> ElementStepList { get; set; }
        public ObservableCollection<ElementStepViewModel> ElementStepVMList { get; set; }
        public ElementSelector CurrentSelector { get; set; }
        public string CurrentSelecorDescription { get => _currentSelecorDescription; set { _currentSelecorDescription = value; SelectorDescriptionLabel.Content = _currentSelecorDescription; } }

     
        public MainWindow()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<ElementStep, ElementStepViewModel>()
                .ForMember(
                x => x.Data,
                opt => opt.MapFrom(z => z.DataPropertyList)
                    );
            });

            ElementStepList = new ObservableCollection<ElementStep>();
            ElementStepVMList = new ObservableCollection<ElementStepViewModel>();
            InitializeComponent();
            InitComboboxes();
            //var maped = EffectTreeViewModel.GetEffectTree();
            //effectTree.Items.Add(maped);
        }

        private void InitComboboxes()
        {

            ElementType.SelectedIndex = 0;
            MediaType.SelectedIndex = 0;
            SelectorType.SelectedIndex = 0;
            SetupComboboxWithOptions(SelectorType, OptionGetter.GetSelectorTypeOptionList());
            SetupComboboxWithOptions(MediaType, OptionGetter.GetElementMediaTypeOptionList());
            SetupComboboxWithOptions(ElementType, OptionGetter.GetElementTypeOptionList());
        }
        private void SetupComboboxWithOptions(ComboBox comboBox, IEnumerable<OptionGetterModel> options)
        {

            comboBox.ItemsSource = options;
            comboBox.DisplayMemberPath = "Description";
            comboBox.SelectedValuePath = "Value";
            comboBox.SelectedIndex = 0;
        }
        private void ElementType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            MediaType.IsEnabled = ElementType.SelectedIndex > 0;
            if(MediaType.IsEnabled)
            {
                SetupComboboxWithOptions(MediaType, OptionGetter.GetElementMediaTypeOptionList());
            }else{
                MediaType.SelectedIndex = 0;
            }
        }

        private void MediaType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SelectorType.IsEnabled = MediaType.SelectedIndex > 0;
            if(SelectorType.IsEnabled)
            {

                SetupComboboxWithOptions(SelectorType, OptionGetter.GetSelectorTypeOptionList());
            }
            else
            {
                SelectorType.SelectedIndex = 0;
            }
        }

        private void SelectorType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(SelectorType.SelectedIndex > 0)
            {
                CurrentSelector = new ElementSelector()
                {
                    ElementMediaType = (ElementMediaType)MediaType.SelectedValue,
                    ElementType = (ElementType)ElementType.SelectedValue,
                    SelectorType = (SelectorType)SelectorType.SelectedValue
                };
                ElementName.Visibility = CurrentSelector.SelectorType == ViewModel.Enums.SelectorType.ByName ? Visibility.Visible : Visibility.Hidden;
                CurrentSelecorDescription = $"{CurrentSelector.ElementMediaType}{CurrentSelector.ElementType} {CurrentSelector.SelectorType}";
                CurrentSelecorDescription += CurrentSelector.SelectorType == ViewModel.Enums.SelectorType.ByName ? $"\"{CurrentSelector.Name}\"":"";
            }
            else
            {
                CurrentSelector = null;
                CurrentSelecorDescription = "Selector not valid";
                ElementName.Visibility = Visibility.Hidden;
            }

            ActionTypeLabel.Visibility = CurrentSelector != null ? Visibility.Visible : Visibility.Hidden;
            ActionType.Visibility = CurrentSelector != null ? Visibility.Visible : Visibility.Hidden;
        }

        private void ApplyClick(object sender, RoutedEventArgs e)
        {
            ElementStepList.Add(CurrentActionStepHandler.ElementStep);
            ElementStepVMList.Add(Mapper.Map<ElementStepViewModel>(CurrentActionStepHandler.ElementStep));
            ElementType.SelectedIndex = 0;
        }



        private void ApplySelectorBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ReInitGrig(Grid grid)
        {
            ActionContent.RowDefinitions.Clear();
            ActionContent.ColumnDefinitions.Clear();
            ActionContent.Children.Clear();
        }

        private void ActionType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(ActionType.SelectedValue == null || ActionType.SelectedIndex == 0)
            {
                ReInitGrig(ActionContent);
                return;
            }
            CurrentSelector.Name = ElementName.Text;
            CurrentActionStepHandler = new ActionStepHandler(CurrentSelector, (int)ActionType.SelectedValue);
            CurrentActionStepHandler.HandleAction(ActionContent, ApplyClick);
        }

        private void ActionType_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if((bool)e.NewValue)
            {
                SetupComboboxWithOptions(ActionType, OptionGetter.GetActionOptionList(CurrentSelector.ElementType));
            }
            else
            {
                ReInitGrig(ActionContent);
            }
        }

        private void RenderButton_Click(object sender, RoutedEventArgs e)
        {
            Renderer.StartRender(ElementStepList.ToList());
        }


    }
}
