using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Raktar;

namespace RaktarUnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
        }
        [TestMethod]
        public void TestDolgozoListaz()
        {
            List<CDolgozok> dolgozok = CDolgozokkezeles.DolgozokListaLeker();
            if (dolgozok == null)
            {
                Assert.Fail("Dolgozok lista null");
            }
            else if (dolgozok.Count < 1)
            {
                Assert.Fail("Dolgozok lista üres");
            }
        }
    }
}
