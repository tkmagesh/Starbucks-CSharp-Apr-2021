using System;
using System.Collections;

namespace CollectionsDemo
{
    public class Products : IEnumerable, IEnumerator
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

        public void Add(Product product)
        {
            list.Add(product);
        }

        public Product this[int index]
        {
            get
            {
                return (Product)list[index];
            }
        }

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

        public void Remove(Product product)
        {
            list.Remove(product);
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

        public void Sort(IProductComparer comparer)
        {
            for (var i = 0; i < Count - 1; i++)
            {
                for (var j = i + 1; j < Count; j++)
                {
                    var leftProduct = (Product)list[i];
                    var rightProduct = (Product)list[j];
                    if (comparer.Compare(leftProduct, rightProduct) > 0)
                    {
                        var temp = leftProduct;
                        list[i] = list[j];
                        list[j] = temp;
                    }
                }
            }
        }

        public void Sort(ProductComparerDelegate comparerDelegate)
        {
            for (var i = 0; i < Count - 1; i++)
            {
                for (var j = i + 1; j < Count; j++)
                {
                    var leftProduct = (Product)list[i];
                    var rightProduct = (Product)list[j];
                    if (comparerDelegate(leftProduct, rightProduct) > 0)
                    {
                        var temp = leftProduct;
                        list[i] = list[j];
                        list[j] = temp;
                    }
                }
            }
        }

        public Products Filter(IProductSpecification specification)
        {
            var result = new Products();
            foreach (var item in list)
            {
                var product = (Product)item;
                if (specification.SatisfiedBy(product))
                {
                    result.Add(product);
                }
            }
            return result;
        }

        public Products Filter(ProductPredicate productPredicate)
        {
            var result = new Products();
            foreach (var item in list)
            {
                var product = (Product)item;
                if (productPredicate(product))
                {
                    result.Add(product);
                }
            }
            return result;
        }



    }

    public interface IProductSpecification
    {
        bool SatisfiedBy(Product product);
    }

    public delegate bool ProductPredicate(Product product);

    public class ProductSpecificationByCategory : IProductSpecification
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
    public interface IProductComparer
    {
        int Compare(Product leftProduct, Product rightProduct);
    }

    public delegate int ProductComparerDelegate(Product leftProduct, Product rightProduct);

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
    /*
    class ProductsComparer
    {
        public bool Compare(Product leftProduct, Product rightProduct, string attrName)
        {
            switch (attrName)
            {
                case "Id":
                    return leftProduct.Id > rightProduct.Id;
                    
                case "Units":
                    return leftProduct.Units > rightProduct.Units;
                    
                case "UnitCost":
                    return leftProduct.UnitCost > rightProduct.UnitCost;
                    
                case "Name":
                    return leftProduct.Name.CompareTo(rightProduct.Name) > 0;
                    
                case "Category":
                    return leftProduct.Category.CompareTo(rightProduct.Category) > 0;
                default:
                    return false;
            }
        }
    }
    */
}
