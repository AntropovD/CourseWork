using GeneticProgramming.Genetic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Genetic_Tests
{
    [TestClass]
    public class Population_Tests
    {
        [TestMethod]
        public void InitiatePopulation_should_return_population_size_from_config()
        {
            var config = ConfigurationFactory.Configuration.GeneticConfig;
            var population = new Population(config);
            
            Assert.AreEqual(config.PopulationSize, population.SpeciesAndValues.Count);
        }
    }
}   
