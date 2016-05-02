using System;
using System.IO;
using System.Xml.Serialization;
using GeneticProgramming.Genetic;
using GeneticProgramming.NInject;
using Ninject;

namespace GeneticProgramming
{
    public class Program
    {
        private const string ConfigFilename = "config.xml";

        public static void Main()
        {
            Console.WriteLine("Hello genetic algorithms!");

            var configuration = GeneticConfiguration.DeserializeFromFile(ConfigFilename);
            var t = new GeneticAlgorithm(configuration);
            t.Run();
        }
    }
}