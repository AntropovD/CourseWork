using System;
using GeneticProgramming.Genetic.GeneticEngine;
using log4net;

namespace GeneticProgramming.Genetic
{
    public class GeneticAlgorithm
    {
        private readonly GeneticConfig _config;
        private readonly IGeneticEngine GeneticEngine;
        private static readonly ILog log =
            LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public GeneticAlgorithm(GeneticConfig _config)
        {
            this._config = _config;
            GeneticEngine = new BaseGeneticEngine(_config);
        }

        public void Run()
        {
            log.Info("Genetic Programming Started");
            
            var population =  new Population(_config.PopulationSize, _config.MaxStrategySize);
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
