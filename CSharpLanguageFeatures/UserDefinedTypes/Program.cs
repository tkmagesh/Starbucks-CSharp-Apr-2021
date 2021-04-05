using System;

namespace UserDefinedTypes
{
    class Employee
    {
        //fields
        private int Id;
        //private string _FirstName;
        public readonly string LastName;

        /*
        public string GetFirstName()
        {
            return FirstName;
        }
        public void SetFirstName(string value)
        {
            //do some validations
            FirstName = value;
        }
        */

        /*
        public string FirstName
        {
            get
            {
                //Console.WriteLine("firstname getter triggered");
                return _FirstName;
            }
            set
            {
                //Console.WriteLine($"firstname setter triggered with value : {value}");
                _FirstName = value;
            }
        }*/

        public string FirstName { get; set; }
        

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

    /*
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
    */
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
            var emp = new Employee(100) { LastName = "Kuppan" };
            emp.FirstName = "Magesh";
            Console.WriteLine(emp.FirstName);
            //emp.Print();

            var emp2 = new Employee(200) { LastName = "Kennedy" };
            //emp.SetFirstName("John");
            emp2.FirstName = "John";
            Console.WriteLine(emp2.FirstName);
            //emp2.Print();
            //var user = new User();

            /*
            var user = User.GetUser();
            user.Print();

            var user2 = User.GetUser();
            user2.Print();
            */
        }
    }
}
