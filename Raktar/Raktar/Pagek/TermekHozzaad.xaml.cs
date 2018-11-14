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

namespace Raktar.Pagek
{
    /// <summary>
    /// Interaction logic for TermekHozzaad.xaml
    /// </summary>
    public partial class TermekHozzaad : Page
    {
        public TermekHozzaad()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            CTermekkezeles.TermekHozaad(int.Parse(suly.Text),int.Parse(Raktar_id.Text),megnevezes.Text,byte.Parse(raktaron.Text),Convert.ToDateTime(szavatossag.Text));
        }
        MainWindow mainWin = Application.Current.Windows
       .Cast<Window>()
       .FirstOrDefault(window => window is MainWindow) as MainWindow;

        private void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Termekek main = new Termekek();
            mainWin.Content = main;
        }

        

        private void megnevezes_GotFocus(object sender, RoutedEventArgs e)
        {
            megnevezes.Text = "";
        }

        
    }
}
