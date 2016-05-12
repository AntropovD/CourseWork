using System;
using GeneticProgramming.Simulator.Maps;
using GeneticProgramming.Simulator.Modules;
using GeneticProgramming.Simulator.Strategies;
using GeneticProgramming.Simulator.Tanks;
using GeneticProgramming.Visualiser;

namespace GeneticProgramming.Simulator
{
    class BattleSimulator
    {
        private Map Map { get; }

        private readonly bool isDebug;
        private readonly BaseVisualiser visualiser;
        private Strategy enemyStrategy;

        public BattleSimulator(Map Map, Strategy enemyStrategy, bool isDebug = false)
        {
            this.Map = Map;
            this.isDebug = isDebug;
            this.enemyStrategy = enemyStrategy;
            if (isDebug)
                visualiser = new ConsoleVisualiser();
        }
        
        public int Execute(Strategy strategy)
        {
            int result = 0;
            int index = 0;
            string[] commands = strategy.commands.ToArray();
            var tankFunctions = new StrategyFunctions(Map, Map.Tank);
         
            if (isDebug)
                System.IO.File.WriteAllText(@"strategy.txt", string.Join(@"\r\n", commands));

            while (index < strategy.commands.Count)
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
            }
            return result;
        }

        private void MakeStep(string command)
        {
            Coord nextCoord = Map.Tank.NextStep(command);
            if (IsPossible(nextCoord))
            {
                Map.Tank.Coord = nextCoord;
            }

            foreach (var enemy in Map.Enemies)
            {
                enemy.NextStep()
            }
        }

        private bool IsPossible(Coord nextCoord)
        {
            return true;
        }
    }
}
