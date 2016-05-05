using System;
using System.Collections.Generic;
using GeneticProgramming.Genetic;
using GeneticProgramming.Simulator;
using GeneticProgramming.Simulator.Tanks;

namespace GeneticProgramming
{
    public class Program
    {
        private const string ConfigFilename = "config.xml";

        public static void Main()
        {
            var configuration = Configuration.DeserializeFromFile(ConfigFilename);
            var geneticAlgorithm = new GeneticAlgorithm(configuration.GeneticConfig);
            geneticAlgorithm.Run();
        }
    }
}
