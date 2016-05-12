using GeneticProgramming.Simulator.Strategies;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Genetic_Tests
{
    [TestClass]
    public class ProgramGenerator_Tests
    {
        [TestMethod]
        public void GenerateRandomProgram_length_30_should_return_program_not_less_30()
        {
            var generator = new StrategiesGenerator(30);
            var program = generator.GenerateProgram();
            Assert.IsTrue(30 <= program.commands.Count);
        }

        [TestMethod]
        public void GenerateRandomProgram_should_return_working_program()
        {
            var generator = new StrategiesGenerator(30);
            var program = generator.GenerateProgram();
            Assert.IsTrue(generator.CheckProgram(program.commands));
        }
    }
}
