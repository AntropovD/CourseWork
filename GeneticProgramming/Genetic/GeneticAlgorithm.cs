using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using GeneticProgramming.Configurations;
using GeneticProgramming.Genetic.Engine;
using GeneticProgramming.Simulator.Strategies;
using log4net;

namespace GeneticProgramming.Genetic
{
    public class GeneticAlgorithm
    {
        private Population population;
        private readonly Configuration configuration;
        private readonly IGeneticEngine geneticEngine;
        private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public GeneticAlgorithm(Configuration configuration)
        {
            this.configuration = configuration;
            geneticEngine = new GeneticEngine(configuration.GeneticConfig, configuration.StrategyConfig);
        }

        public void Run()
        {
            log.Info("Genetic Programming Started");
            population = new Population(configuration);
            int index = 0;
            while (!Console.KeyAvailable)
            {
                MakeNextGeneration(ref index);
                if (population.HasAnyFinished() || index == 30)
                    return;
            }
        }

        private void MakeNextGeneration(ref int index)
        {
            var nextGenerationStrategies = GetNextGenerationStrategies();
            population.UpdateStrategies(nextGenerationStrategies);
            population = geneticEngine.SelectPopulation(population);
        
            population.LogInfo(index);
            population.LogAllStrategies(index);
            index++;
        }

        private List<Strategy> GetNextGenerationStrategies()
        {
            var strategies = population.GetStrategies();
            var offsping = geneticEngine.CrossoverStrategies(strategies);
            var mutated = geneticEngine.MutateStrategies(strategies);
            return strategies.Concat(offsping).Concat(mutated).Distinct().ToList();
        }
    }
}
