using System;
using System.Collections.Generic;
using System.Linq;
namespace CollectionsDemo
{
    public static class MyUtils
    {
        public static void WhoAmI(this Customer customer)
        {
            Console.WriteLine("I am a customer!");
        }

        public static void WhoAmI(this string str)
        {
            Console.WriteLine("I am a string!");
        }

        public static string FormatForConsole(this IFormattable o)
        {
            var objType = o.GetType();
            var result = $"[{objType.Name}] - ";
            var allProps = objType.GetProperties();
            foreach(var propInfo in allProps)
            {
                var propName = propInfo.Name;
                var propValue = propInfo.GetValue(o);
                result += $"{propName}={propValue}\t";
            }
            return result;
        }

        public static IEnumerable<T> Filter<T>(this IEnumerable<T> list, IItemSpecification<T> specification)
        {
            foreach (var item in list)
            {
                var tItem = (T)item;
                if (specification.SatisfiedBy(tItem))
                {
                    yield return tItem;
                }
            }
            
        }

        public static IEnumerable<T> Filter<T>(this IEnumerable<T> list, Func<T,bool> itemPredicate)
        {

            foreach (var item in list)
            {
                var tItem = (T)item;
                if (itemPredicate(tItem))
                {
                    yield return tItem;
                }
            }
        }
        
        public static T First<T>(this IEnumerable<T> list, Func<T, bool> itemPredicate)
        {
            foreach (var item in list)
            {
                var tItem = (T)item;
                if (itemPredicate(tItem))
                {
                    return tItem;
                }
            }
            return default(T);
        }

        public static int Max<T>(this IEnumerable<T> list, Func<T, int> keySelector)
        {
            var result = 0;
            foreach (var item in list)
            {
                var tItem = (T)item;
                var value = keySelector(tItem);
                result = value > result ? value : result;
            }
            return result;
        }

        public static 

    }
}
