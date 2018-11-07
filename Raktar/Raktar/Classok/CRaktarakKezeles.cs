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
        public int Iranyitoszam
        {
            get; set;
        }
        public string Raktarcim
        {
            get; set;
        }
        public int Kapacitas
        {
            get; set;
        }

        public bool Ures
        { get; set; }
        public CRaktarak(int id, string raktarnev, string raktarcim)
        {
            this.Id = id; this.Raktarnev = raktarnev; this.Raktarcim = raktarcim;
            
        }
    }
    class CRaktarakKezeles
    {
        //Raktár adatainak kilistázása, raktár eltávolítása, hozzáadása

        static List<CRaktarak> raktarak = new List<CRaktarak>();

        static List<CRaktarak> RaktarListaVisszaad()
        {
            int id;
            string raktarnev; string raktarcim; 
            using (firepenguinEntities1 db = new firepenguinEntities1())
            {
                var actid = db.Raktár.Select(u => u.id).Min();
                var raktar = db.Raktár.FirstOrDefault(u => u.id == actid);
                while (actid <= db.Raktár.Select(u => u.id).Max())
                {
                    id = raktar.id;
                    raktarcim = raktar.Cím;
                    raktarnev = raktar.Név;
                    CRaktarak leraktar = new CRaktarak(id,raktarnev,raktarcim);
                    raktarak.Add(leraktar);

                    actid++;
                }
            }

                return raktarak;
        }

        public static void RaktarHozzaAd()
        {

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
