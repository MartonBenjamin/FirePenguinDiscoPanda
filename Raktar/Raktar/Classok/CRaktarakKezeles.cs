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

        static List<CRaktarakKezeles> termek = new List<CRaktarakKezeles>();

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
        public override string ToString()
        {
            return Id + " " + Raktarnev + " " + Iranyitoszam + " " + Raktarcim + " " + Kapacitas + " " + Ures + " ";
        }
        public static void RaktarHozzaAd()
        {

        }
    }
}
