using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using GeneticProgramming.Configurations;
using GeneticProgramming.Simulator;
using GeneticProgramming.Simulator.Maps;
using GeneticProgramming.Simulator.Strategies;

namespace Tests
{
    public class Program
    {
        private const string ConfigFilename = "config.xml";

//        public static void Main()
//        {
//            Clear();
//            var configuration = Configuration.DeserializeFromFile(ConfigFilename);
//            var geneticAlgorithm = new GeneticAlgorithm(configuration);
//            geneticAlgorithm.Run();
//        }
//
//        private static void Clear()
//        {
//            for (int i = 0; i < 30; i++)
//            {
//                string folderName = $"Logs\\Generation{i}";
//                if (Directory.Exists(folderName))
//                    Directory.Delete(folderName, true);
//            }
//        }

        public static void Main()
        {
            var configuration = Configuration.DeserializeFromFile(ConfigFilename);

            var strategiesGenerator = new StrategiesGenerator(5000);
            var strategy = strategiesGenerator.GenerateProgram();
            var enemyStrategy = strategiesGenerator.GenerateEnemyProgram();
            System.IO.File.WriteAllLines("strategy.txt", strategy.commands);

            var mapGenerator = new MapGenerator(configuration);
            var map = mapGenerator.GenerateMap();
         //   SerializeMap(map);
            
            var simulator = new BattleSimulator(map, strategy, enemyStrategy, true);
            
            var value = simulator.Execute();
            Console.WriteLine($"Fitness value: {value}");
        }

        private static void SerializeMap(Map map)
        {
            // создаем объект BinaryFormatter
            var formatter = new BinaryFormatter();
            // получаем поток, куда будем записывать сериализованный объект
            using (var fs = new FileStream("map.dat", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, map);
                Console.WriteLine("Объект сериализован");
            }
        }
    }
}