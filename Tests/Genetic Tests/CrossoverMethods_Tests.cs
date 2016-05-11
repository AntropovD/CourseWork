using System.Linq;
using GeneticProgramming.Configurations;
using GeneticProgramming.Genetic;
using GeneticProgramming.Genetic.Methods;
using GeneticProgramming.Simulator;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Genetic_Tests
{
    [TestClass]
    public class CrossoverMethods_Tests
    {
        private readonly GeneticConfig _config = ConfigurationFactory.Configuration.GeneticConfig;
        private Crossover crossover;

        [TestInitialize]
        public void TestInitialize()
        {
            crossover = new Crossover(_config);
        }
        
        [TestMethod]
        public void CrossoverSpecies_should_not_overtop_maxAlgorithms_size()
        {
            var algo1 = new Strategy(Enumerable.Range(0, _config.MaxStrategyLength).Select(i => "Forward"));
            var algo2 = new Strategy(Enumerable.Range(0, _config.MaxStrategyLength).Select(i => "Shoot"));
            var result = algo1.Crossover(algo2, _config.MaxStrategyLength);
            Assert.IsTrue(result.commands.Count < _config.MaxStrategyLength);
        }
    }
}
