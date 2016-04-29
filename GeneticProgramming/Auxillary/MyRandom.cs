using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticProgramming.Auxillary
{
    public interface IRandom
    {
        int Next(int maxValue);
    }

    class MyRandom : IRandom
    {
        private Random random = new Random(Guid.NewGuid().GetHashCode());

        public int Next(int maxValue)
        {
            return random.Next(maxValue);
        }
    }
}
