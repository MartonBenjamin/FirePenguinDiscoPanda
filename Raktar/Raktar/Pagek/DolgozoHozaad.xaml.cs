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
            CDolgozokkezeles.DolgozokHozaad(tbvezeteknev.Text, tbkeresztnev.Text, tbszulido.Text,
                tbadoazon.Text, tbtaj.Text, tbirsz.Text, tbanyjaneve.Text, Convert.ToUInt32(tbfizetes.Text));
        }

        private void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Dolgozok dolgozok = new Dolgozok();
            this.Content = dolgozok;

        }
    }
}
