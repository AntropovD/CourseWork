﻿using System.Collections.Generic;
using GeneticProgramming;
using GeneticProgramming.Configurations;
using GeneticProgramming.Genetic.Methods;
using GeneticProgramming.Simulator.Tanks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.TankTests
{
    [TestClass]
    public class TankStrategy_Tests
    {
        private readonly GeneticConfig _config = ConfigurationFactory.Configuration.GeneticConfig;
        private CrossoverMethods crossoverMethods;

        [TestInitialize]
        public void TestInitialize()
        {
            crossoverMethods = new CrossoverMethods(_config);
        }

        [TestMethod]
        public void FindMostLikely_on_3_algos_should_return_algo_with_1_difference()
        {
            var algo1 = new TankStrategy(new List<Command> { Command.Backward, Command.Backward, Command.Shoot });
            var algo2 = new TankStrategy(new List<Command> { Command.Backward, Command.Backward, Command.Stay });
            var algo3 = new TankStrategy(new List<Command> { Command.TurnLeft, Command.TurnLeft, Command.TurnLeft });
            var result = algo1.FindMostLikely(new List<TankStrategy> { algo1, algo2, algo3 });

            CollectionAssert.AreEqual(algo2.commands, result.commands);
        }

        [TestMethod]
        public void FincMostUnlikely_on_3_algos_should_return_algo_with_3_diffeence()
        {
            var algo1 = new TankStrategy(new List<Command> { Command.Backward, Command.Backward, Command.Shoot });
            var algo2 = new TankStrategy(new List<Command> { Command.Backward, Command.Backward, Command.Stay });
            var algo3 = new TankStrategy(new List<Command> { Command.TurnLeft, Command.TurnLeft, Command.TurnLeft });
            var result = algo2.FindMostUnlikely(new List<TankStrategy> { algo1, algo2, algo3 });

            CollectionAssert.AreEqual(algo3.commands, result.commands);
        }


        [TestMethod]
        public void HammingDistance_On_Equal_algos_size_3_should_return_3()
        {
            var algo1 = new TankStrategy(new List<Command> { Command.Backward, Command.Shoot, Command.Forward });
            var algo2 = new TankStrategy(new List<Command> { Command.Backward, Command.Shoot, Command.Forward });
            var result = algo1.HammingDistance(algo2);
            Assert.AreEqual(3, result);
        }

        [TestMethod]
        public void HammingDistance_On_algos_size_3_with_1_difference_should_return_2()
        {
            var algo1 = new TankStrategy(new List<Command> { Command.Backward, Command.Shoot, Command.Forward });
            var algo2 = new TankStrategy(new List<Command> { Command.Backward, Command.Stay, Command.Forward });
            var result = algo1.HammingDistance(algo2);
            Assert.AreEqual(2, result);
        }

        [TestMethod]
        public void HammingDistance_On_different_algos_size_2_should_return_0()
        {
            var algo1 = new TankStrategy(new List<Command> { Command.Backward, Command.Shoot });
            var algo2 = new TankStrategy(new List<Command> { Command.Stay, Command.Forward });
            var result = algo1.HammingDistance(algo2);
            Assert.AreEqual(0, result);
        }
    }
}