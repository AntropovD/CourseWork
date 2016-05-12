using GeneticProgramming.Simulator.Maps;
using GeneticProgramming.Simulator.Strategies;
using GeneticProgramming.Visualiser;

namespace GeneticProgramming.Simulator
{
    class BattleSimulator
    {
        private Map Map { get; }
        private readonly bool isDebug;
        private readonly BaseVisualiser visualiser;

        public BattleSimulator(Map map, Strategy enemyStrategy, bool isDebug = false)
        {
            Map = Map;
            visualiser = new ConsoleVisualiser();
            this.isDebug = isDebug;
        }
        
        public int Execute(Strategy strategy)
        {
            int fitnessValue = 0;
          //  string[] commands = strategy.commands.ToArray();
          //  var tankFunctions = new StrategyFunctions(Map, Map.Tank);

            Map.Tank.Strategy = strategy;

            while (true)
            {
                
            }
            return fitnessValue;
        }

        private void MakeStep(string command)
        {
            Coord nextCoord = Map.Tank.NextStep(command);
            if (IsPossible(nextCoord))
            {
                Map.Tank.Coord = nextCoord;
            }

//            foreach (var enemy in Map.Enemies)
//            {
//                enemy.NextStep();
//            }
        }

        private bool IsPossible(Coord nextCoord)
        {
            return true;
        }
    }
}
/* while (index < strategy.commands.Count)
            {
                if (StrategiesGenerator.IsTerminal(commands[index]))
                {
                    MakeStep(commands[index]);
                    if (isDebug)
                        visualiser.Visualise(Map);
                    if (Map.Tank.Coord == Map.FinishCoord)
                    {
                        result += 1000;
                        return result;
                    }
                    result++;
                }
                if (StrategiesGenerator.IsFunction(commands[index]))
                {
                    tankFunctions.CheckFunction(commands, ref index);
                }
                if (StrategiesGenerator.IsFunctionEnd(commands[index]))
                {
                    
                }
                Console.WriteLine($"Step#{index} - {commands[index]}");
                index++;
             //   Console.ReadKey();
            }*/
