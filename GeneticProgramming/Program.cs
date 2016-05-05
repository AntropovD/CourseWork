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

//
//        public static void Main()
//        {
//            var strategy = new TankStrategy(new List<Command> { Command.Forward, Command.Forward, Command.Forward } );
//            var simulator = new BattleSimulator();
//            simulator.Execute(strategy);
//            Console.WriteLine(simulator.GetFitness());
//        }



        public static void Main()
        {
            var configuration = Configuration.DeserializeFromFile(ConfigFilename);
            var geneticAlgorithm = new GeneticAlgorithm(configuration);
            geneticAlgorithm.Run();
        }
    }
}
