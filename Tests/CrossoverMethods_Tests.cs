using System;
using System.Collections.Generic;
using GeneticProgramming.Genetic;
using GeneticProgramming.Genetic.GeneticEngine;
using GeneticProgramming.Panzer;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class CrossoverMethods_Tests
    {
        [TestMethod]
        public void HammingDistance_On_Equal_algos_should_return_length()
        {
            var config = new GeneticConfiguration();
            var commands = new List<Command>() {Command.MoveBackward, Command.Shoot, Command.MoveForward};
            var algo1 = new PanzerAlgorithm(commands);
            var algo2 = new PanzerAlgorithm(commands);
            var crossoverMethods = new CrossoverMethods(config);
            
            Assert.AreEqual(3, crossoverMethods.HammingDistance(algo1, algo2));
        }
    }
}
