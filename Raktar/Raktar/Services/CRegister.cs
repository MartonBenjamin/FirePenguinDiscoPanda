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
        public static void Register(string felhasznalonev, string jelszo)
        {
            try
            {
                using (firepenguinEntities1 db = new firepenguinEntities1())
            {
                Login ujfelhasznalo = new Login();

                ujfelhasznalo.felhasznalonev = felhasznalonev;
                ujfelhasznalo.jelszo = jelszo;
                ujfelhasznalo.id = db.Logins.Select(p => p.id).Max() + 1;
                db.Logins.Add(ujfelhasznalo);
                db.SaveChanges();
            }
            MessageBox.Show("Felhasználó sikeresen regisztrálca.");
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
