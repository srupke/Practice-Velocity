using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PV.Providers;

namespace PT.EventProvider.UnitTests
{
    [TestClass]
    public class RegisterProviderUnitTests
    {
        [TestMethod]
        public void TestRegisterProvider_3_Equals_Register()
        {
            EventTypeBase provider = EventProviderManager.Providers["Register"];

            Assert.AreEqual("Register", provider.GetResultString(3));
        }

        [TestMethod]
        public void TestRegisterProvider_5_Equals_Patient()
        {
            EventTypeBase provider = EventProviderManager.Providers["Register"];

            Assert.AreEqual("Patient", provider.GetResultString(5));
        }

        [TestMethod]
        public void TestRegisterProvider_15_Equals_RegisterPatient()
        {
            EventTypeBase provider = EventProviderManager.Providers["Register"];

            Assert.AreEqual("Register Patient", provider.GetResultString(15));
        }
    }
}
