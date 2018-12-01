using System;
using System.Collections.Generic;
using System.Data.Entity.Core;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Raktar.Services
{
    public static class CRegister
    {
        public static int Register(string felhasznalonev, string jelszo)
        {
            int felid;
            try
            {
                using (firepenguinEntities1 db = new firepenguinEntities1())
                {
                    Login ujfelhasznalo = new Login();

                    ujfelhasznalo.felhasznalonev = felhasznalonev;
                    ujfelhasznalo.jelszo = jelszo;
                    ujfelhasznalo.admin = 0;
                    db.Logins.Add(ujfelhasznalo);
                    db.SaveChanges();
                    felid = ujfelhasznalo.id;

                }
                MessageBox.Show("Felhasználó sikeresen regisztrálca.");
                return felid;
            }
            catch (EntityCommandExecutionException ex)
            {
                MessageBox.Show("Hiba a szerver kapcsolatban.");
                Logger.Logging.LogExToTxt(ex);
            }
            catch (EntityException ex)
            {
                MessageBox.Show("Hiba a szerver kapcsolatban.");
                Logger.Logging.LogExToTxt(ex);
            }
            catch (DbUpdateException ex)
            {
                MessageBox.Show("Hibás beviteli érték.");
                Logger.Logging.LogExToTxt(ex);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hiba");
                Logger.Logging.LogExToTxt(ex);
            }
            return -1;

        }

        public static bool Admine(int id)
        {
            try
            {
                using (firepenguinEntities1 db = new firepenguinEntities1())
                {
                    Login ellenorzottfelhasznalo = db.Logins.FirstOrDefault(u => u.id == id);
                    if (ellenorzottfelhasznalo.admin == 1)
                        return true;
                    
                }
            }
            catch (EntityCommandExecutionException ex)
            {
                MessageBox.Show("Hiba a szerver kapcsolatban.");
                Logger.Logging.LogExToTxt(ex);
            }
            catch(Exception ex)
            {
                MessageBox.Show("Ismeretlen hiba történt");
                Logger.Logging.LogExToTxt(ex);
            }
            return false;
        }

        public static void JelszoValtoztat(int id, string jelszo)
        {
            try
            {
                using (firepenguinEntities1 db = new firepenguinEntities1())
                {
                    Login jelszocsere = db.Logins.FirstOrDefault(u => u.id == id);
                    jelszocsere.jelszo = jelszo;
                    db.SaveChanges();
                }
                MessageBox.Show("Jelszó megváltoztatása sikeres!");
            }
            catch (EntityCommandExecutionException ex)
            {
                MessageBox.Show("Hiba a szerver kapcsolatban.");
                Logger.Logging.LogExToTxt(ex);
            }
            catch (EntityException ex)
            {
                MessageBox.Show("Hiba a szerver kapcsolatban.");
                Logger.Logging.LogExToTxt(ex);
            }
            catch (DbUpdateException ex)
            {
                MessageBox.Show("Hibás beviteli érték.");
                Logger.Logging.LogExToTxt(ex);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hiba");
                Logger.Logging.LogExToTxt(ex);
            }
        }
    }
}
