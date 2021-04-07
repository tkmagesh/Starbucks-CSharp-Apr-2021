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

        public void Sort(ProductsComparer comparer, string attrName)
        {
            for (var i = 0; i < Count - 1; i++)
            {
                for (var j = i + 1; j < Count; j++)
                {
                    var leftProduct = (Product)list[i];
                    var rightProduct = (Product)list[j];
                    var swap = comparer.Compare(leftProduct, rightProduct, attrName);
                    if (swap)
                    {
                        var temp = leftProduct;
                        list[i] = list[j];
                        list[j] = temp;
                    }
                }
            }
        }

    }

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
    class Program
    {
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

            var productsComparer = new ProductsComparer();
            Console.WriteLine("Sorting Products By Units");
            products.Sort(productsComparer, "Units");
            Print(products);

            Console.WriteLine("Sorting Products By UnitCost");
            products.Sort(productsComparer, "UnitCost");
            Print(products);

        }

        public static void Print(Products products)
        {
            foreach (var product in products)
            {
                Console.WriteLine(product);
            }
        }
    }
}
