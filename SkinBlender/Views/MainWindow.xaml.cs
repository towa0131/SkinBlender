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
using System.Windows.Navigation;
using System.Windows.Shapes;
using SkinBlender.ViewModels;

namespace SkinBlender
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new MainWindowViewModel();
        }

        private void DropView_Drop(object sender, DragEventArgs e)
        {
            // TODO: とりあえず...
            var control = sender as UserControl;
            var vm = this.DataContext as MainWindowViewModel;

            if (e.Data.GetDataPresent(DataFormats.FileDrop, true))
            {
                var paths = e.Data.GetData(DataFormats.FileDrop) as string[];

                if (paths == null || paths.Length != 1)
                {
                    return;
                }

                if (control.Name == "HeadDrop")
                {
                    vm.HeadSkinPath = paths[0];
                }
                else if (control.Name == "BodyDrop")
                {
                    vm.BodySkinPath = paths[0];
                }
            }
        }
    }
}
