using Microsoft.VisualStudio.TestTools.UnitTesting;
using IBDesign;

namespace IBDesign.Tests
{
    [TestClass]
    public class CalculatorTests
    {
        [TestMethod]
        public void Adding_numbers()
        {
            //Arrange
            var calculator = new Calculator();
            var x = 10;
            var y = 20;
            var expectedResult = 30;

            //Act
            var result = calculator.Add(x, y);

            //Assert
            Assert.AreEqual(expectedResult, result);
        }
    }
}
