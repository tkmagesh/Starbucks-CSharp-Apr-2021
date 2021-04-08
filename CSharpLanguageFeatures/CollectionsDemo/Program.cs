using System;
using System.Collections;
using System.Linq;

namespace CollectionsDemo
{
    

    
    class Program
    {
        public delegate int OperationDelegate(int x, int y);

        
        static void Main(string[] args)
        {
            var products = new Products();
            products.Add(new Product { Id = 5, Name = "Pen", UnitCost = 10, Units = 50, Category = "Stationary" });
            products.Add(new Product { Id = 7, Name = "Pencil", UnitCost = 5, Units = 5, Category = "Stationary" });
            products.Add(new Product { Id = 3, Name = "Marker", UnitCost = 50, Units = 15, Category = "Stationary" });
            products.Add(new Product { Id = 2, Name = "Grapes", UnitCost = 70, Units = 25, Category = "Grocery" });
            products.Add(new Product { Id = 4, Name = "Pan", UnitCost = 100, Units = 10, Category = "Utencil" });
            products.Add(new Product { Id = 1, Name = "Stove", UnitCost = 150, Units = 5, Category = "Utencil" });

            Console.WriteLine("Initial list");
            Print(products);

            Console.WriteLine("Sorting Products By Id");
            products.SortById();
            Print(products);

            
            Console.WriteLine("Sorting Products By Units");
            var productsComparerByUnits = new ProductsComparerByUnits();
            products.Sort(productsComparerByUnits);
            Print(products);

            Console.WriteLine("Sorting Products By UnitCost");
            var productsComparerByUnitCost = new ProductsComparerByUnitCost();
            products.Sort(productsComparerByUnitCost);
            Print(products);

            Console.WriteLine("Sorting Products By Name");
            /*
            ProductComparerDelegate compareProductsByName = (leftProduct, rightProduct) =>
            {
                return leftProduct.Name.CompareTo(rightProduct.Name);
            };
            */
            ProductComparerDelegate compareProductsByName = (leftProduct, rightProduct) => leftProduct.Name.CompareTo(rightProduct.Name);
            products.Sort(compareProductsByName);
            Print(products);

            Console.WriteLine("Filter products by Category [Stationary]");
            var stationaryProductsSpecification = new ProductSpecificationByCategory("Stationary");
            var stationaryProducts = products.Filter(stationaryProductsSpecification);
            Print(stationaryProducts);

            //var result = 0;
            //passing method implementation explicitly
            Console.WriteLine(PerformOperation(10, 20, Program.Add));

            //Inlining the function implementation
            Console.WriteLine(PerformOperation(10, 20, delegate (int x, int y){
                return x - y;
	        }));

            //Using lambda expression
            Console.WriteLine(PerformOperation(10, 20, (x,y) => {
                return x * y;
            }));

            //Using lambda expression (simpler implementation)
            Console.WriteLine(PerformOperation(10, 20, (x, y) => x / y));

            /*
            var calculator = new Calculator();
            Console.WriteLine(PerformOperation(100, 200, calculator.Add));
            Console.WriteLine(PerformOperation(100, 200, calculator.Subtract));
            Console.WriteLine(PerformOperation(100, 200, calculator.Multiply));
            Console.WriteLine(PerformOperation(100, 200, calculator.Divide));
            */

            /*
            var nonStationaryProducts = products.Filter(delegate (Product product)
            {
                return product.Category != "Stationary";
            });
            */

            /*
            var nonStationaryProducts = products.Filter(product => 
            {
                return product.Category != "Stationary";
            });
            */
            var nonStationaryProducts = products.Filter(p => p.Category != "Stationary");

            Console.WriteLine("Non Stationary products");
            Print(nonStationaryProducts);


            MyCollection<Customer> customers = new MyCollection<Customer>();
            customers.Add(new Customer { Id = 300, FirstName = "Magesh", LastName = "Kuppan" });
            customers.Add(new Customer { Id = 305, FirstName = "Suresh", LastName = "Kannan" });
            customers.Add(new Customer { Id = 302, FirstName = "Ganesh", LastName = "Shiva" });
            customers.Add(new Customer { Id = 306, FirstName = "Ramesh", LastName = "Jayaraman" });
            customers.Add(new Customer { Id = 301, FirstName = "Rajesh", LastName = "Kumar" });

            Console.WriteLine("Initial list of customers");
            customers.Print();

            Console.WriteLine("Sorting customers by Id");
            customers.Sort((c1, c2) => c1.Id - c2.Id);
            customers.Print();

            Console.WriteLine("Sorting customers by FirstName [using interface & comparer class]");
            customers.Sort(new CustomerComparerByFirstName());
            customers.Print();

            Console.WriteLine("Filtering customers with Id > 302 [using delegates");
            var customersWithIdAbove302 = customers.Filter(c => c.Id > 302);
            //customersWithIdAbove302.Print();

            Console.WriteLine("Filtering customers with Id > 302 [using specification");
            var customersWithIdAbove302Enumerable = customers.Filter(new CustomerSpecificationWithIdAbove302());
            foreach(var customer in customersWithIdAbove302Enumerable)
            {
                Console.WriteLine(customer);
            }

            var c = new Customer { Id = 500, FirstName = "Dummy", LastName = "Customer" };
            //MyUtils.WhoAmI(c);
            //Console.WriteLine(MyUtils.FormatForConsole(c));
            Console.WriteLine(c.FormatForConsole());
            var p = new Product { Id = 5, Name = "Pen", UnitCost = 10, Units = 50, Category = "Stationary" };
            //Console.WriteLine(MyUtils.FormatForConsole(p));
            Console.WriteLine(p.FormatForConsole());

            
            var maxId = customers.Max(customer => customer.Id);
            Console.WriteLine($"Max Id of customers collection : {maxId}\n");

            var customerNames = customers.Select(c => c.FirstName + ' ' + c.LastName);
            /*
            foreach (var cn in customerNames)
                Console.WriteLine(cn);
            */
            //customerNames.ForEach(cn => Console.WriteLine(cn));
            customerNames.ForEach(Console.WriteLine);

        }

        public static int PerformOperation(int x, int y, OperationDelegate operation)
        {
            return operation(x, y);
        }

        public static int Add(int x, int y)
        {
            return x + y;
        }

        public static void Print(Products products)
        {
            foreach (var product in products)
            {
                Console.WriteLine(product);
            }
        }
    }

    public class Calculator
    {
        public int Add(int x, int y)
        {
            return x + y;
        }

        public int Subtract(int x, int y)
        {
            return x - y;
        }

        public int Multiply(int x, int y)
        {
            return x * y;
        }

        public int Divide(int x, int y)
        {
            return x / y;
        }
    }

    public class CustomerComparerByFirstName : IItemComparer<Customer>
    {
        public int Compare(Customer leftItem, Customer rightItem)
        {
            return leftItem.FirstName.CompareTo(rightItem.FirstName);
        }
    }

    public class CustomerSpecificationWithIdAbove302 : IItemSpecification<Customer>
    {
        public bool SatisfiedBy(Customer item)
        {
            return item.Id > 302;
        }
    }
}

