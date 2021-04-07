using System;
using System.Collections;

namespace CollectionsDemo
{
    class Product
    {
        public int Id;
        public string Name;
        public decimal UnitCost;
        public int Units;
        public string Category;

        public override string ToString()
        {
            return $"Id = {this.Id}, Name = {Name}, UnitCost={UnitCost}, Units = {Units}, Category = {Category}";
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

        
    }
    class Program
    {
        static void Main(string[] args)
        {
            var products = new Products();
            products.Add(new Product { Id = 5, Name = "Pen", UnitCost = 10, Units = 50, Category = "Stationary" });
            products.Add(new Product { Id = 7, Name = "Pencil", UnitCost = 5, Units = 5, Category = "Stationary" });
            products.Add(new Product { Id = 3, Name = "Marker", UnitCost = 50, Units = 15, Category = "Stationary" });
            products.Add(new Product { Id = 2, Name = "Grapes", UnitCost = 70, Units = 25, Category = "Grocery" });
            products.Add(new Product { Id = 5, Name = "Pan", UnitCost = 100, Units = 10, Category = "Utencil" });
            products.Add(new Product { Id = 1, Name = "Stove", UnitCost = 150, Units = 5, Category = "Utencil" });

            foreach(var product in products)
            {
                Console.WriteLine(product);
            }
        }
    }
}
