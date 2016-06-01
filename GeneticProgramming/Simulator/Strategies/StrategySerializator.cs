using System.IO;
using System.Linq;

namespace GeneticProgramming.Simulator.Strategies
{
    public class StrategySerializator
    {
        public static Strategy Deserialize(string path)
        {
            string allText = File.ReadAllText(path);

            var commands = allText.Split(' ');
            return new Strategy(commands.ToList());
        }
    }
}
