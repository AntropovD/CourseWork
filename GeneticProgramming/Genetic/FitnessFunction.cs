using System;
using GeneticProgramming.Tank;

namespace GeneticProgramming.Genetic
{
    public class FitnessFunction
    {
        public int countValue(TankStrategy tankStrategy)
        {
            return new Random(Guid.NewGuid().GetHashCode()).Next();
        }
    }
}
