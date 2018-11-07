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
        public CTermekek(int id, string megnevezes, int suly, byte raktaron, int raktar, DateTime beszallitva, DateTime Szavatossag)
        {
            this.Id = id; this.Megnevezés = megnevezes; this.Suly_gramm = suly; this.Raktáron = raktaron;
            this.Beszállítva = beszallitva; this.Szavatosság = Szavatosság;
        }
    }
    class CTermekkezeles
    {
        //Add,remove,modify Ha 0 van raktáron kiírja, hogy "nincs raktáron"
        static List<CTermekek> termekek = new List<CTermekek>(); 

       

        public static void termekTorol(int id)
        {
            using(firepenguinEntities1 db = new firepenguinEntities1())
            {
                Termék toroltermek = db.Termék.FirstOrDefault(p => p.id == id);
                db.Termék.Remove(toroltermek);
            }
        }
        public static List<CTermekek> termekListaVisszaAd()
        {
            int id; int suly; int raktar;
            string megnevezes; byte raktaron;
            DateTime beszallitva; DateTime szavatossag;
            using (firepenguinEntities1 db = new firepenguinEntities1())
            {
                var actid = db.Termék.Select(u => u.id).Min();
                var termek = db.Termék.FirstOrDefault(u => u.id == actid);
                while (actid <= db.Termék.Select(u => u.id).Max())
                {
                    id = termek.id;
                    suly = termek.Súly_gramm;
                    raktar = termek.Raktár;
                    megnevezes = termek.Megnevezés;
                    raktaron = termek.Raktáron;
                    beszallitva = termek.Beszállítva;
                    szavatossag = Convert.ToDateTime(termek.Szavatosság);

                    CTermekek lekerttermek = new CTermekek(id,megnevezes,suly,raktaron,raktar,beszallitva,szavatossag);
                    actid++;
                    termekek.Add(lekerttermek);
                }
                
            }
            return termekek;
        }



        public static void TermekModosit()
        {

        }

    }
}

