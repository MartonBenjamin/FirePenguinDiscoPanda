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
using System.Windows.Shapes;

namespace Raktar
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        static List<CDolgozok> dolgozok = CDolgozokkezeles.DolgozokListaLeker();
        public Window1()
        {
            InitializeComponent();
            
        }

        private void btn_click_dolgozok(object sender, RoutedEventArgs e)
        {
            Dolgozok dolgozok = new Dolgozok();
            this.Content = dolgozok;


        }

        private void btn_click_raktarak(object sender, RoutedEventArgs e)
        {
            Raktarak raktarak = new Raktarak();
            this.Content = raktarak;
        }

        private void btn_click_termekek(object sender, RoutedEventArgs e)
        {
            Termekek termekek = new Termekek();
            this.Content = termekek;
        }
    }
}
