using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeneticProgramming.Panzer;

namespace GeneticProgramming.Genetic
{
    internal class BaseGeneticEngine : IGeneticEngine
    {
        public int FitnessFunction(PanzerAlgorithm panzerAlgorithm)
        {
            throw new NotImplementedException();
        }

        public Population CrossPopulation(Population population)
        {
            throw new NotImplementedException();
        }

        public Population MutatePopulation(Population population)
        {
            throw new NotImplementedException();
        }

        public Population SelectPopulation(Population population)
        {
            throw new NotImplementedException();
        }
    }
}
