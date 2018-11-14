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
    /// Interaction logic for fomenu.xaml
    /// </summary>
    public partial class fomenu : Page
    {
        public fomenu()
        {
            InitializeComponent();
        }

        MainWindow mainWin = Application.Current.Windows
        .Cast<Window>()
        .FirstOrDefault(window => window is MainWindow) as MainWindow;

        private void btn_click_dolgozok(object sender, RoutedEventArgs e)
        {
            Dolgozok dolgozok = new Dolgozok();
            mainWin.Content = dolgozok;
        }

        private void btn_click_raktarak(object sender, RoutedEventArgs e)
        {
            Raktarak raktarak = new Raktarak();
            mainWin.Content = raktarak;
        }

        private void btn_click_termek(object sender, RoutedEventArgs e)
        {
            Termekek termekek = new Termekek();
            mainWin.Content = termekek;
        }
    }
}
