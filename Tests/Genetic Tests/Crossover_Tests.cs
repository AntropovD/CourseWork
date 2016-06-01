using System.Collections.Generic;
using System.Linq;
using GeneticProgramming.Configurations.PartialConfigs;
using GeneticProgramming.Genetic.Engine.Types;
using GeneticProgramming.Genetic.Methods;
using GeneticProgramming.Simulator.Strategies;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Genetic_Tests
{
    [TestClass]
    public class Crossover_Tests
    {
        private readonly GeneticConfig config= ConfigurationFactory.Configuration.GeneticConfig;
        private Crossover crossover;
        private StrategiesGenerator StrategiesGenerator;

        [TestInitialize]
        public void TestInitialize()
        {
            crossover = new Crossover(config);
            StrategiesGenerator = new StrategiesGenerator(100);
        }
        
        [TestMethod]
        public void CrossoverSpecies_should_not_overtop_maxAlgorithms_size()
        {
            var algo1 = new Strategy(Enumerable.
                Range(0, config.MaxStrategySize)
                .Select(i => "Forward").ToList());
            var algo2 = new Strategy(Enumerable.
                Range(0, config.MaxStrategySize)
                .Select(i => "Shoot").ToList());
            var result = StrategyCrossoverMethods.Crossover(algo1, algo2, config.MaxStrategySize);
            Assert.IsTrue(result.commands.Count < config.MaxStrategySize);
        }

        [TestMethod]
        public void CrossoverSpecies_should_return_valid_strategy()
        {
            var algo1 = new Strategy(Enumerable.
                Range(0, config.MaxStrategySize)
                .Select(i => "Forward").ToList());
            var algo2 = new Strategy(Enumerable.
                Range(0, config.MaxStrategySize)
                .Select(i => "Shoot").ToList());
            var result = StrategyCrossoverMethods.Crossover(algo1, algo2, config.MaxStrategySize);
            Assert.IsTrue(StrategiesGenerator.CheckProgram(result.commands));
        }

        [TestMethod]
        public void GetPanmixia_returns_valid_strategy()
        {
            var initialStrategies = new List<Strategy>();
            for (int i = 0; i < config.PopulationSize; i++)
                initialStrategies.Add(StrategiesGenerator.GenerateProgram());

            var strategies = crossover.GetPanmixia(initialStrategies);
            foreach (var strategy in strategies)
            {
                Assert.IsTrue(StrategiesGenerator.CheckProgram(strategy.commands));
            }
        }

        [TestMethod]
        public void GetInbreed_returns_valid_strategy()
        {
            var initialStrategies = new List<Strategy>();
            for (int i = 0; i < config.PopulationSize; i++)
                initialStrategies.Add(StrategiesGenerator.GenerateProgram());

            var strategies = crossover.GetInbreed(initialStrategies);
            foreach (var strategy in strategies)
            {
                Assert.IsTrue(StrategiesGenerator.CheckProgram(strategy.commands));
            }
        }

        [TestMethod]
        public void GetOutbreed_returns_valid_strategy()
        {
            var initialStrategies = new List<Strategy>();
            for (int i = 0; i < config.PopulationSize; i++)
                initialStrategies.Add(StrategiesGenerator.GenerateProgram());

            var strategies = crossover.GetOutbreed(initialStrategies);
            foreach (var strategy in strategies)
            {
                Assert.IsTrue(StrategiesGenerator.CheckProgram(strategy.commands));
            }
        }
    }
}
