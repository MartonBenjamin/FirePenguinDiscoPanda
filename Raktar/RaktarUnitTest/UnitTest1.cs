using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Raktar;
using Raktar.Modell;
using Raktar.Services;

namespace RaktarUnitTest
{
    [TestClass]
    public class UnitTest1
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
        [TestMethod]
        public void TestMethod1()
        {
        }
        [TestMethod]
        public void TestDolgozoListaz1()
        {
            List<DolgozoModell> dolgozok = new List<DolgozoModell>();
            dolgozok = CDolgozokkezeles.DolgozokListaLeker();
            if (dolgozok == null)
            {
                Assert.Fail("Dolgozok lista null");
            }
            else if (dolgozok.Count < 1)
            {
                Assert.Fail("Dolgozok lista üres");
            }
        }
        [TestMethod]
        public void TestAdoazonEll()
        {
            bool igaze = adoazonositoellenoriz("8478272844");
            if (igaze == false)
                Assert.Fail("Nem jó");

        }

        #region Raktár unit teszt
        [TestMethod]
        public void TestRaktarakListaz()
        {
            List<RaktarModell> raktarak = new List<RaktarModell>();
            raktarak = CRaktarakKezeles.RaktarListaVisszaad();
            if (raktarak == null)
            {
                Assert.Fail("Raktárak lista null");
            }
            else if (raktarak.Count < 1)
            {
                Assert.Fail("Raktárak lista üres");
            }
        }

        [TestMethod]
        public void TestRaktarHozzaad()
        {
            CRaktarakKezeles.RaktarHozzaAd("Kis abc", "helyi kocsma 12.");
        }

        [TestMethod]
        public void TestRaktarTorol()
        {
            CRaktarakKezeles.RaktarTorol(1);
        }

        #endregion
        #region TermékKezelés unit tesztek
        [TestMethod]
        public void TestTermekLista()
        {
            List<TermekModell> termekek = new List<TermekModell>();
            termekek = CTermekkezeles.termekListaVisszaAd();
            if (termekek == null)
            {
                Assert.Fail("Termékek lista null");
            }
            else if (termekek.Count < 1)
            {
                Assert.Fail("Termékek lista üres");
            }
        }

        [TestMethod]
        public void TestTermekHozzaad()
        {
            CTermekkezeles.TermekHozaad(10, 10, 1000, "Krumpli", 2, DateTime.Now);
        }

        [TestMethod]
        public void TestTermekTorol()
        {

            CTermekkezeles.termekTorol(10);
        }
        #endregion
        #region Dolgozo Unit teszt
        [TestMethod]
        public void TestDolgozoListaz2()
        {
            Assert.Fail("Dolgozok lista üres");
        }
    
    [TestMethod]
    public void TestDolgozoHozzaad()
    {
        CDolgozokkezeles.DolgozokHozaad("Pistike", "Pistike", "1999-12-12", "123456789", "12345677", "3200", "Kis kutya", 12300);
    }
    [TestMethod]
    public void TestDolgozoTorol()
    {
        CDolgozokkezeles.Dolgozotorol(10);
    }
    [TestMethod]
    public void TestLoggeduserVisszaad()
    {
        DolgozoModell dolgozo = new DolgozoModell();
        var user = CDolgozokkezeles.LoggedUserVisszaad();
        if (dolgozo.GetType() != user.GetType())
        {
            Assert.Fail("Hiba történt");
        }
    }
    #endregion

    [TestMethod]
    public void TestRegister()
    {
        CRegister.Register("bunyospityu", "veremstack");
    }

    [TestMethod]
    public void TestJelszoValtoztat()
    {
        CRegister.JelszoValtoztat(10, "veremstack");
    }

    [TestMethod]
    public void TestMegrendelesTermekKikuld()
    {
        Megrendelés.TermekKikuld(2, 2, "Lagzilajcsi");
    }

    [TestMethod]
    public void TestMegrendelesTermekMegrendel()
    {
        Megrendelés.TermekMegrendel(2, 2, "Lagzilajcsi");
    }

    [TestMethod]
    public void TestVarosListazas()
    {
        List<VarosModell> varos = new List<VarosModell>();
        varos = Varoskezeles.VarosokVisszaad();
        if (varos == null)
        {
            Assert.Fail("Város lista null");
        }
        else if (varos.Count < 1)
        {
            Assert.Fail("Városok lista üres");
        }
    }
    }


}

