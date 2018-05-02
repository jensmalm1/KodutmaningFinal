using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Kodutmaning;


namespace UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestTullPris1()
        {

            var testFordon1 = new Fordon
            {
                FordonsTyp = FordonsTyp.Lastbil,
                MiljöKlassad = false,
                TidVidTullen = DateTime.Parse("2018-04-26 19:30"),
                Vikt = 2000
            };
            double expectedValue1 = 2000;

            Assert.AreEqual(expectedValue1, Program.TullPris(testFordon1));
        }

        [TestMethod]
        public void TestTullPris2()
        {
            var testFordon2 = new Fordon
            {
                FordonsTyp = FordonsTyp.Motorcykel,
                MiljöKlassad = false,
                TidVidTullen = DateTime.Parse("2018-04-27 20:30"),
                Vikt = 500
            };

            double expectedValue2 =175;

            Assert.AreEqual(expectedValue2, Program.TullPris(testFordon2));
        }

        [TestMethod]
        public void TestTullPris3()
        {
            var testFordon3 = new Fordon
            {
                FordonsTyp = FordonsTyp.Personbil,
                MiljöKlassad = false,
                TidVidTullen = DateTime.Parse("2018-04-28 18:30"),
                Vikt = 1500
            };

            double expectedValue3 = 2000;

            Assert.AreEqual(expectedValue3, Program.TullPris(testFordon3));
        }

        [TestMethod]
        public void TestTullPris4()
        {
            var testFordon4 = new Fordon
            {
                FordonsTyp = FordonsTyp.Lastbil,
                MiljöKlassad = true,
                TidVidTullen = DateTime.Parse("2018-04-29 14:30"),
                Vikt = 8000
            };

            double expectedValue4 =0;
            Assert.AreEqual(expectedValue4, Program.TullPris(testFordon4));
        }


    }
}
