using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using GeneticProgramming.Configurations;
using GeneticProgramming.Genetic.GeneticEngine;
using GeneticProgramming.Simulator.Tanks;
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
            geneticEngine = new BaseGeneticEngine(configuration.GeneticConfig);
        }

        public void Run()
        {
            log.Info("Genetic Programming Started");
            population = new Population(configuration.GeneticConfig);
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
            var selectedStrategies = geneticEngine.SelectPoplulation(nextGenerationStrategies);
            population = population.UpdatePopulation(selectedStrategies);
            population.LogInfo(index);
            population.LogAllStrategies(index);
            index++;
        }

        private List<Strategy> GetNextGenerationStrategies()
        {
            var strategies = population.GetStrategies();
            var offsping = geneticEngine.CrossoverPopulation(strategies);
            var mutated = geneticEngine.MutatePopulation(strategies);
            return strategies.Concat(offsping).Concat(mutated).Distinct().ToList();
        }
    }
}
