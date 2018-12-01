using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Raktar.Services
{
    class Megrendelés
    {
        //Termékhez árat rendelni!
        public static int TermekKikuld(int termekid, byte darab, string megrendelo)
        {
            using (firepenguinEntities1 db = new firepenguinEntities1())
            {
                Termék kikuldtermek = db.Termék.FirstOrDefault(p => p.id == termekid);
                if (darab <= kikuldtermek.Raktáron)
                    kikuldtermek.Raktáron -= darab;
                else MessageBox.Show("Nincs ennyi termék raktáron! Raktáron van " + kikuldtermek.Raktáron+ "db");
                db.SaveChanges();
            }
            return 1;
        }
            
    }
}
