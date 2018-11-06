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

namespace Raktar
{
    class CDolgozok
    {
        uint id, fizetes;
        string vezeteknev, keresztnev, szulido, adoazon, taj, irsz, anyjaneve;


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
        public string Szulido
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
        public uint Id
        {
            get { return id; }
            set { id = value; }
        }
        public uint Fizetes
        {
            get { return fizetes; }
            set { fizetes = value; }
        }
        public CDolgozok(uint id, string vezeteknev, string keresztnev, string szulido, string adoazon, string taj, string irsz, string anyjaneve, uint fizetes)
        {
            this.id = id; this.vezeteknev = vezeteknev; this.keresztnev = keresztnev;
            this.szulido = szulido; this.adoazon = adoazon; this.taj = taj; this.irsz = irsz;
            this.anyjaneve = anyjaneve; this.fizetes = fizetes;
        }


    }
    class CDolgozokkezeles
    {
        static public List<CDolgozok> dolgozok = new List<CDolgozok>();
        public static List<CDolgozok> DolgozokListaLeker()
        {
            uint id; uint fizetes;
            string vezeteknev; string keresztnev; string szulido; string adoazon; string taj; string irsz; string anyjaneve;
            using (firepenguinEntities1 db = new firepenguinEntities1())
            {

                var actid = db.Felhasznaloks.Select(u => u.id).Min();
                var worker = db.Felhasznaloks.FirstOrDefault(u => u.id == actid);
                while (actid <= db.Felhasznaloks.Select(u => u.id).Max())
                {
                    id = Convert.ToUInt32(worker.id);
                    fizetes = Convert.ToUInt32(worker.fizetes);
                    vezeteknev = Convert.ToString(worker.vezeteknev);
                    keresztnev = Convert.ToString(worker.keresztnev);
                    szulido = Convert.ToString(worker.szulido);
                    adoazon = Convert.ToString(worker.adoazon);
                    taj = Convert.ToString(worker.taj);
                    irsz = Convert.ToString(worker.irsz);
                    anyjaneve = Convert.ToString(worker.anyjaneve);
                    CDolgozok dolgozo = new CDolgozok(id, vezeteknev, keresztnev, szulido, adoazon, taj, irsz, anyjaneve, fizetes);
                    dolgozok.Add(dolgozo);
                    actid++;
                }
            }
            return dolgozok;
        }
    }
}
