using System;

namespace UserDefinedTypes
{
    class Employee
    {
        //fields
        private int Id;
        public string FirstName;
        public string LastName;

        public static string Dummy = "A dummy string";

        //constructor method
        public Employee(int Id)
        {
            this.Id = Id;
            Console.WriteLine("A new employee object is being created!");
        }

        //static constructor method
        static Employee()
        {
            Console.WriteLine("The first instance of an employee is created");
        }

        public void Print()
        {
            Console.WriteLine($"Id = {this.Id}, FirstName = {FirstName}, LastName = {LastName}");
        }
    }

    class User
    {
        public string UserName;
        private static User instance;

        private User(string userName)
        {
            this.UserName = userName;
        }

        public void Print()
        {
            Console.WriteLine($"Current User = {UserName}");
        }

        static User()
        {
            if (instance == null)
            {
                instance = new User("Magesh");
            }
        }

        public static User GetUser()
        {
            return instance;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            /*
            var emp = new Employee();
            emp.Id = 100;
            emp.FirstName = "Magesh";
            emp.LastName = "Kuppan";
            */

            //using the object initializer syntax
            var emp = new Employee(100) { FirstName = "Magesh", LastName = "Kuppan" };
            emp.Print();

            var emp2 = new Employee(200) { FirstName = "John", LastName = "Kennedy" };
            emp2.Print();
            //var user = new User();

            var user = User.GetUser();
            user.Print();

            var user2 = User.GetUser();
            user2.Print();
        }
    }
}
