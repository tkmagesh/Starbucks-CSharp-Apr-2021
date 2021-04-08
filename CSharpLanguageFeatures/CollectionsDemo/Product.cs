using System;
namespace CollectionsDemo
{
    public class Product : IFormattable
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal UnitCost { get; set; }
        public int Units { get; set; }
        public string Category { get; set; }

        public override string ToString()
        {
            return $"Id = {this.Id}\t Name = {Name}\t UnitCost={UnitCost}\t Units = {Units}\t Category = {Category}";
        }
    }
}
