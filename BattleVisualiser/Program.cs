using System;
using System.IO;
using System.Windows;
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
            string fileNotExceeded;
            if (!CheckFiles(out fileNotExceeded))
            {
                MessageBox.Show($"File not exists {fileNotExceeded}");
                return;
            }
            var battle = GetBattle();
            using (var game = new GameVisualiser(battle))
                game.Run();
        }

        private static bool CheckFiles(out string file)
        {
            if (!File.Exists(folder + mapFile))
            {
                file = folder + mapFile;
                return false;
            }
            if (!File.Exists(folder + enemyStrategyFile))
            {
                file = folder + enemyStrategyFile;
                return false;
            }
            if (!File.Exists(folder + strategyFile))
            {
                file = folder + strategyFile;
                return false;
            }
            file = "";
            return true;
        }

        static Battle GetBattle()
        {
            var map = MapSerializator.Deserialise(folder + mapFile);
            var strategy = StrategySerializator.Deserialize(folder + strategyFile);
            var enemyStrategy = StrategySerializator.Deserialize(folder + enemyStrategyFile);

            return new Battle(map, strategy, enemyStrategy);
        }

        private static string folder = "Battle\\";
        private static string mapFile = "Map.dat";
        private static string enemyStrategyFile = "enemy.strategy";
        private static string strategyFile = "tank.Strategy";
    }
#endif
}
