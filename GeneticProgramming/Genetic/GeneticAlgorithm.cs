using GeneticProgramming.Genetic.GeneticEngine;
using GeneticProgramming.NInject;
using log4net;
using Ninject;

namespace GeneticProgramming.Genetic
{
    public class GeneticAlgorithm
    {
        public static IKernel AppKernel;
        private GeneticConfiguration configuration;

        
        //public IGeneticEngine GeneticEngine { get; private set; }

        private static readonly ILog log =
            LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public GeneticAlgorithm(GeneticConfiguration configuration)
        {
            AppKernel = new StandardKernel(new BindingModule());
            this.configuration = configuration;
        }

        public void Run()
        {
            log.Info("Genetic Programming Started");

            var population = new GeneticPopulation(configuration);

            while (true)
            {
                
            }
        }
    }
}
