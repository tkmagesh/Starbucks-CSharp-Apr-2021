using System;

namespace OOPDemo
{
    public interface IDimension
    {
        double Area();
        double Perimeter();
    }

    public class Circle : IDimension
    {
        public double Radius { get; set; }

        public double Area() => Math.PI * Radius * Radius;

        public double Perimeter() => 2 * Math.PI * Radius;
    }


    public class Rectangle : IDimension
    {
        public double Height { get; set; }
        public double Width { get; set; }

        public double Area() => Width * Height;

        public double Perimeter() => (2 * Width) + (2 * Height);
               
    }
}
