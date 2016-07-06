using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using GeneticProgramming.Configurations;
using GeneticProgramming.Extensions;
using GeneticProgramming.Genetic.Engine;
using GeneticProgramming.Simulator.Strategies;
using log4net.Repository.Hierarchy;

namespace GeneticProgramming.Genetic
{
    public class GeneticAlgorithm
    {
        private Population population;
        private readonly Configuration configuration;
        private readonly IGeneticEngine geneticEngine;
        private GeneticLogger logger;

        public GeneticAlgorithm(Configuration configuration)
        {
            this.configuration = configuration;
            geneticEngine = new GeneticEngine(configuration.GeneticConfig);
            logger = new GeneticLogger();
        }

        public void Run()
        {
            logger.Start();
            population = new Population(configuration);
            logger.InitiateMessage();
            while (true)
            {
                MakeNextGeneration();
//                if (population.HasAnyFinished())
//                    return;
            }
        }

        public Population RunAndGetPopulation()
        {
            logger.Start();
            population = new Population(configuration);
            logger.InitiateMessage();
            var sw = new Stopwatch();
            sw.Start();
            while (true)
            {
                MakeNextGeneration();
                if (population.HasAnyFinished())
                    return population;
                if (sw.ElapsedMilliseconds > 1000 * 60 * 5)
                    return population;
            }
        }

        private void MakeNextGeneration()
        {
            var nextGenerationStrategies = GetNextGenerationStrategies();
            if (!nextGenerationStrategies.Any(strategy => StrategiesGenerator.CheckProgram(strategy.commands)))
            {
                throw new Exception("Wrong strategy!");
            }
            population.UpdateStrategies(nextGenerationStrategies);
            population = geneticEngine.SelectPopulation(population);

            logger.LogGeneration(population);
            population.IncreaseIndex();
        }

        private List<Strategy> GetNextGenerationStrategies()
        {
            var strategies = population.GetStrategies();
            var offsping = geneticEngine.CrossoverStrategies(strategies);
            var mutated = geneticEngine.MutateStrategies(strategies);
            return strategies.Concat(offsping).Concat(mutated).ToList();
        }
    }
}
