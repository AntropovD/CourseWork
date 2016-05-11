using System;
using GeneticProgramming.Genetic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.GeneticTests
{
    [TestClass]
    public class ProgramGenerator_Tests
    {
        [TestMethod]
        public void GenerateRandomProgram_length_30_should_return_program_not_less_30()
        {
            var generator = new ProgramGenerator(30);
            var program = generator.GenerateRandomProgram();
            Assert.IsTrue(30 <= program.Count);
        }

        [TestMethod]
        public void GenerateRandomProgram_should_return_working_program()
        {
            var generator = new ProgramGenerator(30);
            var program = generator.GenerateRandomProgram();
            Assert.IsTrue(generator.CheckProgram(program));
        }
    }
}
