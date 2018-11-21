using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raktar.Modell
{
    class TermekModell
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
    }
}
