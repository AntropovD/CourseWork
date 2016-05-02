using System;

namespace GeneticProgramming.Randomizer
{
    public interface IRandom
    {
        int Next(int maxValue);
    }

    public class GuidRandom : IRandom
    {
        private Random random;

        public GuidRandom()
        {
            random = new Random(Guid.NewGuid().GetHashCode());
        }

        public int Next(int maxValue)
        {
            return random.Next(maxValue);
        }
    }
}
