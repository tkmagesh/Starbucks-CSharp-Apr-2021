using System;

namespace OOPDemo
{
    class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal UnitCost { get; set; }
        public decimal Discount { get; set; }
        public decimal FinalCost() => UnitCost * ((100 - Discount) / 100);
       
    }

    class ProductItem
    {
        public Product Product { get; set; }
        public int Units { get; set; }
        /*
        public decimal ProductValue() => UnitCost * Units;
        */
        public decimal ProductValue()
        {
            return Units * Product.FinalCost();
        }
    }

    class Order
    {
        public ProductItem[] ProductItems = new ProductItem[] {
            new ProductItem
            {
                Product = new Product {Id = 100, Name = "Pen", UnitCost = 10, Discount = 5}
                , Units = 10
            },
            new ProductItem
            {
                Product = new Product {Id = 101, Name = "Pencil", UnitCost = 5, Discount = 5}
                , Units = 10
            },
            new ProductItem
            {
                Product = new Product {Id = 102, Name = "Marker", UnitCost = 50, Discount = 10}
                , Units = 10
            },
        };
        public decimal Discount;

        public decimal CalculateTotal()
        {
            var total = 0m;
            foreach(var productItem in ProductItems)
            {
                total += productItem.ProductValue();
            }
            return total * ((100 - Discount) / 100);
        }
    }



    class Program
    {
        static void Main(string[] args)
        {
            /*
            var product = new Product { Id = 101, Name = "Pen", UnitCost = 5, Discount = 5 };
            var productItem = new ProductItem { Product = product, Units = 10 };
            Console.WriteLine($"Product Value = {productItem.ProductValue()}");
            */
            var order = new Order();
            Console.WriteLine($"Order Value = {order.CalculateTotal()}");
        }
    }
}
