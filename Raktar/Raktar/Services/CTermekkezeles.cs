using Raktar.Modell;
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


       

        public static void termekTorol(int id)
        {
            using(firepenguinEntities1 db = new firepenguinEntities1())
            {
                Termék toroltermek = db.Termék.FirstOrDefault(p => p.id == id);
                db.Termék.Remove(toroltermek);
                db.SaveChanges();
                
            }
        }
        public static List<TermekModell> termekListaVisszaAd()
        {
            List<TermekModell> termekek = new List<TermekModell>();

            //int id; int suly; int raktar;
            //string megnevezes; byte raktaron;
            //DateTime beszallitva; DateTime szavatossag;
            using (firepenguinEntities1 db = new firepenguinEntities1())
            {

                foreach (var termek in db.Termék)
                {
                    termekek.Add(new TermekModell
                    {
                        Id = termek.id,
                        Suly_gramm = termek.Súly_gramm_,
                        Raktár = termek.Raktár,
                        Megnevezés = termek.Megnevezés,
                        Raktáron = termek.Raktáron,
                        Beszállítva = Convert.ToDateTime(termek.Beszállítva),
                        Szavatosság = Convert.ToDateTime(termek.Szavatosság)
                    });
                }
                return termekek;
            }
        }

        public static void TermekHozaad(int suly, int raktar, string megnevezes, byte raktaron, DateTime szavatossag)
        {
            using (firepenguinEntities1 db = new firepenguinEntities1())
            {
                Termék ujtermek = new Termék();
                int maxId = db.Termék.Select(p => p.id).Max();
                ujtermek.id = maxId + 1;
                ujtermek.Megnevezés = megnevezes;
                ujtermek.Súly_gramm_ = suly;
                ujtermek.Raktár = raktar;
                ujtermek.Raktáron = raktaron;
                ujtermek.Beszállítva = DateTime.Now;
                ujtermek.Szavatosság = szavatossag;
                db.Termék.Add(ujtermek);
                
                db.SaveChanges();
            }
        }

       
            
        }

    }


