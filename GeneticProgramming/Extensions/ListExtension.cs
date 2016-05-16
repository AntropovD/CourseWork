using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;

namespace GeneticProgramming.Extensions
{
    public static class ListExtension
    {
        public static List<T> TakeRange<T>(this List<T> list, int count)
        {
            var result = list.Take(count).ToList();
            list.RemoveRange(0, count);
            return result;
        }

        public static T FirstAndRemove<T>(this List<T> list)
        {
            var result = list[0];
            list.RemoveAt(0);
            return result;
        }
    }
}
