using Raktar.Pagek;
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

namespace Raktar
{
    /// <summary>
    /// Interaction logic for Raktarak.xaml
    /// </summary>
    public partial class Raktarak : Page
    {
        public Raktarak()
        {
            InitializeComponent();
        }

        MainWindow mainWin = Application.Current.Windows
        .Cast<Window>()
        .FirstOrDefault(window => window is MainWindow) as MainWindow;

        private void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            fomenu main = new fomenu();
            mainWin.Content = main;
        }
    }
}
