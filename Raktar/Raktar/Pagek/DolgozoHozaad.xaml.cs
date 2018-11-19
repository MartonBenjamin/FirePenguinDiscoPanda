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
    /// Interaction logic for DolgozoHozaad.xaml
    /// </summary>
    public partial class DolgozoHozaad : Page
    {  
        public DolgozoHozaad()
        {
            InitializeComponent();
        }

        private void btnDolgozoHozaad_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                CDolgozokkezeles.DolgozokHozaad(tbvezeteknev.Text, tbkeresztnev.Text, tbszulido.Text,
                    tbadoazon.Text, tbtaj.Text, tbirsz.Text, tbanyjaneve.Text, Convert.ToInt32(tbfizetes.Text));
            }
            catch (Exception ex)
            {
                //Logger.Logging.LogExToTxt(ex);
            }
        }

        MainWindow mainWin = Application.Current.Windows
        .Cast<Window>()
        .FirstOrDefault(window => window is MainWindow) as MainWindow;

        private void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Dolgozok dolgozok = new Dolgozok();
            mainWin.Content = dolgozok;
        }
        private void vezeteknev_GotFocus(object sender, RoutedEventArgs e)
        {
            tbvezeteknev.Text = "";
        }
        private void keresztnev_GotFocus(object sender, RoutedEventArgs e)
        {
            tbkeresztnev.Text = "";
        }
        private void szulido_GotFocus(object sender, RoutedEventArgs e)
        {
            tbszulido.Text = "";
        }
        private void adoazon_GotFocus(object sender, RoutedEventArgs e)
        {
            tbadoazon.Text = "";
        }
        private void taj_GotFocus(object sender, RoutedEventArgs e)
        {
            tbtaj.Text = "";
        }
        private void fizetes_GotFocus(object sender, RoutedEventArgs e)
        {
            tbfizetes.Text = "";
        }
        private void irsz_GotFocus(object sender, RoutedEventArgs e)
        {
            tbirsz.Text = "";
        }
        private void anyjaneve_GotFocus(object sender, RoutedEventArgs e)
        {
            tbanyjaneve.Text = "";
        }
    }
}
