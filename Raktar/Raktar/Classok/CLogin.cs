using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raktar
{
    class CLogin
    {
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

                        lblloginfo.Content = "Hibás jelszó!";
                        lblloginfo.Foreground = Brushes.Red;


                    }

                }
                else
                {
                    lblloginfo.Visibility = Visibility.Visible;

                    lblloginfo.Content = "Hibás felhasználónév!";
                    lblloginfo.Foreground = Brushes.Red;


                }

            }
            
        }
        private void Bejelentkezes()
{
    Window1 win1 = new Window1();
    win1.Show();
    this.Close();
    //Fomenu!!
}

    }
}
