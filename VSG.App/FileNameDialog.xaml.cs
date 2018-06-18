using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace VSG.App
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class FileNameDialog : Window
    {
        public string folderPath;
        public FileNameDialog()
        {
            InitializeComponent();
        }

        private void ContinueButton_Click(object sender, RoutedEventArgs e)
        {
            
            Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            using(var dialog = new System.Windows.Forms.FolderBrowserDialog())
            {
                System.Windows.Forms.DialogResult result = dialog.ShowDialog();
                folderPath = dialog.SelectedPath;
                FolderName.Text = folderPath;
            }
        }
    }
}
