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
using VSG.App.ViewModel;
using VSG.Translator;

namespace VSG.App
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private EffectService EffectService;

        public MainWindow()
        {
            EffectService = new EffectService();
            InitializeComponent();
            Mapper.Initialize(cfg=> { });
            var maped = Mapper.Map<EffectTreeViewModel>(EffectService.GetEffectList());
            effectTree.Items.Add(maped);
        }

        private void ComboBox_Loaded(object sender, RoutedEventArgs e)
        {
            //var ss  = new MainViewModel()
            //{
            //    EffectTypeList = new ObservableCollection<EffectViewModel>(EffectService.GetEffectList().Select(x => new EffectViewModel { Name = x }))
            //};
        }
    }
}
