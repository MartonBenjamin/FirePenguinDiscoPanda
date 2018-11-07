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
using System.Timers;
using System.Threading;

namespace Raktar
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //static string nev = "teszt";
        //static string jelszo = "123";
        
        public MainWindow()
        {
            InitializeComponent();
            //CDolgozokkezeles.Dolgozotorol(2);
            //termék page hozzáférés
            //Termekek win1 = new Termekek();
            //this.Content = win1;
        }


        private void btnlogin_Click(object sender, RoutedEventArgs e)
        {
            CLogin login = new CLogin();
            login.LoginTry();
            //Dolgozó hozzáadás tesztelés! Működik!
            //CDolgozokkezeles.DolgozokHozaad("Teszt", "Felhasználó", "1999.01.01", "9876543210", "192837465", "3300", "Drága Édesanya", 100000);
            
        }
    }
}
