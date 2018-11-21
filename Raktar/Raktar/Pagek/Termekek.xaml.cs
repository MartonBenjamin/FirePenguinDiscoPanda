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
    /// Interaction logic for Termekek.xaml
    /// </summary>
    public partial class Termekek : Page 
    {
        private void TablazatLetrehoz()
        {
            dataGridView1.ItemsSource = CTermekkezeles.termekListaVisszaAd();           
        }
        public Termekek()
        {
            InitializeComponent();

            TablazatLetrehoz();
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                TermekHozzaad main = new TermekHozzaad();
                mainWin.Content = main;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hiba a szerver kapcsolatban.");
                Logger.Logging.LogExToTxt(ex);
            }
        }

        private void btntermektorol_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                CTermekkezeles.termekTorol(Convert.ToInt32(tbtermekindex.Text));
                TablazatLetrehoz();
            }
            catch (Exception ex)
            {
                MessageBox.Show("A beírt érték hibás.");
                Logger.Logging.LogExToTxt(ex);
            }
        }

    }
}
