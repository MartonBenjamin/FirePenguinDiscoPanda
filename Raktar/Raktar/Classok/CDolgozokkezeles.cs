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
    public class CDolgozok
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
    public class CDolgozokkezeles
    {
        static public int loggeduserid = 0;
        public static CDolgozok LoggedUserVisszaad()
        {
            CDolgozok loggeddolgozo = new CDolgozok();
            using (firepenguinEntities1 db = new firepenguinEntities1())
            {

                foreach (var felhasznalok in db.Felhasznaloks)
                {
                    if (felhasznalok.loginid == loggeduserid)
                    {
                        loggeddolgozo.Id = felhasznalok.id;
                        loggeddolgozo.Vezeteknev = felhasznalok.vezeteknev;
                        loggeddolgozo.Keresztnev = felhasznalok.keresztnev;
                        loggeddolgozo.Irsz = felhasznalok.irsz;
                        loggeddolgozo.Szulido = felhasznalok.szulido;
                        loggeddolgozo.Adoazon = felhasznalok.adoazon;
                        loggeddolgozo.Taj = felhasznalok.taj;
                        loggeddolgozo.Anyjaneve = felhasznalok.anyjaneve;
                        loggeddolgozo.Fizetes = Convert.ToInt32(felhasznalok.fizetes);
                        loggeddolgozo.Loginid = loggeduserid;
                    }
                }
            }
                return loggeddolgozo;
        }

        public static List<CDolgozok> DolgozokListaLeker()
        {
            try
            {
                List<CDolgozok> dolgozok = new List<CDolgozok>();
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
                            Anyjaneve = felhasznalok.anyjaneve,
                            Fizetes = Convert.ToInt32(felhasznalok.fizetes),
                            Loginid = felhasznalok.loginid
                        });
                    }
                    return dolgozok;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("A dolgozók betöltése sikertelen!");
                return null;
            }
        }

        //HOZZÁADNI, CSAK FŐNÖK TUDJA MAJD!!
        public static void DolgozokHozaad(string vezeteknev, string keresztnev, string szulido, string adoazon, string taj, string irsz, string anyjaneve, int fizetes)
            {
            try
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
            catch (Exception ex)
            {
                Logger.Logging.LogExToTxt(ex);
            }
               
            }
            public static void Dolgozotorol(int id)
            {
            try
            {
                using (firepenguinEntities1 db = new firepenguinEntities1())
                {
                    Felhasznalok toroldolgozo = db.Felhasznaloks.FirstOrDefault(p => p.id == id);
                    db.Felhasznaloks.Remove(toroldolgozo);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Logger.Logging.LogExToTxt(ex);
            }
            
            }
        }
}
