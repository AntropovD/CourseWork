using System.Linq;

namespace GeneticProgramming.Extensions
{
    static class MathExtension
    {
        public static double GetMedian(int[] values)
        {
            var sorted = values.OrderBy(x => x).ToList();
            double mid = (sorted.Count - 1) / 2.0;
            return (sorted[(int)(mid)] + sorted[(int)(mid + 0.5)]) / 2.0;
        }
    }
}
