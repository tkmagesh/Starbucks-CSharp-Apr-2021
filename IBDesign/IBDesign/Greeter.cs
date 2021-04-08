using System;
namespace IBDesign
{
    public class Greeter
    {
       public string Greet(string userName)
        {
            if (DateTime.Now.Hour < 12)
            {
                return $"Hi {userName}, Good Morning!";
            } else {
                return $"Hi {userName}, Good Evening!";
            }
        }
    }
}
