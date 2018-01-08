using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTestDemo;

namespace UnitTestDemi.Tests
{
    [TestClass]
    public class BankszamlaTests
    {

        /// <summary>
        /// Ellenőrzi ezt:
        /// egy új bankszámlán ha jóváírunk 5000 forintot,
        /// akkor a bankszámla egyenlege 5000 ft kell, hogy legyen
        /// </summary>
        [TestMethod]
        public void BankszamlaJovairasNoveliAzEgyenleget()
        {
            //Arrange: előkészítés, létrehozás
            var bnkszmla = new Bankszamla("Teszt bankszámla");

            //Act: művelet
            bnkszmla.Jovairas(5000);

            //Assert: ellenőrzés
            Assert.AreEqual(4000, bnkszmla.Egyenleg);

        }
    }
}
