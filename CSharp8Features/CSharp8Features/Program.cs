using System;
using System.Collections.Generic;
using System.Linq;

public class Product 
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal UnitCost { get; set; }
    public int Units { get; set; }
    public int CategoryId { get; set; }

    public override string ToString()
    {
        return $"Id = {this.Id}\t Name = {Name}\t UnitCost={UnitCost}\t Units = {Units}\t Category = {CategoryId}";
    }
}

public class Category
{
    public int Id { get; set; }
    public string Name { get; set; }
}

namespace CSharp8Features
{
    class Program
    {
        static void Main(string[] args)
        {
            //var engine = new Tuple<string, int, double>("M270 Turbo", 1600, 75);
            var engine = Tuple.Create("M270 Turbo", 1600, 70);
            Console.WriteLine($"{engine.Item1} {engine.Item2} {engine.Item3}");

            (string Name, int Capacity, double Power) engine2 = ("M270 Turbo", 1600, 70);
            Console.WriteLine($"{engine2.Name} {engine2.Capacity} {engine2.Power}");

            var products = new List<Product>();
            products.Add(new Product { Id = 5, Name = "Pen", UnitCost = 10, Units = 50, CategoryId = 1 });
            products.Add(new Product { Id = 7, Name = "Pencil", UnitCost = 5, Units = 5, CategoryId = 1 });
            products.Add(new Product { Id = 3, Name = "Marker", UnitCost = 50, Units = 15, CategoryId = 1 });
            products.Add(new Product { Id = 2, Name = "Grapes", UnitCost = 70, Units = 25, CategoryId = 2 });
            products.Add(new Product { Id = 4, Name = "Pan", UnitCost = 100, Units = 10, CategoryId = 3 });
            products.Add(new Product { Id = 1, Name = "Stove", UnitCost = 150, Units = 5, CategoryId = 3 });

            var categories = new List<Category>()
            {
                new Category{ Id = 1, Name = "Stationary"},
                new Category{ Id = 2, Name = "Grocery"},
                new Category{ Id = 3, Name = "Utencil"}
            };

            var productsWithCategory = products.Join(categories, p => p.CategoryId, c => c.Id, (p, c) => ( Id : p.Id, Name : p.Name, Category : c.Name ));
            Print(productsWithCategory);
        }

        public static void Print(IEnumerable<(int Id, string Name, string Category)> productsWithCategory)
        {
            foreach (var pc in productsWithCategory)
            {
                Console.WriteLine($"Id = {pc.Id}, Name = {pc.Name}, Category = {pc.Category}");
            }
        }
        
    }
}


public static class MyUtils
{
    public static IEnumerable<TResult>  MyJoin<TOuter, TInner, TKey, TResult>(
            this IEnumerable<TOuter> outerList,
            IEnumerable<TInner> innerList,
            Func<TOuter, TKey> outerKeySelector,
            Func<TInner, TKey> innerKeySelector,
            Func<TOuter, TInner, TResult> mergeObject
            )
    {
        foreach(var outerObj in outerList)
            foreach(var innerObj in innerList)
            {
                TKey outerKeyValue = outerKeySelector(outerObj);
                TKey innerKeyValue = innerKeySelector(innerObj);
                if (outerKeyValue.Equals(innerKeyValue))
                {
                    yield return mergeObject(outerObj, innerObj);
                }
            }
    }
}