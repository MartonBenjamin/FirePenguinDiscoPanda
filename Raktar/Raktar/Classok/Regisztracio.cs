using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raktar.Classok
{
    class Regisztracio
    {

        private string vezeteknev, keresztnev, taj, irsz, anyjaneve;
        DateTime szulido;



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

    }

    class RegisztracioKezeles
    {
        static public int loggeduserid = 0;
        public static Regisztracio LoggedUserVisszaad()
        {
            Regisztracio loggeddolgozo = new Regisztracio();
            using (firepenguinEntities1 db = new firepenguinEntities1())
            {

                foreach (var felhasznalok in db.Felhasznaloks)
                {
                    if (felhasznalok.loginid == loggeduserid)
                    {
                        loggeddolgozo.Vezeteknev = felhasznalok.vezeteknev;
                        loggeddolgozo.Keresztnev = felhasznalok.keresztnev;
                        loggeddolgozo.Irsz = felhasznalok.irsz;
                        loggeddolgozo.Szulido = felhasznalok.szulido;
                        loggeddolgozo.Taj = felhasznalok.taj;
                        loggeddolgozo.Anyjaneve = felhasznalok.anyjaneve;
                    }
                }
            }
            return loggeddolgozo;
        }

        public static List<Regisztracio> RegisztraltakListaLeker()
        {
            List<Regisztracio> regisztraltak = new List<Regisztracio();
            using (firepenguinEntities1 db = new firepenguinEntities1())
            {

                foreach (var felhasznalok in db.Felhasznaloks)
                {
                    regisztraltak.Add(new Regisztracio
                    {
                        Vezeteknev = felhasznalok.vezeteknev,
                        Keresztnev = felhasznalok.keresztnev,
                        Irsz = felhasznalok.irsz,
                        Szulido = Convert.ToDateTime(felhasznalok.szulido),
                        Taj = felhasznalok.taj,
                        Anyjaneve = felhasznalok.anyjaneve,
                    });
                }
                return regisztraltak;
            }
        }


    }
}

