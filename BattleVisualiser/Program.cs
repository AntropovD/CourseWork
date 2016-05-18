using System;
using GeneticProgramming.Configurations;
using GeneticProgramming.Simulator;
using GeneticProgramming.Simulator.Maps;
using GeneticProgramming.Simulator.Strategies;

namespace BattleVisualiser
{
#if WINDOWS || LINUX
    /// <summary>
    /// The main class.
    /// </summary>
    public static class Program
    {
        [STAThread]
        static void Main()
        {
            var battle = GetBattle();
            using (var game = new GameVisualiser(battle))
                game.Run();
        }

        static Battle GetBattle()
        {
            var configuration = Configuration.DeserializeFromFile("config.xml");

            var strategiesGenerator = new StrategiesGenerator(5000);
            var strategy = strategiesGenerator.GenerateProgram();
            var enemyStrategy = strategiesGenerator.GenerateEnemyProgram();
            System.IO.File.WriteAllLines("strategy.txt", strategy.commands);

            var mapGenerator = new MapGenerator(configuration);
            var map = mapGenerator.GenerateMap();

            return new Battle(map, strategy, enemyStrategy);
        }
    }
#endif
}
