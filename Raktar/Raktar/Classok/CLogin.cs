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
using Raktar.Pagek;

namespace Raktar
{

    class CLogin
    {
        MainWindow mainWin = Application.Current.Windows
       .Cast<Window>()
       .FirstOrDefault(window => window is MainWindow) as MainWindow;

        private void ValidLogin()
        {
            Application.Current.Dispatcher.Invoke((Action)delegate
            {
                fomenu win1 = new fomenu();
               
                mainWin.Content = win1;
                
            });
        }

        public void LoginTry()
        {
            using (firepenguinEntities1 db = new firepenguinEntities1())
            {
                var user = db.Logins.FirstOrDefault(u => u.felhasznalonev == mainWin.tblogin.Text);
                int maxId = db.Logins.Select(p => p.id).Max();
                if (user != null)
                {

                    if (user.jelszo == mainWin.pswbox.Password)
                    {
                        
                        mainWin.lblloginfo.Visibility = Visibility.Visible;
                        mainWin.lblloginfo.Content = "Sikeres bejelentkezés!";
                        mainWin.lblloginfo.Foreground = Brushes.Green;

                        Task.Delay(750).ContinueWith(t => ValidLogin());

                    }
                    else
                    {
                        mainWin.lblloginfo.Visibility = Visibility.Visible;
                        mainWin.lblloginfo.Content = "Hibás jelszó!";
                        mainWin.lblloginfo.Foreground = Brushes.Red;
                    }

                }
                else
                {
                    mainWin.lblloginfo.Visibility = Visibility.Visible;
                    mainWin.lblloginfo.Content = "Hibás felhasználónév!";
                    mainWin.lblloginfo.Foreground = Brushes.Red;
                }

            }

        }



    }

}
