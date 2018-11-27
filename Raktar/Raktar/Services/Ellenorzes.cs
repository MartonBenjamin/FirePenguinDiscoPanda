using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raktar.Services
{
    class Ellenorzes
    {
        public bool adoazonositoellenoriz(string adoazonosito)
        {
            if (adoazonosito.Length != 10)
                return false;
            char[] arr = adoazonosito.ToCharArray();
            int sum = 0;
            for (int i = 0; i < 9; i++)
                sum += arr[i];
            if (arr[9] % 11 == 10)
                return false;

            return true;
        }
        public bool tajszamellenoriz(string tajszam)
        {
            if (tajszam.Length != 9)
                return false;
            int parosakosszege = tajszam[1] + tajszam[3] + tajszam[5] + tajszam[7] * 7;
            int paratlanokosszege = tajszam[0] + tajszam[2] + tajszam[4] + tajszam[6] * 3;
            if ((parosakosszege + paratlanokosszege) % 10 != tajszam[8])
                return false;
            return true;
        }
    }
}
