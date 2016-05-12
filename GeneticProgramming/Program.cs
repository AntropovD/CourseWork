using System;
using GeneticProgramming.Configurations;
using GeneticProgramming.Genetic;
using GeneticProgramming.Simulator;

namespace GeneticProgramming
{
    public class Program
    {
        private const string ConfigFilename = "config.xml";

//        public static void Main()
//        {
//            var configuration = Configuration.DeserializeFromFile(ConfigFilename);
//            var geneticAlgorithm = new GeneticAlgorithm(configuration);
//            geneticAlgorithm.Run();
//        }

        public static void Main()
        {
            var configuration = Configuration.DeserializeFromFile(ConfigFilename);

            var strategiesGenerator = new StrategiesGenerator(500);
            var strategy = strategiesGenerator.GenerateProgram();

            var mapGenerator = new MapGenerator(configuration);
            var map = mapGenerator.GenerateMap();

            var simulator = new BattleSimulator(map, true);
            simulator.Execute(strategy);
        }
    }
}