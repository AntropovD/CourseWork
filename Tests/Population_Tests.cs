using System;
using GeneticProgramming.Genetic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class Population_Tests
    {
        [TestMethod]
        public void InitiatePopulation_should_return_population_size_from_config()
        {
            var config = new GeneticConfiguration();
            var population = new Population(config);
            population.InitiatePopulation();
            Assert.AreEqual(config.InitialPopulationSize, population.Species.Count);
        }
    }
}
