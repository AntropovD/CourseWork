using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticProgramming.Genetic
{
    public class GeneticConfiguration
    {
        public int InitialPopulationSize = 32;
        public int MaximumPopulationSize = 128;
        public int MaximumProgramSize = 1024;

        public double CrossoverProb = 0.90;
        public double MutationProb = 0.05;
    }
}
