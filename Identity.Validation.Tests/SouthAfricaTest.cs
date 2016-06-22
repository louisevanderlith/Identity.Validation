using System;
using Identity.Validation.Country;
using Identity.Validation.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Identity.Validation.Tests
{
    [TestClass]
    public class SouthAfricaTest
    {
        private readonly IIdentification identification;

        public SouthAfricaTest()
        {
            var idNumber = "9102085125081";
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
            var expected = new DateTime(1991, 02, 08);
            Assert.AreEqual(expected, identification.DateOfBirth);
        }

        [TestMethod]
        public void IdIsValid()
        {
            Assert.IsTrue(identification.IsValid);
        }
    }
}
