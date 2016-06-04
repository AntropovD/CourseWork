﻿using System;
using System.Collections.Generic;
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
            var index = 1;
            while (true)
            {
                MakeNextGeneration(ref index);
                if (population.HasAnyFinished())
                    return;
            }
        }

        private void MakeNextGeneration(ref int index)
        {
            var nextGenerationStrategies = GetNextGenerationStrategies();
            if (!nextGenerationStrategies.Any(strategy => StrategiesGenerator.CheckProgram(strategy.commands)))
            {
                throw new Exception("Wrong strategy!");
            }
            population.UpdateStrategies(nextGenerationStrategies);
            population = geneticEngine.SelectPopulation(population);

            logger.LogGeneration(population, index);
            index++;
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
