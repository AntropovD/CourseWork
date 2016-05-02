using GeneticProgramming.Genetic;

namespace GeneticProgramming
{
    public class Program
    {
        private const string ConfigFilename = "config.xml";

        public static void Main()
        {
            var configuration = GeneticConfiguration.DeserializeFromFile(ConfigFilename);
            var geneticAlgorithm = new GeneticAlgorithm(configuration);
            geneticAlgorithm.Run();
        }
    }
}