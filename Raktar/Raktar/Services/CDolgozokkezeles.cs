using System;
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
using Raktar.Modell;
using System.Data.Entity.Core;
using System.Data.Entity.Infrastructure;
using Raktar.Pagek;
using Raktar.Services;

namespace Raktar
{
   
    public class CDolgozokkezeles
    {
        static public int loggeduserid = 0;

        public static DolgozoModell LoggedUserVisszaad()
        {
            try
            {
                DolgozoModell loggeddolgozo = new DolgozoModell();
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
            catch (Exception ex)
            {                
                MessageBox.Show("Hiba a szerver kapcsolatban");
                Logger.Logging.LogExToTxt(ex);
                return null;
            }
        }

        public static List<DolgozoModell> DolgozokListaLeker()
        {
            try
            {
                List<DolgozoModell> dolgozok = new List<DolgozoModell>();
                using (firepenguinEntities1 db = new firepenguinEntities1())
                {

                    foreach (var felhasznalok in db.Felhasznaloks)
                    {
                        dolgozok.Add(new DolgozoModell
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
            catch (EntityCommandExecutionException ex)
            {
                MessageBox.Show("Hiba a szerver kapcsolatban.");
                Logger.Logging.LogExToTxt(ex);
                return null;
            }
            catch (EntityException ex)
            {
                MessageBox.Show("Hiba a szerver kapcsolatban.");
                Logger.Logging.LogExToTxt(ex);
                return null;
            }
            catch (Exception ex)
            {
                Logger.Logging.LogExToTxt(ex);
                MessageBox.Show("A dolgozók betöltése sikertelen!");
                return null;
            }
        }

        //HOZZÁADNI, CSAK FŐNÖK TUDJA MAJD!!
        public static void DolgozokHozaad(string vezeteknev, string keresztnev, string szulido, string adoazon, string taj, string irsz, string anyjaneve, int fizetes)
            {
            //try
            //{
                using (firepenguinEntities1 db = new firepenguinEntities1())
                {
                    Felhasznalok ujdolgozo = new Felhasznalok();

                    ujdolgozo.id = db.Felhasznaloks.Select(p => p.id).Max() + 1;
                    ujdolgozo.vezeteknev = vezeteknev;
                    ujdolgozo.keresztnev = keresztnev;
                    ujdolgozo.szulido = Convert.ToDateTime(szulido);
                    ujdolgozo.adoazon = adoazon;
                    ujdolgozo.taj = taj;
                    ujdolgozo.irsz = irsz;
                    ujdolgozo.anyjaneve = anyjaneve;
                    ujdolgozo.fizetes = fizetes;
                    ujdolgozo.loginid = db.Logins.Select(p => p.id).Max() + 1;                    
                    db.Felhasznaloks.Add(ujdolgozo);
                    db.SaveChanges();                
                    CRegister.Register(vezeteknev, keresztnev);                    
                }
                MessageBox.Show("Dolgozó sikeresen hozzáadva.");
            }
            //catch (EntityCommandExecutionException ex)
            //{
            //    MessageBox.Show("Hiba a szerver kapcsolatban.");
            //    Logger.Logging.LogExToTxt(ex);
            //}
            //catch (EntityException ex)
            //{
            //    MessageBox.Show("Hiba a szerver kapcsolatban.");
            //    Logger.Logging.LogExToTxt(ex);
            //}
            //catch (DbUpdateException ex)
            //{                
            //    MessageBox.Show("Hibás beviteli érték.");
            //    Logger.Logging.LogExToTxt(ex);
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Hiba");
            //    Logger.Logging.LogExToTxt(ex);
            //}
    
       // }
            public static void Dolgozotorol(int id)
            {
            try
            {
                using (firepenguinEntities1 db = new firepenguinEntities1())
                {
                    Felhasznalok toroldolgozo = db.Felhasznaloks.FirstOrDefault(p => p.id == id);
                    Login toroldolgozologin = db.Logins.FirstOrDefault(u => u.id == toroldolgozo.loginid);
                    db.Felhasznaloks.Remove(toroldolgozo);
                    db.Logins.Remove(toroldolgozologin);
                    db.SaveChanges();
                }
            }
            catch (ArgumentNullException ex)
            {
                MessageBox.Show("Ilyen id-vel nem létezik dolgozó!");
                Logger.Logging.LogExToTxt(ex);
            }
            catch (EntityCommandExecutionException ex)
            {
                MessageBox.Show("Hiba a szerver kapcsolatban.");
                Logger.Logging.LogExToTxt(ex);
            }
            catch (EntityException ex)
            {
                MessageBox.Show("Hiba a szerver kapcsolatban.");
                Logger.Logging.LogExToTxt(ex);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hiba!");
                Logger.Logging.LogExToTxt(ex);
            }

        }
        }
}
