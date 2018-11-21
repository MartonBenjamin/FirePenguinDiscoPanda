using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raktar.Modell
{
    public class DolgozoModell
    {
        private int id, fizetes, loginid;
        private string vezeteknev, keresztnev, adoazon, taj, irsz, anyjaneve;
        DateTime szulido;



        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Vezeteknev
        {
            get { return vezeteknev; }
            set { vezeteknev = value; }
        }
        public string Keresztnev
        {
            get { return keresztnev; }
            set { keresztnev = value; }
        }
        public DateTime Szulido
        {
            get { return szulido; }
            set { szulido = value; }
        }
        public string Adoazon
        {
            get { return adoazon; }
            set { adoazon = value; }
        }
        public string Taj
        {
            get { return taj; }
            set { taj = value; }
        }
        public string Irsz
        {
            get { return irsz; }
            set { irsz = value; }
        }
        public string Anyjaneve
        {
            get { return anyjaneve; }
            set { anyjaneve = value; }
        }

        public int Fizetes
        {
            get { return fizetes; }
            set { fizetes = value; }
        }

        public int Loginid
        {
            get { return loginid; }
            set { loginid = value; }
        }
    }
}
