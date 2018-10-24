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
        }
        

        private void btnlogin_Click(object sender, RoutedEventArgs e)
        {
            lblloginfo.Visibility = Visibility.Hidden;
            using (firepenguinEntities1 db = new firepenguinEntities1())
            {


                var user = db.Logins.FirstOrDefault(u => u.felhasznalonev == tblogin.Text);
                int maxId = db.Logins.Select(p => p.id).Max();
                //user.felhasznalonev = "admin";
                //user.jelszo = "admin";
                //user.id = maxId + 1;
                //db.Loginadatok.Add(user);
                //db.SaveChanges();
                if (user != null)
                {
                    
                    if (user.jelszo == pswbox.Password)
                    {
                        lblloginfo.Visibility = Visibility.Visible;
                        lblloginfo.Content = "Sikeres bejelentkezés!";
                        lblloginfo.Foreground = Brushes.Green;
                        Bejelentkezes();
                    }
                    else
                    {
                        lblloginfo.Visibility = Visibility.Visible;
                        lblloginfo.Content =  pswbox.Password + user.jelszo + ".";
                        //lblloginfo.Content = "Hibás felhasználónév vagy jelszó!";
                        lblloginfo.Foreground = Brushes.Red;

                    }

                }
                
            }
            
        }
        private void Bejelentkezes()
        {
            
        }
    }
}
