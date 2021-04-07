using System;
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
}
