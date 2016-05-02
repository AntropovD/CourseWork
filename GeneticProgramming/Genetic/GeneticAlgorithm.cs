using GeneticProgramming.Genetic.GeneticEngine;
using GeneticProgramming.NInject;
using Ninject;
using NLog;

namespace GeneticProgramming.Genetic
{
    public class GeneticAlgorithm
    {
        public static IKernel AppKernel;
        public GeneticConfiguration GeneticConfiguration { get; private set; }
        //public GeneticPopulation GeneticPopulation { get; private set; }
        //public IGeneticEngine GeneticEngine { get; private set; }

        public Logger logger = LogManager.GetCurrentClassLogger();
        public GeneticAlgorithm(GeneticConfiguration configuration)
        {
          //  GeneticPopulation = new GeneticPopulation(configuration);
            AppKernel = new StandardKernel(new BindingModule());
            var logger = LogManager.GetCurrentClassLogger();
        }

        public void Run()
        {
          //  logger.Info("Start Genetic Programming");
        }
    }
}
