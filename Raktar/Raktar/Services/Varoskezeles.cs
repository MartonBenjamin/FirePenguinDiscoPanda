using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Raktar.Modell;

namespace Raktar.Services
{
    class Varoskezeles
    {
        public static List<VarosModell> VarosokVisszaad()
        {
            List<VarosModell> varosok = new List<VarosModell>();

            using (firepenguinEntities1 db = new firepenguinEntities1())
            {
                foreach (var varo in db.Város)
                {
                    varosok.Add(new VarosModell
                    {
                        Irszam = varo.Irányítószám,
                        Varosmegnevezes = varo.Város1

                    });
                }
                return varosok;
            }

        }

    }
}
