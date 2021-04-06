using System;
using System.Collections;

namespace OOPDemo
{
    public interface IDimension
    {
        double Area();
        double Perimeter();
    }

    public abstract class Shape
    {
        public abstract void Draw();
    }

    public class Circle :Shape, IDimension
    {
        public double Radius { get; set; }

        public double Area() => Math.PI * Radius * Radius;

        public override void Draw()
        {
            Console.Write($"Circle with Area= {Area()}, Perimeter={Perimeter()}\n");
        }

        public double Perimeter() => 2 * Math.PI * Radius;
    }


    public class Rectangle : Shape, IDimension
    {
        public double Height { get; set; }
        public double Width { get; set; }

        public double Area() => Width * Height;

        public double Perimeter() => (2 * Width) + (2 * Height);

        public override void Draw()
        {
            Console.Write($"Rectangle with Area= {Area()}, Perimeter={Perimeter()}\n");
        }

    }

    public class Shapes : IEnumerator, IEnumerable
    {
        private ArrayList list = new ArrayList();

        private int index = -1;

        public void AddShape(Shape shape)
        {
            list.Add(shape);
        }

        public Shape GetByIndex(int index)
        {
            return (Shape)list[index];
        }

        public bool MoveNext()
        {
            ++index;
            if (index < list.Count)
            {
                return true;
            } else
            {
                Reset();
                return false;
            }
        }

        public void Reset()
        {
            index = -1;
        }

        public IEnumerator GetEnumerator()
        {
            return this;
        }



        //indexer syntax
        public Shape this[int index]
        {
            get
            {
                return (Shape)list[index];
            }
        }

        public int Count
        {
            get
            {
                return list.Count;
            }
        }

        public object Current => (Shape)list[index];
    }
}
