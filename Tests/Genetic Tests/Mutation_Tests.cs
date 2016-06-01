using System.Collections.Generic;
using System.Linq;
using GeneticProgramming.Configurations.PartialConfigs;
using GeneticProgramming.Genetic.Engine.Types;
using GeneticProgramming.Simulator.Strategies;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Genetic_Tests
{
    [TestClass]
    public class Mutation_Tests
    {
        private readonly GeneticConfig config = ConfigurationFactory.Configuration.GeneticConfig;
        private Mutation mutation;
        private StrategiesGenerator StrategiesGenerator;

        [TestInitialize]
        public void TestInitialize()
        {
            mutation = new Mutation();
            StrategiesGenerator = new StrategiesGenerator(100);
        }
        
        [TestMethod]
        public void GetMutatesSpecies_on_mutation_count_2_returns_2_species()
        {
            var population = new List<Strategy>
            {
                new Strategy(new List<string> {"Backward", "Backward"}),
                new Strategy(new List<string> {"Forward", "Forward"})
            };

            var mutatedSpecies = mutation.GetMutatedSpecies(population, 2);
            Assert.AreEqual(2, mutatedSpecies.Count());
        }


        [TestMethod]
        public void GetMutatedSpecies_returns_valid_strategy()
        {
            var initialStrategies = new List<Strategy>();
            for (int i = 0; i < config.PopulationSize; i++)
                initialStrategies.Add(StrategiesGenerator.GenerateProgram());

            var strategies = mutation.GetMutatedSpecies(initialStrategies, 10);
            foreach (var strategy in strategies)
            {
                Assert.IsTrue(StrategiesGenerator.CheckProgram(strategy.commands));
            }
        }
    }
}
