using GeneticProgramming.Genetic.GeneticEngine;
using GeneticProgramming.NInject;
using Ninject;

namespace GeneticProgramming.Genetic
{
    public class GeneticAlgorithm
    {
        public static IKernel AppKernel;
        public GeneticConfiguration GeneticConfiguration { get; private set; }
        public GeneticPopulation GeneticPopulation { get; private set; }
        public IGeneticEngine GeneticEngine { get; private set; }

        public GeneticAlgorithm(GeneticConfiguration configuration)
        {
            GeneticPopulation = new GeneticPopulation(configuration);
            AppKernel = new StandardKernel(new BindingModule());
        }

        public void Run()
        {
            
        }
    }
}
