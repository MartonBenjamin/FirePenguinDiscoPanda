using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raktar
{
    class CRaktarak
    {
        public int Id
        {
            get; set;
        }
        public string Raktarnev
        {
            get; set;
        }

        public string Raktarcim
        {
            get; set;
        }
    }
    class CRaktarakKezeles
    {
        //Raktár adatainak kilistázása, raktár eltávolítása, hozzáadása

        static List<CRaktarak> raktarak = new List<CRaktarak>();

        public static List<CRaktarak> RaktarListaVisszaad()
        {
            
            using (firepenguinEntities1 db = new firepenguinEntities1())
            {
                foreach (var raktár in db.Raktár)
                {
                    raktarak.Add(new CRaktarak
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
