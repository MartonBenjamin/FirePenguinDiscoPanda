using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raktar
{
    class CTermekek
    {
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
        public byte Raktáron
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
        //public CTermekek(int id, string megnevezes, int suly, byte raktaron, int raktar, DateTime beszallitva, DateTime Szavatossag)
        //{
        //    this.Id = id; this.Megnevezés = megnevezes; this.Suly_gramm = suly; this.Raktáron = raktaron;
        //    this.Beszállítva = beszallitva; this.Szavatosság = Szavatosság;
        //}
    }
    class CTermekkezeles
    {
        //Add,remove,modify Ha 0 van raktáron kiírja, hogy "nincs raktáron"


       

        public static void termekTorol(int id)
        {
            using(firepenguinEntities1 db = new firepenguinEntities1())
            {
                Termék toroltermek = db.Termék.FirstOrDefault(p => p.id == id);
                db.Termék.Remove(toroltermek);
                db.SaveChanges();
            }
        }
        public static List<CTermekek> termekListaVisszaAd()
        {
            List<CTermekek> termekek = new List<CTermekek>();

            //int id; int suly; int raktar;
            //string megnevezes; byte raktaron;
            //DateTime beszallitva; DateTime szavatossag;
            using (firepenguinEntities1 db = new firepenguinEntities1())
            {

                foreach (var termek in db.Termék)
                {
                    termekek.Add(new CTermekek
                    {
                        Id = termek.id,
                        Suly_gramm = termek.Súly_gramm,
                        Raktár = termek.Raktár,
                        Megnevezés = termek.Megnevezés,
                        Raktáron = termek.Raktáron,
                        Beszállítva = Convert.ToDateTime(termek.Beszállítva),
                        Szavatosság = Convert.ToDateTime(termek.Szavatosság)
                    });
                }

                //    var actid = db.Termék.Select(u => u.id).First();
                //    int szamlalo = actid;
                //    var termek = db.Termék.FirstOrDefault(u => u.id == actid);

                //    while (szamlalo <= db.Termék.Select(u => u.id).Max())
                //    {

                //        termekek.Add(new CTermekek
                //        {
                //            Id = termek.id,
                //            Suly_gramm = termek.Súly_gramm,
                //            Raktár = termek.Raktár,
                //            Megnevezés = termek.Megnevezés,
                //            Raktáron = termek.Raktáron,
                //            Beszállítva = Convert.ToDateTime(termek.Beszállítva),
                //            Szavatosság = Convert.ToDateTime(termek.Szavatosság)
                //        });

                //        szamlalo++;
                //    }             
                //}
                return termekek;
            }
        }

        public static void TermekHozaad()
        {

        }

        public static void TermekModosit()
        {

        }

    }
}

