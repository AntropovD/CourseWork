using System;
using System.Collections.Generic;
using GeneticProgramming.Configurations;
using GeneticProgramming.Simulator;
using GeneticProgramming.Simulator.Maps;
using GeneticProgramming.Simulator.Tanks;

namespace GeneticProgramming
{
    public class Program
    {
        private const string ConfigFilename = "config.xml";

        public static void Main()
        {
            var configuration = Configuration.DeserializeFromFile(ConfigFilename);

            var strategy = new TankStrategy(new List<Command>
            {
                Command.Forward, Command.Forward, Command.TurnLeft,
                Command.Forward, Command.TurnRight, Command.Backward, Command.Backward
            });
            var map = new MapGenerator(configuration.MapConfig).GenerateMap();
            //.GenerateMap();
            var simulator = new BattleSimulator(map, true);
            simulator.Execute(strategy);
         

//            var geneticAlgorithm = new GeneticAlgorithm(configuration);
//            geneticAlgorithm.Run();
        }
    }
}
