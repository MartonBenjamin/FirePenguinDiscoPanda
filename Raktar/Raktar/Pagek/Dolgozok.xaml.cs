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
        public Dolgozok()
        {
            InitializeComponent();
        }

        private void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Window1 fomenu = new Window1();
            this.Content = fomenu;
        }
    }
}
