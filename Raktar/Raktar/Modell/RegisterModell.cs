using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raktar.Modell
{
    class RegisterModell
    {
        private int id;
        private string felhasznalonev, jelszo;
        private bool admin;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Felhasznalonev
        {
            get { return felhasznalonev; }
            set { felhasznalonev = value; }
        }

        public string Jelszo
        {
            get { return jelszo; }
            set { jelszo = value; }
        }

        public bool Admin
        {
            get { return admin; }
            set { admin = value; }
        }
    }
}
