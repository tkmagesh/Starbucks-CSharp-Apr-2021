using System;

namespace OOPDemo
{
    abstract class Product {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal UnitCost { get; set; }
        public decimal Discount { get; set; }
        public virtual decimal FinalCost() => UnitCost * ((100-Discount)/100);
    }

    class StaionaryProduct : Product
    {
        
    }

    class ElectronicProduct : Product
    {
        
    }

    class PerishableProduct : Product {        
        public int ExpiryInDays {get; set;}
        public override decimal FinalCost()
        {
            var finalDiscount = ExpiryInDays <= 2 ? Discount + 10 : Discount;
            return this.UnitCost * ((100 - finalDiscount) / 100);
        }
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

    class ProductItems
    {
        public ProductItem[] Items = new ProductItem[] {
            new ProductItem
            {
                Product = new StaionaryProduct {Id = 100, Name = "Pen", UnitCost = 10, Discount = 5}
                , Units = 10
            },
            new ProductItem
            {
                Product = new StaionaryProduct {Id = 101, Name = "Pencil", UnitCost = 5, Discount = 5}
                , Units = 10
            },
            new ProductItem
            {
                Product = new PerishableProduct {Id = 102, Name = "Grapes", UnitCost = 20, Discount = 25, ExpiryInDays = 2}
                , Units = 10
            }
        };

        public decimal ItemsTotal()
        {
            var total = 0m;
            foreach (var productItem in Items)
            {
                total += productItem.ProductValue();
            }
            return total;
        }
    }

    class Order
    {
        public ProductItems ProductItems = new ProductItems();
        public decimal Discount;

        public decimal CalculateTotal()
        {
            return ProductItems.ItemsTotal() * ((100 - Discount) / 100);
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
            /*
            var order = new Order();
            Console.WriteLine($"Order Value = {order.CalculateTotal()}");
            */

            //StaionaryProduct pen = new StaionaryProduct{ Id = 100, Name = "Pen", UnitCost = 10, Discount = 0 };
            //Console.WriteLine(pen.FinalCost());

            PerishableProduct grapes = new PerishableProduct { Id = 101, Name = "Grapes", UnitCost = 50, Discount = 25, ExpiryInDays = 2 };
            Console.WriteLine(grapes.FinalCost());

            Product p = grapes;
            Console.WriteLine(p.FinalCost());

            var order = new Order();
            Console.WriteLine($"Order Value = {order.CalculateTotal()}");
        }
    }
}
