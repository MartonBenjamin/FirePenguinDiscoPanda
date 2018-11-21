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
            try
            {
                CTermekkezeles.TermekHozaad(int.Parse(suly.Text), int.Parse(Raktar_id.Text), megnevezes.Text, byte.Parse(raktaron.Text), Convert.ToDateTime(szavatossag.Text));
            }
            catch (FormatException ex)
            {
                MessageBox.Show("Hibás beviteli érték!");
                Logger.Logging.LogExToTxt(ex);
            }
            catch (OverflowException ex)
            {
                MessageBox.Show("Hiba:\nElméretezett érték található!");
                Logger.Logging.LogExToTxt(ex);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hiba");
                Logger.Logging.LogExToTxt(ex);
            }
        }
        
        MainWindow mainWin = Application.Current.Windows
       .Cast<Window>()
       .FirstOrDefault(window => window is MainWindow) as MainWindow;

        private void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                Termekek main = new Termekek();
                mainWin.Content = main;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hiba a szerver kapcsolatban.");
                Logger.Logging.LogExToTxt(ex);
            }            
        }

        

        private void megnevezes_GotFocus(object sender, RoutedEventArgs e)
        {
            megnevezes.Text = "";
        }
        private void suly_GotFocus(object sender, RoutedEventArgs e)
        {
            suly.Text = "";
        }
        private void raktar_id_GotFocus(object sender, RoutedEventArgs e)
        {
            Raktar_id.Text = "";
        }
        private void darabszam_GotFocus(object sender, RoutedEventArgs e)
        {
            raktaron.Text = "";
        }
        private void szavatossag_GotFocus(object sender, RoutedEventArgs e)
        {
            szavatossag.Text = "";
        }


    }
}
