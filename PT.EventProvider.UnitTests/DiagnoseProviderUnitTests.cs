using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PV.Providers;

namespace PT.EventProvider.UnitTests
{
    [TestClass]
    public class DiagnoseProviderUnitTests
    {
        [TestMethod]
        public void TestDiagnoseProvider_2_Equals_Diagnose()
        {
            EventTypeBase provider = EventProviderManager.Providers["Diagnose"];

            Assert.AreEqual("Diagnose", provider.GetResultString(2));
        }

        [TestMethod]
        public void TestDiagnoseProvider_7_Equals_Patient()
        {
            EventTypeBase provider = EventProviderManager.Providers["Diagnose"];

            Assert.AreEqual("Patient", provider.GetResultString(7));
        }

        [TestMethod]
        public void TestDiagnoseProvider_14_Equals_DiagnosePatient()
        {
            EventTypeBase provider = EventProviderManager.Providers["Diagnose"];

            Assert.AreEqual("Diagnose Patient", provider.GetResultString(14));
        }
    }
}
