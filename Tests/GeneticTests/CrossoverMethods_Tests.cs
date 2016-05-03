using System.Collections.Generic;
using System.Linq;
using GeneticProgramming.Genetic;
using GeneticProgramming.Genetic.GeneticEngine;
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
        public void FindMostLikely_on_3_algos_should_return_algo_with_1_difference()
        {
            var algo1 = new TankStrategy(new List<Command> {Command.MoveBackward, Command.MoveBackward, Command.Shoot});
            var algo2 = new TankStrategy(new List<Command> {Command.MoveBackward, Command.MoveBackward, Command.Stay});
            var algo3 = new TankStrategy(new List<Command> {Command.TurnLeft, Command.TurnLeft, Command.TurnLeft});
            var result = algo1.FindMostLikely(new List<TankStrategy> { algo1, algo2, algo3 });

            CollectionAssert.AreEqual(algo2.commands, result.commands);
        }

        [TestMethod]
        public void FincMostUnlikely_on_3_algos_should_return_algo_with_3_diffeence()
        {
            var algo1 = new TankStrategy(new List<Command> { Command.MoveBackward, Command.MoveBackward, Command.Shoot });
            var algo2 = new TankStrategy(new List<Command> { Command.MoveBackward, Command.MoveBackward, Command.Stay });
            var algo3 = new TankStrategy(new List<Command> { Command.TurnLeft, Command.TurnLeft, Command.TurnLeft });
            var result = algo2.FindMostUnlikely(new List<TankStrategy> { algo1, algo2, algo3 });

            CollectionAssert.AreEqual(algo3.commands, result.commands);
        }

        [TestMethod]
        public void CrossoverSpecies_should_not_overtop_maxAlgorithms_size()
        {
            var algo1 = new TankStrategy(Enumerable.Range(0, configuration.MaxStrategySize).Select(i => Command.MoveForward));
            var algo2 = new TankStrategy(Enumerable.Range(0, configuration.MaxStrategySize).Select(i => Command.Shoot));
            var result = algo1.Crossover(algo2, configuration.MaxStrategySize);
            Assert.IsTrue(result.commands.Count < configuration.MaxStrategySize);
        }

        [TestMethod]
        public void HammingDistance_On_Equal_algos_size_3_should_return_3()
        {
            var algo1 = new TankStrategy(new List<Command> { Command.MoveBackward, Command.Shoot, Command.MoveForward });
            var algo2 = new TankStrategy(new List<Command> { Command.MoveBackward, Command.Shoot, Command.MoveForward });
            var result = algo1.HammingDistance(algo2);
            Assert.AreEqual(3, result);
        }

        [TestMethod]
        public void HammingDistance_On_algos_size_3_with_1_difference_should_return_2()
        {
            var algo1 = new TankStrategy(new List<Command> { Command.MoveBackward, Command.Shoot, Command.MoveForward });
            var algo2 = new TankStrategy(new List<Command> { Command.MoveBackward, Command.Stay, Command.MoveForward });
            var result = algo1.HammingDistance(algo2);
            Assert.AreEqual(2, result);
        }

        [TestMethod]
        public void HammingDistance_On_different_algos_size_2_should_return_0()
        {
            var algo1 = new TankStrategy(new List<Command> { Command.MoveBackward, Command.Shoot });
            var algo2 = new TankStrategy(new List<Command> { Command.Stay, Command.MoveForward });
            var result = algo1.HammingDistance(algo2);
            Assert.AreEqual(0, result);
        }
    }
}
