﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Timers;
using System.Threading;

namespace Raktar
{
    class CDolgozok
    {
        int id, fizetes;
        string vezeteknev, keresztnev, adoazon, taj, irsz, anyjaneve;
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
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public int Fizetes
        {
            get { return fizetes; }
            set { fizetes = value; }
        }
        

    }
    class CDolgozokkezeles
    {
        static public List<CDolgozok> dolgozok = new List<CDolgozok>();

        public static List<CDolgozok> DolgozokListaLeker()
        {
            using (firepenguinEntities1 db = new firepenguinEntities1())
            {

                foreach (var felhasznalok in db.Felhasznaloks)
                {
                    dolgozok.Add(new CDolgozok
                    {
                        Id = felhasznalok.id,
                        Vezeteknev = felhasznalok.vezeteknev,
                        Keresztnev = felhasznalok.keresztnev,
                        Irsz = felhasznalok.irsz,
                        Szulido = Convert.ToDateTime(felhasznalok.szulido),
                        Adoazon = felhasznalok.adoazon,
                        Taj = felhasznalok.taj,
                        Anyjaneve = felhasznalok.anyjaneve

                    });
                }
                return dolgozok;
            }
        }

            //HOZZÁADNI, CSAK FŐNÖK TUDJA MAJD!!
            public static void DolgozokHozaad(string vezeteknev, string keresztnev, string szulido, string adoazon, string taj, string irsz, string anyjaneve, uint fizetes)
            {
                using (firepenguinEntities1 db = new firepenguinEntities1())
                {
                    Felhasznalok ujdolgozo = new Felhasznalok();
                
                    int maxId = db.Felhasznaloks.Select(p => p.id).Max();
                    ujdolgozo.id = maxId + 1;
                    ujdolgozo.vezeteknev = vezeteknev;
                    ujdolgozo.keresztnev = keresztnev;
                    ujdolgozo.szulido = Convert.ToDateTime(szulido);
                    ujdolgozo.adoazon = adoazon;
                    ujdolgozo.taj = taj;
                    ujdolgozo.irsz = irsz;
                    ujdolgozo.anyjaneve = anyjaneve;
                    ujdolgozo.fizetes = fizetes;

                    db.Felhasznaloks.Add(ujdolgozo);
                    db.SaveChanges();
                }
            }
            public static void Dolgozotorol(uint id)
            {
                using (firepenguinEntities1 db = new firepenguinEntities1())
                {
                    Felhasznalok toroldolgozo = db.Felhasznaloks.FirstOrDefault(p => p.id == id);
                    db.Felhasznaloks.Remove(toroldolgozo);
                    db.SaveChanges();
                }
            }
        }
}
