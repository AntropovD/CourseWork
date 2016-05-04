using System.Collections.Generic;
using System.Linq;
using GeneticProgramming.Genetic;
using GeneticProgramming.Genetic.Methods;
using GeneticProgramming.Tank;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.GeneticTests
{
    [TestClass]
    public class CrossoverMethods_Tests
    {
        private readonly GeneticConfiguration configuration = ConfigurationFactory.GetConfigForTesting();
        private CrossoverMethods crossoverMethods;

        [TestInitialize]
        public void TestInitialize()
        {
            crossoverMethods = new CrossoverMethods(configuration);
        }
        
        [TestMethod]
        public void CrossoverSpecies_should_not_overtop_maxAlgorithms_size()
        {
            var algo1 = new TankStrategy(Enumerable.Range(0, configuration.MaxStrategySize).Select(i => Command.MoveForward));
            var algo2 = new TankStrategy(Enumerable.Range(0, configuration.MaxStrategySize).Select(i => Command.Shoot));
            var result = algo1.Crossover(algo2, configuration.MaxStrategySize);
            Assert.IsTrue(result.commands.Count < configuration.MaxStrategySize);
        }

    }
}
