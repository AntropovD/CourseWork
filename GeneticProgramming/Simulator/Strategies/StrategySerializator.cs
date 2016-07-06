using System;
using System.IO;
using System.Linq;

namespace GeneticProgramming.Simulator.Strategies
{
    public class StrategySerializator
    {
        public static Strategy Deserialize(string path)
        {
            string[] allText = File.ReadAllLines(path);
            var commands = allText[1]?.Split(' ');
            return new Strategy(commands?.ToList());
        }

        public static void SerializeToFile(string filename, Strategy strategy, FightStat fightStat)
        {
            File.WriteAllLines(filename, new[]
            {
                fightStat.ToString(),
                string.Join(" ", strategy.commands)
            });
        }
    }
}
