using System;
namespace IBDesign
{
    public class Greeter
    {
        ITimeService timeService;

        public Greeter(ITimeService timeService)
        {
            this.timeService = timeService;
        }
        public string Greet(string userName)
        {
            if (timeService.GetCurrent().Hour < 12)
            {
                return $"Hi {userName}, Good Morning!";
            } else {
                return $"Hi {userName}, Good Evening!";
            }
        }
    }
}
