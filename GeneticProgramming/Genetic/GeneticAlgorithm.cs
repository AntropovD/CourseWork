using System.Collections.Generic;
using GeneticProgramming.Genetic.GeneticEngine;
using GeneticProgramming.Tank;
using log4net;

namespace GeneticProgramming.Genetic
{
    public class GeneticAlgorithm
    {
        private readonly GeneticConfiguration configuration;
        private readonly IGeneticEngine GeneticEngine;
        private static readonly ILog log =
            LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public GeneticAlgorithm(GeneticConfiguration configuration)
        {
            this.configuration = configuration;
            GeneticEngine = new BaseGeneticEngine(configuration);
        }

        public void Run()
        {
            log.Info("Genetic Programming Started");
            
            var population =  new Population(configuration.PopulationSize, configuration.MaxStrategySize);
            population.Initiate();
             
           
            int index = 0;
            while (true)
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
