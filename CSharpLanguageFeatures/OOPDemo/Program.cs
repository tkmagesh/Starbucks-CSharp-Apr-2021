using System;

namespace OOPDemo
{
    class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        private decimal _unitCost;
        public decimal UnitCost {
            set
            {
                _unitCost = value;
            }
            get
            {
                return _unitCost * ((100 - Discount) / 100);
            }
        }
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
            var product = new Product { Id = 101, Name = "Pen", UnitCost = 5, Discount = 5 };
            var productItem = new ProductItem { Product = product, Units = 10 };
            Console.WriteLine($"Product Value = {productItem.ProductValue()}");
        }
    }
}
