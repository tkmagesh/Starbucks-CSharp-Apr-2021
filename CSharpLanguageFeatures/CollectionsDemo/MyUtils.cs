using System;
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
            //allProps.Aggregate((res, prop) => result += $"{prop.Name}={prop.GetValue(o)}\t", result)

            foreach(var propInfo in allProps)
            {
                var propName = propInfo.Name;
                var propValue = propInfo.GetValue(o);
                result += $"{propName}={propValue}\t";
            }
            return result;
        }

    }
}
