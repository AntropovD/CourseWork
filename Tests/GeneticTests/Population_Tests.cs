using GeneticProgramming.Genetic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.GeneticTests
{
    [TestClass]
    public class Population_Tests
    {
        [TestMethod]
        public void InitiatePopulation_should_return_population_size_from_config()
        {
            var config = ConfigurationFactory.GetConfigForTesting();
            var population = new GeneticPopulation(config);
            population.InitiatePopulation();
            
            Assert.AreEqual(config.InitialPopulationSize, population.Species.Count);
        }
    }

    public static class ConfigurationFactory
    {
        public static GeneticConfiguration GetConfigForTesting()
        {
            return new GeneticConfiguration
            {
                InitialPopulationSize = 16,
                MaximumPopulationSize = 64,
                MaximumProgramSize = 128,
                CrossoverProb = 0.9,
                MutationProb = 0.05,
                PanmixiaRatio = 0.4,
                InbreedRatio = 0.3,
                OutbreedRatio = 0.4
            };
        }
    }
}   
