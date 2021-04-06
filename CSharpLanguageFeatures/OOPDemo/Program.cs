using System;

namespace OOPDemo
{
    class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal UnitCost { get; set; }
        public decimal Discount { get; set; }
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
            return Units * Product.UnitCost;
        }
    }



    class Program
    {
        static void Main(string[] args)
        {
            var productItem = new ProductItem { Product = new Product { Id = 101, Name = "Pen", UnitCost = 5}, Units = 10 };
            Console.WriteLine($"Product Value = {productItem.ProductValue()}");
        }
    }
}
