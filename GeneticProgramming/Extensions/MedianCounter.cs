using System.Linq;

namespace GeneticProgramming.Extensions
{
    public static class MedianCounter
    {
        public static double GetMedian(int[] values)
        {
            var sorted = values.OrderBy(x => x).ToList();
            var mid = (sorted.Count - 1) / 2.0;
            return (sorted[(int)(mid)] + sorted[(int)(mid + 0.5)]) / 2.0;
        }
    }
}
