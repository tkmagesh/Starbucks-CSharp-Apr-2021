using System;
namespace CSharp8Features
{
   public interface IWelcome
    {
        string FirstName { get; }
        string LastName { get; }
        string Greet() => $"Hi {FirstName} {LastName}";
    }

    public class Person : IWelcome
    {
        public string FirstName { get; }

        public string LastName { get; }

        public Person(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
        }
        public string Greet()
        {
            return $"Hi {FirstName} {LastName}";
        }
    }

    public class MyProgram
    {
        public static void Test()
        {
            var p = new Person("Magesh", "Kuppan");
            IWelcome iw = p;
            iw.Greet();
        }
    }
}
