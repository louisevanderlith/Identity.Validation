using Identity.Validation.Country;
using Identity.Validation.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Identity.Validation.Tests
{
    [TestClass]
    public class SouthAfricaTest
    {
        private readonly IIdentification identification;

        public SouthAfricaTest()
        {
            var idNumber = "8801235111088";
            identification = new SouthAfricanID(idNumber);
        }

        [TestMethod]
        public void GenderIsMale()
        {
            Assert.AreEqual(Gender.Male, identification.Gender);
        }

        [TestMethod]
        public void BirthdayIsCorrect()
        {
            var expected = new DateTime(1988, 01, 23);
            Assert.AreEqual(expected, identification.DateOfBirth);
        }

        [TestMethod]
        public void IdIsValid()
        {
            Assert.IsTrue(identification.IsValid);
        }

        [TestMethod]
        public void IsRaceValid()
        {
            Assert.AreEqual(Race.White, identification.Race);
        }
    }
}
