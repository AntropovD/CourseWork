﻿using GeneticProgramming.Configurations;
using GeneticProgramming.Genetic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Genetic_Tests
{
    [TestClass]
    public class CrossoverMethods_Tests
    {
        private readonly GeneticConfig _config = ConfigurationFactory.Configuration.GeneticConfig;
        private CrossoverMethods crossoverMethods;

        [TestInitialize]
        public void TestInitialize()
        {
            crossoverMethods = new CrossoverMethods(_config);
        }
        /*
        [TestMethod]
        public void CrossoverSpecies_should_not_overtop_maxAlgorithms_size()
        {
            var algo1 = new TankStrategy(Enumerable.Range(0, _config.MaxStrategyLength).Select(i => string.Forward));
            var algo2 = new TankStrategy(Enumerable.Range(0, _config.MaxStrategyLength).Select(i => string.Shoot));
            var result = algo1.Crossover(algo2, _config.MaxStrategyLength);
            Assert.IsTrue(result.commands.Count < _config.MaxStrategyLength);
        }*/
    }
}