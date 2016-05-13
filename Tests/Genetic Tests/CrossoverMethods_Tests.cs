using System.Linq;
using GeneticProgramming.Configurations;
using GeneticProgramming.Genetic.Engine.Types;
using GeneticProgramming.Genetic.Methods;
using GeneticProgramming.Simulator.Strategies;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Genetic_Tests
{
    [TestClass]
    public class CrossoverMethods_Tests
    {
        private readonly Configuration configuration = ConfigurationFactory.Configuration;
        private Crossover crossover;

        [TestInitialize]
        public void TestInitialize()
        {
            crossover = new Crossover(configuration.GeneticConfig, configuration.StrategyConfig);
        }
        
        [TestMethod]
        public void CrossoverSpecies_should_not_overtop_maxAlgorithms_size()
        {
            var algo1 = new Strategy(Enumerable.
                Range(0, configuration.StrategyConfig.MaxStrategySize)
                .Select(i => "Forward").ToList());
            var algo2 = new Strategy(Enumerable.
                Range(0, configuration.StrategyConfig.MaxStrategySize)
                .Select(i => "Shoot").ToList());
            var result = StrategyCrossoverMethods.Crossover(algo1, algo2, configuration.StrategyConfig.MaxStrategySize);
            Assert.IsTrue(result.commands.Count < configuration.StrategyConfig.MaxStrategySize);
        }
    }
}
