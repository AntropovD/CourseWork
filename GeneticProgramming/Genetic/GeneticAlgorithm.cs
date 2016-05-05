using System;
using GeneticProgramming.Configurations;
using GeneticProgramming.Genetic.GeneticEngine;
using log4net;

namespace GeneticProgramming.Genetic
{
    public class GeneticAlgorithm
    {
        private readonly IGeneticEngine GeneticEngine;
        private static readonly ILog log =
            LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private Configuration configuration;

        public GeneticAlgorithm(Configuration configuration)
        {
            this.configuration = configuration;
            GeneticEngine = new BaseGeneticEngine(configuration.GeneticConfig);
        }

        public void Run()
        {
            log.Info("Genetic Programming Started");
            
            var population =  new Population(configuration.GeneticConfig.PopulationSize, 
                                            configuration.GeneticConfig.MaxStrategySize);
            population.Initiate();

            int index = 0;
            while (! Console.KeyAvailable)
            {
                var strategies = population.GetStrategies();

                var offsping = GeneticEngine.CrossoverPopulation(strategies);
                var mutated = GeneticEngine.MutatePopulation(strategies);

                population.UpdatePopulation(offsping);
                population.UpdatePopulation(mutated);

                population.SelectPopulation();
                population.LogInfo();
                log.Info($"Generation #{index}");
                index++;
            }
        }
 
    }
}
