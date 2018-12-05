using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raktar.Modell
{
    public class VarosModell
    {
        private string irszam;

        public string Irszam
        {
            get { return irszam; }
            set { irszam = value; }
        }
        private string varosmegnevezes;

        public string Varosmegnevezes
        {
            get { return varosmegnevezes; }
            set { varosmegnevezes = value; }
        }

    }
}
