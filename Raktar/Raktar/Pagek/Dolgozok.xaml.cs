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
    /// Interaction logic for Dolgozok.xaml
    /// </summary>
    public partial class Dolgozok : Page
    {
        private void GridFill()
        {
             dtgDolgozok.ItemsSource = CDolgozokkezeles.DolgozokListaLeker();
        }

        public Dolgozok()
        {
            InitializeComponent();
            GridFill();
        }

        MainWindow mainWin = Application.Current.Windows
        .Cast<Window>()
        .FirstOrDefault(window => window is MainWindow) as MainWindow;

        private void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            fomenu main = new fomenu();
            mainWin.Content = main;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {       
            DolgozoHozaad dolgozoHozaad = new DolgozoHozaad();
            mainWin.Content = dolgozoHozaad;
        }

        private void btndolgozotorol_Click(object sender, RoutedEventArgs e)
        {
            CDolgozokkezeles.Dolgozotorol(Convert.ToInt32(tbdolgozoindex.Text));
            GridFill();
        }

    }
}
