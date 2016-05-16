using System;
using System.IO;
using System.Linq;
using GeneticProgramming.Configurations;
using GeneticProgramming.Genetic;
using GeneticProgramming.Simulator;
using GeneticProgramming.Simulator.Maps;
using GeneticProgramming.Simulator.Strategies;

namespace GeneticProgramming
{
    public class Program
    {
        private const string ConfigFilename = "config.xml";

        public static void Main()
        {
            Clear();
            var configuration = Configuration.DeserializeFromFile(ConfigFilename);
            var geneticAlgorithm = new GeneticAlgorithm(configuration);
            geneticAlgorithm.Run();
        }

        private static void Clear()
        {
            for (int i = 0; i < 30; i++)
            {
                string folderName = $"Logs\\Generation{i}";
                if (Directory.Exists(folderName))
                    Directory.Delete(folderName, true);
            }
        }

//        public static void Main()
//        {
//            var configuration = Configuration.DeserializeFromFile(ConfigFilename);
//
//            var strategiesGenerator = new StrategiesGenerator(5000);
//            var strategy = strategiesGenerator.GenerateProgram();
//            var enemyStrategy = strategiesGenerator.GenerateEnemyProgram();
//            System.IO.File.WriteAllLines("strategy.txt", strategy.commands);
//
//            var mapGenerator = new MapGenerator(configuration);
//            var map = mapGenerator.GenerateMap();
//
//            var battle = new Battle(map, strategy, enemyStrategy);
//            var simulator = new BattleSimulator(battle, true);
//            
//            int value = simulator.Execute();
//            Console.WriteLine($"Fitness value: {value}");
//        }
    }
}