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
using Raktar.Services;
using Raktar.Pagek;

namespace Raktar.Pagek
{
    /// <summary>
    /// Interaction logic for Jelszovaltoztatas.xaml
    /// </summary>
    public partial class Jelszovaltoztatas : Page
    {
        public Jelszovaltoztatas()
        {
            InitializeComponent();
        }

        private void Btnjelszocsere_Click(object sender, RoutedEventArgs e)
        {
            CRegister.JelszoValtoztat(fomenu.loggeduser.Loginid, tbjelszo.Password);
            backtomenu();
        }
    

        MainWindow mainWin = Application.Current.Windows
         .Cast<Window>()
         .FirstOrDefault(window => window is MainWindow) as MainWindow;

        private void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                fomenu main = new fomenu();
                mainWin.Content = main;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hiba a szerver kapcsolatban.");
                Logger.Logging.LogExToTxt(ex);
            }
        }
        private void backtomenu()
        {
            try
            {
                fomenu main = new fomenu();
                mainWin.Content = main;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hiba a szerver kapcsolatban.");
                Logger.Logging.LogExToTxt(ex);
            }
        }

        private void tbjelszomegegyszer_PasswordChanged(object sender, RoutedEventArgs e)
        {

            if (tbjelszo.Password != tbjelszomegegyszer.Password)
            {
                lblnemegyezojelszo.Foreground = Brushes.Red;
                lblnemegyezojelszo.Content = "A két jelszó nem egyezik meg!";
                btnjelszocsere.IsEnabled = false;
            }
            else if (tbjelszo.Password != null && tbjelszomegegyszer.Password != null)
            {
                lblnemegyezojelszo.Foreground = Brushes.Green;
                lblnemegyezojelszo.Content = "Megfelelő jelszó!";
                btnjelszocsere.IsEnabled = true;
            }

        }
    }
}
