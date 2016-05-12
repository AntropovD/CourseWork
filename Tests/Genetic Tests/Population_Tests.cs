using GeneticProgramming.Genetic.Engine;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Genetic_Tests
{
    [TestClass]
    public class Population_Tests
    {
        [TestMethod]
        public void InitiatePopulation_should_return_population_size_from_config()
        {
            var config = ConfigurationFactory.Configuration;
            var population = new Population(config.GeneticConfig, config.StrategyConfig);
            
            Assert.AreEqual(config.GeneticConfig.PopulationSize, population.SpeciesAndValues.Count);
        }
    }
}   
