using System.Collections.Generic;
using GeneticProgramming.Configurations;
using GeneticProgramming.Genetic.Engine.Types;
using GeneticProgramming.Genetic.Methods;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Simulator_Tests.Strategy_Tests
{
    [TestClass]
    public class StrategyExtensions_Tests
    {
        private readonly Configuration config = ConfigurationFactory.Configuration;
        private Crossover crossover;

        [TestInitialize]
        public void TestInitialize()
        {
            crossover = new Crossover(config.GeneticConfig, config.StrategyConfig);
        }
        
        [TestMethod]
        public void FindMostLikely_on_3_algos_should_return_algo_with_1_difference()
        {
            var algo1 = new GeneticProgramming.Simulator.Strategies.Strategy(new List<string> { "Backward", "Backward", "Shoot" });
            var algo2 = new GeneticProgramming.Simulator.Strategies.Strategy(new List<string> { "Backward", "Backward", "Stay" });
            var algo3 = new GeneticProgramming.Simulator.Strategies.Strategy(new List<string> { "TurnLeft", "TurnLeft", "TurnLeft" });
            
            var result = algo1.FindMostLikely(new List<GeneticProgramming.Simulator.Strategies.Strategy> { algo1, algo2, algo3 });

            CollectionAssert.AreEqual(algo2.commands, result.commands);
        }
        
        [TestMethod]
        public void FincMostUnlikely_on_3_algos_should_return_algo_with_3_diffeence()
        {
            var algo1 = new GeneticProgramming.Simulator.Strategies.Strategy(new List<string> { "Backward", "Backward", "Shoot" });
            var algo2 = new GeneticProgramming.Simulator.Strategies.Strategy(new List<string> { "Backward", "Backward", "Stay" });
            var algo3 = new GeneticProgramming.Simulator.Strategies.Strategy(new List<string> { "TurnLeft", "TurnLeft", "TurnLeft" });
            var result = algo2.FindMostUnlikely(new List<GeneticProgramming.Simulator.Strategies.Strategy> { algo1, algo2, algo3 });

            CollectionAssert.AreEqual(algo3.commands, result.commands);
        }

        [TestMethod]
        public void HammingDistance_On_Equal_algos_size_3_should_return_3()
        {
            var algo1 = new GeneticProgramming.Simulator.Strategies.Strategy(new List<string> { "Backward", "Shoot", "Forward" });
            var algo2 = new GeneticProgramming.Simulator.Strategies.Strategy(new List<string> { "Backward", "Shoot", "Forward" });
            var result = StrategyGeneticExtensions.HammingDistance(algo1, algo2);
            Assert.AreEqual(3, result);
        }

        [TestMethod]
        public void HammingDistance_On_algos_size_3_with_1_difference_should_return_2()
        {
            var algo1 = new GeneticProgramming.Simulator.Strategies.Strategy(new List<string> { "Backward", "Shoot", "Forward" });
            var algo2 = new GeneticProgramming.Simulator.Strategies.Strategy(new List<string> { "Backward", "Stay", "Forward" });
            var result = StrategyGeneticExtensions.HammingDistance(algo1, algo2);
            Assert.AreEqual(2, result);
        }

        [TestMethod]
        public void HammingDistance_On_different_algos_size_2_should_return_0()
        {
            var algo1 = new GeneticProgramming.Simulator.Strategies.Strategy(new List<string> { "Backward", "Shoot" });
            var algo2 = new GeneticProgramming.Simulator.Strategies.Strategy(new List<string> { "Stay", "Forward" });
            var result = StrategyGeneticExtensions.HammingDistance(algo1, algo2);
            Assert.AreEqual(0, result);
        }
    }
}
