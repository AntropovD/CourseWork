
using log4net;

namespace GeneticProgramming.Genetic
{
    public class GeneticAlgorithm
    {
        private GeneticConfiguration configuration;

        
        //public IGeneticEngine GeneticEngine { get; private set; }

        private static readonly ILog log =
            LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public GeneticAlgorithm(GeneticConfiguration configuration)
        {
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
