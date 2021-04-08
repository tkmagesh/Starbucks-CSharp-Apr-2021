using Microsoft.VisualStudio.TestTools.UnitTesting;
using IBDesign;
using System;

class FakeTimeService : ITimeService
{
    private DateTime fakeTime;

    public FakeTimeService(DateTime fakeTime)
    {
        this.fakeTime = fakeTime;
    }
    public DateTime GetCurrent()
    {
        return this.fakeTime;
    }
}

namespace IBDesign.Tests
{
    [TestClass]
    public class GreeterTests
    {
        [TestMethod]
        public void Greets_Good_Morning_When_Greeted_Before_12()
        {
            //Arrange
            var timeServiceForMorning = new FakeTimeService(new DateTime(2011, 04, 09, 10, 0, 0));
            var greeter = new Greeter(timeServiceForMorning);
            var userName = "Magesh";
            var expectedMessage = "Hi Magesh, Good Morning!";

            //Act
            var actualMessage = greeter.Greet(userName);

            //Assert
            Assert.AreEqual(expectedMessage, actualMessage);
        }

        [TestMethod]
        public void Greets_Good_Evening_When_Greeted_After_12()
        {
            //Arrange
            var timeServiceForMorning = new FakeTimeService(new DateTime(2011, 04, 09, 16, 0, 0));
            var greeter = new Greeter(timeServiceForMorning);
            var userName = "Magesh";
            var expectedMessage = "Hi Magesh, Good Evening!";

            //Act
            var actualMessage = greeter.Greet(userName);

            //Assert
            Assert.AreEqual(expectedMessage, actualMessage);
        }
    }
}
