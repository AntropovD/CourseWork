using System;
using System.Collections.Generic;
using System.Linq;
using GeneticProgramming.Genetic;
using GeneticProgramming.Genetic.GeneticEngine;
using GeneticProgramming.Panzer;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class CrossoverMethods_Tests
    {
        private GeneticConfiguration configuration;
        private CrossoverMethods crossoverMethods;

        [TestInitialize]
        public void TestInitialize()
        {
            configuration = new GeneticConfiguration();
            crossoverMethods = new CrossoverMethods(configuration);
        }

        [TestMethod]
        [TestCategory("CrossoverMethods")]
        public void FindMostLikely_on_3_algos_should_return_algo_with_1_difference()
        {
            var algo1 = new PanzerAlgorithm(new List<Command> {Command.MoveBackward, Command.MoveBackward, Command.Shoot});
            var algo2 = new PanzerAlgorithm(new List<Command> {Command.MoveBackward, Command.MoveBackward, Command.Stay});
            var algo3 = new PanzerAlgorithm(new List<Command> {Command.TurnLeft, Command.TurnLeft, Command.TurnLeft});
            var result = crossoverMethods.FindMostLikely(new List<PanzerAlgorithm> { algo1, algo2, algo3 }, algo1);

            CollectionAssert.AreEqual(algo3.commands, result.commands);
        }

        [TestMethod]
        [TestCategory("CrossoverMethods")]
        public void FincMostUnlikely_on_3_algos_should_return_algo_with_3_diffeence()
        {
            var algo1 = new PanzerAlgorithm(new List<Command> { Command.MoveBackward, Command.MoveBackward, Command.Shoot });
            var algo2 = new PanzerAlgorithm(new List<Command> { Command.MoveBackward, Command.MoveBackward, Command.Stay });
            var algo3 = new PanzerAlgorithm(new List<Command> { Command.TurnLeft, Command.TurnLeft, Command.TurnLeft });
            var result = crossoverMethods.FindMostUnlikely(new List<PanzerAlgorithm> { algo1, algo2, algo3 }, algo1);

            CollectionAssert.AreEqual(algo3.commands, result.commands);
        }

        [TestMethod]
        [TestCategory("CrossoverMethods")]
        public void CrossoverSpecies_should_not_overtop_maxAlgorithms_size()
        {
            var algo1 = new PanzerAlgorithm(Enumerable.Range(0, configuration.MaximumProgramSize).Select(i => Command.MoveForward));
            var algo2 = new PanzerAlgorithm(Enumerable.Range(0, configuration.MaximumProgramSize).Select(i => Command.Shoot));
            var result = crossoverMethods.CrossoverSpecies(algo1, algo2);
            Assert.IsTrue(result.commands.Count < configuration.MaximumProgramSize);
        }

        [TestMethod]
        [TestCategory("CrossoverMethods")]
        public void HammingDistance_On_Equal_algos_size_3_should_return_3()
        {
            var algo1 = new PanzerAlgorithm(new List<Command> { Command.MoveBackward, Command.Shoot, Command.MoveForward });
            var algo2 = new PanzerAlgorithm(new List<Command> { Command.MoveBackward, Command.Shoot, Command.MoveForward });
            var result = crossoverMethods.HammingDistance(algo1, algo2);
            Assert.AreEqual(3, result);
        }

        [TestMethod]
        [TestCategory("CrossoverMethods")]
        public void HammingDistance_On_algos_size_3_with_1_difference_should_return_2()
        {
            var algo1 = new PanzerAlgorithm(new List<Command> { Command.MoveBackward, Command.Shoot, Command.MoveForward });
            var algo2 = new PanzerAlgorithm(new List<Command> { Command.MoveBackward, Command.Stay, Command.MoveForward });
            var result = crossoverMethods.HammingDistance(algo1, algo2);
            Assert.AreEqual(2, result);
        }
    }
}
