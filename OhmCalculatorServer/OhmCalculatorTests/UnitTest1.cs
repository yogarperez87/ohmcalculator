using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OhmCalculator.Entities;

namespace OhmCalculatorTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestOhmValue()
        {
            var ohmValue = new OhmValueCalculator();
            int result = ohmValue.CalculateOhmValue("Blue", "Red", "Silver", "Grey");
            Assert.AreEqual(result, 1);
        }
        [TestMethod]
        public void TestOhmValue2()
        {
            var ohmValue = new OhmValueCalculator();
            int result = ohmValue.CalculateOhmValue("Yellow", "Orange", "Brown", "Grey");
            Assert.AreEqual(result, 430);
        }
        [TestMethod]
        public void TestMethod3()
        {
        }
    }
}
