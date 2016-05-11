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

/*
                      var strategy = new TankStrategy(new List<string>
                      {
                          string.Forward, string.Forward, string.TurnLeft,
                          string.Forward, string.TurnRight, string.Backward, string.Backward
                      });
                      var map = new MapGenerator(configuration.MapConfig).GenerateMap();
                      //.GenerateMap();
                      var simulator = new BattleSimulator(map, true);
                      simulator.Execute(strategy);

              */
