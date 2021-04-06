using System;
using System.Collections;

namespace OOPDemo
{
    abstract class Product {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal UnitCost { get; set; }
        public decimal Discount { get; set; }
        public virtual decimal FinalCost() => UnitCost * ((100-Discount)/100);

        public override string ToString()
        {
            return $"Id = {Id}, Name = {Name}, UnitCost = {UnitCost} Discount = {Discount}";
        }
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

        public override string ToString()
        {
            return $"{Product}, Units = {Units} ProductValue = {ProductValue()}";
        }
    }

    class ProductItems
    {
        private ArrayList Items = new ArrayList();

        public decimal ItemsTotal()
        {
            var total = 0m;
            foreach (var productItem in Items)
            {
                total += ((ProductItem)productItem).ProductValue();
            }
            return total;
        }

        public void AddProductItem(ProductItem productItem)
        {
            Items.Add(productItem);
        }

        public ProductItem GetProductItemByIndex(int index)
        {
            return (ProductItem)Items[index];
        }

        public override string ToString()
        {
            var result = "";
            foreach(var item in Items)
            {
                result += item.ToString() + "\n";
            }
            return result;
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

        public override string ToString()
        {
            return $"{ProductItems}\n Order Value : {CalculateTotal()}";
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
            /*
            PerishableProduct grapes = new PerishableProduct { Id = 101, Name = "Grapes", UnitCost = 50, Discount = 25, ExpiryInDays = 2 };
            Console.WriteLine(grapes.FinalCost());

            Product p = grapes;
            Console.WriteLine(p.FinalCost());

            var order = new Order();
            Console.WriteLine($"Order Value = {order.CalculateTotal()}");
            */
            /*
            ArrayList list = new ArrayList();
            list.Add(100);
            list.Add(new StaionaryProduct());
            list.Add(300);
            foreach(var item in list)
            {
                Console.WriteLine(item);
            }*/

            /*
            var pen = new StaionaryProduct { Id = 100, Name = "Pen", UnitCost = 10, Discount = 0 };
            var pencil = new StaionaryProduct { Id = 101, Name = "Pencil", UnitCost = 5, Discount = 5 };
            var marker = new StaionaryProduct { Id = 102, Name = "Marker", UnitCost = 50, Discount = 10 };
            var grapes = new PerishableProduct { Id = 103, Name = "Grapes", UnitCost = 30, Discount = 5, ExpiryInDays = 4 };
            var onions = new PerishableProduct { Id = 104, Name = "Onions", UnitCost = 20, Discount = 0, ExpiryInDays = 7 };
            var garlic = new PerishableProduct { Id = 105, Name = "Garlic", UnitCost = 40, Discount = 0, ExpiryInDays = 7 };

            var order = new Order();
            order.ProductItems.AddProductItem(new ProductItem { Product = pen, Units = 5 });
            order.ProductItems.AddProductItem(new ProductItem { Product = pencil, Units = 10 });
            order.ProductItems.AddProductItem(new ProductItem { Product = grapes, Units = 10 });
            order.ProductItems.AddProductItem(new ProductItem { Product = onions, Units = 15 });

            
            //Console.WriteLine(order.ProductItems);
            //Console.WriteLine(order.CalculateTotal());
            
            Console.WriteLine(order);
            */


            /*
            IDimension[] shapesWithDimension = new IDimension[]
            {
                new Circle { Radius = 5},
                new Rectangle { Height = 10, Width = 20 },
                new Circle { Radius = 15}
            };
            foreach (var shapeWithDimension in shapesWithDimension)
            {
                Console.WriteLine($"Area = {shapeWithDimension.Area()}, Perimeter = {shapeWithDimension.Perimeter()}");
            }*/

            Shapes shapes = new Shapes();
            shapes.AddShape(new Circle { Radius = 5 });
            shapes.AddShape(new Rectangle { Height = 10, Width = 20 });
            shapes.AddShape(new Circle { Radius = 10 });
            shapes.AddShape(new Rectangle { Height = 15, Width = 10 });

            /*
            for(var index = 0; index < shapes.Count; index++)
            {
                var shape = shapes[index];
                shape.Draw();
            }*/

            /*
            var enumerator = (IEnumerator)shapes;
            while (enumerator.MoveNext())
            {
                var shape = (Shape)enumerator.Current;
                shape.Draw();
            }
            */

            
            foreach(var shape in shapes)
            {
                ((Shape)shape).Draw();
            }
            

        }
    }
}

/*
 Actual Cost : Products cost without discount
 Savings : discount value
 To Pay : order value
*/
