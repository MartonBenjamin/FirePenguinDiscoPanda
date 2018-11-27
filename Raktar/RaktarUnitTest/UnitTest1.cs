using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Raktar;

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
        //[TestMethod]
        //public void TestDolgozoListaz()
        //{
        //    List<CDolgozok> dolgozok = CDolgozokkezeles.DolgozokListaLeker();
        //    if (dolgozok == null)
        //    {
        //        Assert.Fail("Dolgozok lista null");
        //    }
        //    else if (dolgozok.Count < 1)
        //    {
        //        Assert.Fail("Dolgozok lista üres");
        //    }
        //}
        [TestMethod]
        public void TestAdoazonEll()
        {
            bool igaze = adoazonositoellenoriz("8478272844");
            if (igaze == false)
                Assert.Fail("Nem jó");
            
        }
    }
}
