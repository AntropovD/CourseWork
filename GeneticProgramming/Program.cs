using System;
using GeneticProgramming.Configurations;
using GeneticProgramming.Configurations.PartialConfigs;
using GeneticProgramming.Simulator;
using GeneticProgramming.Simulator.Maps;
using GeneticProgramming.Simulator.Strategies;

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

            var strategiesGenerator = new StrategiesGenerator(30);
            var strategy = strategiesGenerator.GenerateProgram();
            var enemyStrategy = strategiesGenerator.GenerateEnemyProgram();

            var mapGenerator = new MapGenerator(configuration);
            var map = mapGenerator.GenerateMap();

            var simulator = new BattleSimulator(map, enemyStrategy, true);
            int value = simulator.Execute(strategy);
            Console.WriteLine($"Fitness value: {value}");
        }
    }
}