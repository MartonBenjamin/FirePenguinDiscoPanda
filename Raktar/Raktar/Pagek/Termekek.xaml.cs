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
            fomenu main = new fomenu();
            mainWin.Content = main;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            TermekHozzaad main = new TermekHozzaad();
            mainWin.Content = main;
        }
    }
}
