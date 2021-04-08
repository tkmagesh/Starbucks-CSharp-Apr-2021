using System;
using System.Collections;
using System.Collections.Generic;

namespace CollectionsDemo
{

    public class MyCollection<T> : IEnumerable, IEnumerator, IEnumerable<T>, IEnumerator<T>
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

        T IEnumerator<T>.Current => (T)list[index];

        public void Add(T item)
        {
            list.Add(item);
        }

        public T this[int index]
        {
            get
            {
                return (T)list[index];
            }
        }
        /*
        public Product GetById(int id)
        {
            foreach (var item in list)
            {
                if (((Product)item).Id == id)
                {
                    return (Product)item;
                }
            }
            return null;
        }
        */

        public void Remove(T item)
        {
            list.Remove(item);
        }

        public IEnumerator GetEnumerator()
        {
            return this;
        }

        public bool MoveNext()
        {
            ++index;
            if (index >= Count)
            {
                Reset();
                return false;
            }
            else
            {
                return true;
            }
        }

        public void Reset()
        {
            index = -1;
        }

        /*
        public void SortById()
        {
            for (var i = 0; i < Count - 1; i++)
            {
                for (var j = i + 1; j < Count; j++)
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
        */

        public void Sort(IItemComparer<T> comparer)
        {
            for (var i = 0; i < Count - 1; i++)
            {
                for (var j = i + 1; j < Count; j++)
                {
                    var leftItem = (T)list[i];
                    var rightItem = (T)list[j];
                    if (comparer.Compare(leftItem, rightItem) > 0)
                    {
                        var temp = leftItem;
                        list[i] = list[j];
                        list[j] = temp;
                    }
                }
            }
        }

        public void Sort(ItemComparerDelegate<T> comparerDelegate)
        {
            for (var i = 0; i < Count - 1; i++)
            {
                for (var j = i + 1; j < Count; j++)
                {
                    var leftItem = (T)list[i];
                    var rightItem = (T)list[j];
                    if (comparerDelegate(leftItem, rightItem) > 0)
                    {
                        var temp = leftItem;
                        list[i] = list[j];
                        list[j] = temp;
                    }
                }
            }
        }

       

        public void Print()
        {
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            return this;
        }

        public void Dispose()
        {
            
        }
    }

    public interface IItemSpecification<T>
    {
        bool SatisfiedBy(T item);
    }

    //the following can be replaced with the Func delegate
    /*
    public delegate int KeySelector<T>(T item);
    public delegate bool ItemPredicate<T>(T item);
    public delegate decimal DecDelegate<T>(T Item);
    public delegate long LongDelegate<T>(T Item);
    */
   

    /*
    public class ProductSpecificationByCategory : ISpecification<Product>
    {
        private string category;

        public ProductSpecificationByCategory(string category)
        {
            this.category = category;
        }
        public bool SatisfiedBy(Product product)
        {
            return product.Category == category;
        }
    }
    */

    public interface IItemComparer<T>
    {
        int Compare(T leftItem, T rightItem);
    }

    public delegate int ItemComparerDelegate<T>(T leftItem, T rightItem);

    /*
    class ProductsComparerById : IProductComparer
    {
        public int Compare(Product leftProduct, Product rightProduct)
        {
            if (leftProduct.Id > rightProduct.Id) return 1;
            if (leftProduct.Id < rightProduct.Id) return -1;
            return 0;
        }
    }
    

    class ProductsComparerByUnits : IProductComparer
    {
        public int Compare(Product leftProduct, Product rightProduct)
        {
            if (leftProduct.Units > rightProduct.Units) return 1;
            if (leftProduct.Units < rightProduct.Units) return -1;
            return 0;
        }
    }
    class ProductsComparerByUnitCost : IProductComparer
    {
        public int Compare(Product leftProduct, Product rightProduct)
        {
            if (leftProduct.UnitCost > rightProduct.UnitCost) return 1;
            if (leftProduct.UnitCost < rightProduct.UnitCost) return -1;
            return 0;
        }
    }
    */
}
