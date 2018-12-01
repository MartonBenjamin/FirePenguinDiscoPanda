using Raktar.Modell;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Raktar.Services;

namespace Raktar
{
    class CTermekkezeles
    {
        //Add,remove,modify Ha 0 van raktáron kiírja, hogy "nincs raktáron"        
        public static List<TermekModell> termekListaVisszaAd()
        {
            try
            {
                List<TermekModell> termekek = new List<TermekModell>();

                //int id; int suly; int raktar;
                //string megnevezes; byte raktaron;
                //DateTime beszallitva; DateTime szavatossag;
                using (firepenguinEntities1 db = new firepenguinEntities1())
                {

                    foreach (var termek in db.Termék)
                    {
                        termekek.Add(new TermekModell
                        {
                            Id = termek.id,
                            Suly_gramm = termek.Súly_gramm_,
                            Raktár = termek.Raktár,
                            Megnevezés = termek.Megnevezés,
                            Raktáron = termek.Raktáron,
                            Beszállítva = Convert.ToDateTime(termek.Beszállítva),
                            Szavatosság = Convert.ToDateTime(termek.Szavatosság)
                        });
                    }
                    return termekek;
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
                MessageBox.Show("A termékek betöltése sikertelen!");
                return null;
            }
        }

        public static void termekTorol(int id)
        {
            try
            {
                if (CRegister.Admine(CDolgozokkezeles.loggeduserid))
                {
                    using (firepenguinEntities1 db = new firepenguinEntities1())
                    {
                        Termék toroltermek = db.Termék.FirstOrDefault(p => p.id == id);
                        db.Termék.Remove(toroltermek);
                        db.SaveChanges();
                    }
                }
                else
                    MessageBox.Show("Nincs jogosultságod a termék törléséhez!");
            }
            catch (ArgumentNullException ex)
            {
                MessageBox.Show("Ilyen id-vel nem létezik termék!");
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

        public static void TermekHozaad(int suly, int raktar, string megnevezes, byte raktaron, DateTime szavatossag)
        {
            try
            {
                using (firepenguinEntities1 db = new firepenguinEntities1())
                {
                    Termék ujtermek = new Termék();
                    int maxId = db.Termék.Select(p => p.id).Max();
                    ujtermek.id = maxId + 1;
                    ujtermek.Megnevezés = megnevezes;
                    ujtermek.Súly_gramm_ = suly;
                    ujtermek.Raktár = raktar;
                    ujtermek.Raktáron = raktaron;
                    ujtermek.Beszállítva = DateTime.Now;
                    ujtermek.Szavatosság = szavatossag;
                    db.Termék.Add(ujtermek);

                    db.SaveChanges();
                }
                MessageBox.Show("Termék sikeresen hozzáadva.");
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
            catch (DbUpdateException ex)
            {
                MessageBox.Show("Hibás beviteli érték.");
                Logger.Logging.LogExToTxt(ex);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hiba");
                Logger.Logging.LogExToTxt(ex);
            }
        }

       
            
        }

    }


