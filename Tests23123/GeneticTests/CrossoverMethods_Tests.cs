using System.Collections.Generic;
using System.Linq;
using GeneticProgramming.Genetic;
using GeneticProgramming.Genetic.Methods;
using GeneticProgramming.Simulator.Tank;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.GeneticTests
{
    [TestClass]
    public class CrossoverMethods_Tests
    {
        private readonly GeneticConfig _config = ConfigurationFactory.GetConfigForTesting();
        private CrossoverMethods crossoverMethods;

        [TestInitialize]
        public void TestInitialize()
        {
            crossoverMethods = new CrossoverMethods(_config);
        }
        
        [TestMethod]
        public void CrossoverSpecies_should_not_overtop_maxAlgorithms_size()
        {
            var algo1 = new TankStrategy(Enumerable.Range(0, _config.MaxStrategySize).Select(i => Command.MoveForward));
            var algo2 = new TankStrategy(Enumerable.Range(0, _config.MaxStrategySize).Select(i => Command.Shoot));
            var result = algo1.Crossover(algo2, _config.MaxStrategySize);
            Assert.IsTrue(result.commands.Count < _config.MaxStrategySize);
        }

    }
}
