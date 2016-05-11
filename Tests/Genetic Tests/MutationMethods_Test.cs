using System.Collections.Generic;
using System.Linq;
using GeneticProgramming.Genetic;
using GeneticProgramming.Genetic.Methods;
using GeneticProgramming.Simulator;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Genetic_Tests
{
    [TestClass]
    public class MutationMethods_Test
    {
        private Mutation mutation;

        [TestInitialize]
        public void TestInitialize()
        {
            mutation = new Mutation();
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
    }
}
