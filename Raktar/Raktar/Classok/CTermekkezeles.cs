using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raktar
{
    class CTermekkezeles
    {
        //Add,remove,modify Ha 0 van raktáron kiírja, hogy "nincs raktáron"
        static List<CTermekkezeles> termek = new List<CTermekkezeles>();

        public int Id
        {
            get; set;
        }
        public string Megnevezés
        {
            get; set;
        }
        public int Suly_gramm
        {
            get; set;
        }
        public string Raktáron
        {
            get; set;
        }
        public int Raktár
        {
            get; set;
        }
        public DateTime Beszállítva
        {
            get; set;
        }
        public DateTime Szavatosság
        {
            get; set;
        }

        public override string ToString()
        {
            return Id + " " + Megnevezés + " " + Suly_gramm + " " + Raktáron + " " + Raktár + " " + Beszállítva + " " + Szavatosság;
        }

        public static List<CTermekkezeles> ListaVisszaAd()
        {
            return termek;
        }

        public static void termekTorol()
        {
            using(firepenguinEntities1 db = new firepenguinEntities1())
            {

            }
        }
        public static void termekListaFeltolt()
        {
            using (firepenguinEntities1 db = new firepenguinEntities1())
            {
                var termekid = db.Termék.Select(u => u.id).Min();

                while (termekid <= db.Termék.Select(u => u.id).Max())
                {
                    termek.Add(new CTermekkezeles() { Id = db.Termék.Select(a => a.id).FirstOrDefault() });
                    termek.Add(new CTermekkezeles() { Megnevezés = db.Termék.Select(a => a.Megnevezés).FirstOrDefault() });
                    termek.Add(new CTermekkezeles() { Suly_gramm = db.Termék.Select(a => a.Súly_gramm).FirstOrDefault() });
                    if (db.Termék.Select(a => a.Raktáron).FirstOrDefault() == 1)
                    {
                        termek.Add(new CTermekkezeles() { Raktáron = "Raktáron van" });
                    }
                    else
                    {
                        termek.Add(new CTermekkezeles() { Raktáron = "Nincs raktáron" });
                    }
                    termek.Add(new CTermekkezeles() { Raktár = db.Termék.Select(a => a.Raktár).FirstOrDefault() });
                    termek.Add(new CTermekkezeles() { Beszállítva = db.Termék.Select(a => a.Beszállítva).FirstOrDefault() });
                    termek.Add(new CTermekkezeles() { Szavatosság = (DateTime)db.Termék.Select(a => a.Szavatosság).FirstOrDefault() });
                    termekid++;
                }
            }
        }



        public static void RaktaronVanE()
        {
            if (termek == null)
            {
                Termekek termekek = new Termekek();
                termekek.nincsTermekLbl.Visibility = System.Windows.Visibility.Visible;
                termekek.nincsTermekLbl.Foreground = System.Windows.Media.Brushes.Red;
                termekek.Content = "A raktár üres!";
            }
        }

    }
}

