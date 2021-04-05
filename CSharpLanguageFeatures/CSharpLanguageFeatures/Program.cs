using System;
/*
class Car
{
    public string Color;
}
*/

struct Car
{
    public string Color;

    public void WhoAmI()
    {
        Console.WriteLine("I am a car");
    }
}

namespace CSharpLanguageFeatures
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            int x = 10;
            int y = x;
            x = 100;
            Console.WriteLine(y);
            */

            /*
            Car c1 = new Car { Color = "Blue" };
            Car c2 = c1;
            c1.Color = "Red";
            Console.WriteLine(c1.Color);
            Console.WriteLine(c2.Color);
            c1.WhoAmI();
            */

            /*
            const int x = 100;
            */

            //nullable type
            //Nullable<int> x = null;
            int? x = null;
            /*
            if (x.HasValue) {
                Console.WriteLine(x);
            } else
            {
                Console.WriteLine("x has null value");
            }
            */
            //Console.WriteLine(x.GetValueOrDefault());

            int y;
            /*
            if (x.HasValue)
            {
                y = x.Value;
            } else
            {
                y = -1;
            }
            */
            //the above can be simplied using the null caoalescing operator
            int? z = null;

            y = x ?? z ?? -1;

            //Arrays (fixed size)
            //int[] nos = new int[] { 4, 1, 6, 2, 5, 7 };
            //int[] nos = new int[6];
            //int[] nos = new int[6] { 4, 1, 6, 2, 5,7 };
            //int[] nos = { 4, 1, 6, 2, 5, 7 };
            var nos = new int[]{ 4, 1, 6, 2, 5, 7 };
            //Console.WriteLine(nos.Length);

            /*
            for (var i = 0; i < nos.Length; i++)
            {
                Console.WriteLine(nos[i]);
            }
            */
            foreach(var no in nos)
            {
                Console.WriteLine(no);
            }

            //Type conversion
            /*
            int a = 100;
            float b = a;
            Console.WriteLine(b);
            */
            /*
            float a = 100.45f;
            int b = (int)a;
            Console.WriteLine(b);
            */

            //type conversion using helper methods
            /*
            var dateAsString = "5-Apr-2021";
            var d = DateTime.Parse(dateAsString);
            Console.WriteLine(d);
            */

            //control statements
            //switch
            //SwitchDemo();

            //indefinite loops
            /*for(; ; )
            {
                break;
            }*/

            //while loop
            /*
            
            initializer;
            while(condition){
                statement1;
                statement2;
            }
            */

            /*
            var i = 0;
            while(i <= 10)
            {
                if (i % 2 == 0)
                {
                    Console.WriteLine($"{i} is an even number");
                } else
                {
                    Console.WriteLine($"{i} is an odd number");
                }
                i++;
            }*/

            //do while construct
            /*
            var i = 0;
            do
            {
                if (i % 2 == 0)
                {
                    Console.WriteLine($"{i} is an even number");
                }
                else
                {
                    Console.WriteLine($"{i} is an odd number");
                }
                i++;
            }
            while (i <= 10);
            */


            //break
            /*
            for(var i=0; i<= 10; i++)
            {
                Console.WriteLine(i);
                if (i == 5)
                    break;
            }
            */
            //continue
            Console.WriteLine("Using 'continue'");
            for(var i=0; i<= 10; i++)
            {
                if (i % 2 != 0)
                    continue;
                Console.WriteLine(i);
            }

            var fib10 = Fibonacci(10);
            Console.WriteLine($"10th Fibonacci no : {fib10}");
            
        }

        //Function returns nth Fibonacci number
        public static int Fibonacci(int n)
        {
            if (n > 1)
            {
                return Fibonacci(n - 1) + Fibonacci(n - 2);
            }
            else
            {
                return n;
            }
             
        }

        public static void SwitchDemo()
        {
            Console.WriteLine("Enter number (1-10");
            var line = Console.ReadLine();
            var no = int.Parse(line);
            switch (no)
            {
                case 1:
                    Console.WriteLine("Smallest numbers");
                    break;
                case 2: case 3: case 5: case 7:
                    Console.WriteLine("Prime Number");
                    break;
                case 4: 
                case 6:
                case 8:
                    Console.WriteLine("Even number");
                    break;
                case 9:
                    Console.WriteLine("Odd number");
                    break;
                default:
                    Console.WriteLine("Not in the range");
                    break;

            }
        }
    }

    
}
