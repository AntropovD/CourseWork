using GeneticProgramming.Configurations;
using GeneticProgramming.Genetic;

namespace GeneticProgramming
{
    public class Program
    {
        private const string ConfigFilename = "config.xml";

        public static void Main()
        {
            var configuration = Configuration.DeserializeFromFile(ConfigFilename);
            var geneticAlgorithm = new GeneticAlgorithm(configuration);
            geneticAlgorithm.Run();
        }
    }
}
