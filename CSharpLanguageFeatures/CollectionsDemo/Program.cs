using System;
using System.Collections;

namespace CollectionsDemo
{
    public class Product
    {
        public int Id;
        public string Name;
        public decimal UnitCost;
        public int Units;
        public string Category;

        public override string ToString()
        {
            return $"Id = {this.Id}\t Name = {Name}\t UnitCost={UnitCost}\t Units = {Units}\t Category = {Category}";
        }
    }

    class Products : IEnumerable, IEnumerator
    {
        ArrayList list = new ArrayList();
        private int index = -1;
        public int Count
        {
            get
            {
                return list.Count;
            }
        }

        public object Current => list[index];

        public void Add(Product product)
        {
            list.Add(product);
        }

        public Product this[int index]
        {
            get
            {
                return (Product)list[index];
            }
        }

        public Product GetById(int id)
        {
            foreach(var item in list)
            {
                if (((Product)item).Id == id)
                {
                    return (Product)item;
                }
            }
            return null;
        }

        public void Remove(Product product)
        {
            list.Remove(product);
        }

        public IEnumerator GetEnumerator()
        {
            return this;
        }

        public bool MoveNext()
        {
            ++index;
            if (index >= Count) {
                Reset();
                return false;
            } else
            {
                return true;
            }
        }

        public void Reset()
        {
            index = -1;
        }

        public void SortById()
        {
            for(var i=0; i < Count-1; i++)
            {
                for(var j= i+1; j < Count; j++)
                {
                    var leftProduct = (Product)list[i];
                    var rightProduct = (Product)list[j];
                    if (leftProduct.Id > rightProduct.Id)
                    {
                        var temp = leftProduct;
                        list[i] = list[j];
                        list[j] = temp;
                    }
                }
            }
        }

        public void Sort(IProductComparer comparer)
        {
            for (var i = 0; i < Count - 1; i++)
            {
                for (var j = i + 1; j < Count; j++)
                {
                    var leftProduct = (Product)list[i];
                    var rightProduct = (Product)list[j];
                    if (comparer.Compare(leftProduct, rightProduct) > 0)
                    {
                        var temp = leftProduct;
                        list[i] = list[j];
                        list[j] = temp;
                    }
                }
            }
        }

        public void Sort(ProductComparerDelegate comparerDelegate)
        {
            for (var i = 0; i < Count - 1; i++)
            {
                for (var j = i + 1; j < Count; j++)
                {
                    var leftProduct = (Product)list[i];
                    var rightProduct = (Product)list[j];
                    if (comparerDelegate(leftProduct, rightProduct) > 0)
                    {
                        var temp = leftProduct;
                        list[i] = list[j];
                        list[j] = temp;
                    }
                }
            }
        }

        public Products Filter(IProductSpecification specification)
        {
            var result = new Products();
            foreach(var item in list)
            {
                var product = (Product)item;
                if (specification.SatisfiedBy(product))
                {
                    result.Add(product);
                }
            }
            return result;
        }

        public Products Filter(ProductPredicate productPredicate)
        {
            var result = new Products();
            foreach (var item in list)
            {
                var product = (Product)item;
                if (productPredicate(product))
                {
                    result.Add(product);
                }
            }
            return result;
        }

    }

    public interface IProductSpecification
    {
        bool SatisfiedBy (Product product);
    }

    public delegate bool ProductPredicate(Product product);

    public class ProductSpecificationByCategory : IProductSpecification
    {
        private string category;

        public ProductSpecificationByCategory(string category)
        {
            this.category = category;
        }
        public bool SatisfiedBy(Product product)
        {
            return product.Category == category;
        }
    }
    interface IProductComparer
    {
        int Compare(Product leftProduct, Product rightProduct);
    }

    public delegate int ProductComparerDelegate(Product leftProduct, Product rightProduct);

    class ProductsComparerById : IProductComparer
    {
        public int Compare(Product leftProduct, Product rightProduct)
        {
            if (leftProduct.Id > rightProduct.Id) return 1;
            if (leftProduct.Id < rightProduct.Id) return -1;
            return 0;
        }
    }

    class ProductsComparerByUnits : IProductComparer
    {
        public int Compare(Product leftProduct, Product rightProduct)
        {
            if (leftProduct.Units > rightProduct.Units) return 1;
            if (leftProduct.Units < rightProduct.Units) return -1;
            return 0;
        }
    }
    class ProductsComparerByUnitCost : IProductComparer
    {
        public int Compare(Product leftProduct, Product rightProduct)
        {
            if (leftProduct.UnitCost > rightProduct.UnitCost) return 1;
            if (leftProduct.UnitCost < rightProduct.UnitCost) return -1;
            return 0;
        }
    }
    /*
    class ProductsComparer
    {
        public bool Compare(Product leftProduct, Product rightProduct, string attrName)
        {
            switch (attrName)
            {
                case "Id":
                    return leftProduct.Id > rightProduct.Id;
                    
                case "Units":
                    return leftProduct.Units > rightProduct.Units;
                    
                case "UnitCost":
                    return leftProduct.UnitCost > rightProduct.UnitCost;
                    
                case "Name":
                    return leftProduct.Name.CompareTo(rightProduct.Name) > 0;
                    
                case "Category":
                    return leftProduct.Category.CompareTo(rightProduct.Category) > 0;
                default:
                    return false;
            }
        }
    }
    */
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
}
