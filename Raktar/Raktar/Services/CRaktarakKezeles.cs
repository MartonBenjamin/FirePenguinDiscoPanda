using Raktar.Modell;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raktar
{
    class CRaktarakKezeles
    {
        //Raktár adatainak kilistázása, raktár eltávolítása, hozzáadása

        static List<RaktarModell> raktarak = new List<RaktarModell>();

        public static List<RaktarModell> RaktarListaVisszaad()
        {
            
            using (firepenguinEntities1 db = new firepenguinEntities1())
            {
                foreach (var raktár in db.Raktár)
                {
                    raktarak.Add(new RaktarModell
                    {
                        Id = raktár.id,
                        Raktarnev = raktár.Név,
                        Raktarcim = raktár.Cím

                    });
                }
            }

                return raktarak;
        }

        public static void RaktarHozzaAd(string raktarnev, string raktarcim)
        {
            using (firepenguinEntities1 db = new firepenguinEntities1())
            {
                Raktár ujraktar = new Raktár();
                int maxId = db.Raktár.Select(p => p.id).Max();
                ujraktar.Név = raktarnev;
                ujraktar.Cím = raktarcim;
                db.Raktár.Add(ujraktar);
                db.SaveChanges();

            }
        }
        public static void RaktarTorol(int id)
        {
            using (firepenguinEntities1 db = new firepenguinEntities1())
            {
                Raktár torolraktar = db.Raktár.FirstOrDefault(p => p.id == id);
                db.Raktár.Remove(torolraktar);
                db.SaveChanges();
            }
        }
    }
}
