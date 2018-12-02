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
        /// <summary>
        /// Termék kiküldése a megrendelőhöz! Visszatérés: Termékek ára
        /// </summary>
        /// <param name="termekid"></param>
        /// <param name="darab"></param>
        /// <param name="megrendelo"></param>
        /// <returns>Visszaadja, hogy mennyi a bevétel!</returns>
        public static int TermekKikuld(int termekid, byte darab, string megrendelo)
        {
            using (firepenguinEntities1 db = new firepenguinEntities1())
            {
                Termék kikuldtermek = db.Termék.FirstOrDefault(p => p.id == termekid);
                if (darab <= kikuldtermek.Raktáron)
                    kikuldtermek.Raktáron -= darab;
                else MessageBox.Show("Nincs ennyi termék raktáron! Raktáron van " + kikuldtermek.Raktáron+ "db");
                db.SaveChanges();
                return darab*kikuldtermek.Ár;
            }
            
        }
        /// <summary>
        /// Termékeket lehet megrendelni a raktárba! Feltétele, hogy szerepljen a termékek táblába! Visszatérés: Termékek ára
        /// </summary>
        /// <param name="termekid"></param>
        /// <param name="darab"></param>
        /// <param name="beszallito"></param>
        public static int TermekMegrendel(int termekid, byte darab, string beszallito)
        {
            using (firepenguinEntities1 db = new firepenguinEntities1())
            {
                Termék megrendeltermek = db.Termék.FirstOrDefault(p => p.id == termekid);
                megrendeltermek.Raktáron += darab;
                db.SaveChanges();
                return darab;
            }
        }
            
    }
}
