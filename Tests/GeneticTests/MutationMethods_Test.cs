using System.Collections.Generic;
using System.Linq;
using GeneticProgramming.Genetic.Methods;
using GeneticProgramming.Panzer;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.GeneticTests
{
    [TestClass]
    public class MutationMethods_Test
    {
        private MutationMethods mutationMethods;

        [TestInitialize]
        public void TestInitialize()
        {
            mutationMethods = new MutationMethods();
        }

        [TestMethod]
        public void GetMutatesSpecies_on_mutation_count_2_returns_2_species()
        {
            var population = new List<PanzerAlgorithm>
            {
                new PanzerAlgorithm(new List<Command> {Command.MoveBackward, Command.MoveBackward}),
                new PanzerAlgorithm(new List<Command> {Command.MoveForward, Command.MoveForward})
            };

            var mutatedSpecies = mutationMethods.GetMutatedSpecies(population, 2);
            Assert.AreEqual(2, mutatedSpecies.Count());
        }
    }
}
