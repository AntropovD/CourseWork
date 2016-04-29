using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeneticProgramming.Panzer;

namespace GeneticProgramming.Genetic
{
    public class GeneticAlgorithm
    {
        public Population Population { get; private set; }
        //public Func<int, PanzerAlgorithm> FitnessFunction { get; private set; }

        public GeneticAlgorithm(GeneticConfiguration configuration, Func<int, PanzerAlgorithm> fitnessFunc)
        {
            Population = new Population(configuration);
          //  FitnessFunction = fitnessFunc;
        }
    }
}
