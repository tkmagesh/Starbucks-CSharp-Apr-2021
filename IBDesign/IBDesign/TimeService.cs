using System;
namespace IBDesign
{
    public class TimeService : ITimeService
    {
        public TimeService()
        {
        }

        public DateTime GetCurrent()
        {
            return DateTime.Now;
        }
    }
}
