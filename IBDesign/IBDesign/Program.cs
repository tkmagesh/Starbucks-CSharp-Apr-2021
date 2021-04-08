using System;

namespace IBDesign
{

    class Program
    {
        static void Main(string[] args)
        {
            var ts = new TimeService();
            var greeter = new Greeter(ts);
            Console.WriteLine(greeter.Greet("Magesh"));
        }
    }
}
