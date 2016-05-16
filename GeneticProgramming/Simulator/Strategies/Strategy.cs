using System;
using System.Collections.Generic;
using GeneticProgramming.Simulator.Maps;
using GeneticProgramming.Simulator.Modules;
using GeneticProgramming.Simulator.Tanks;
using static GeneticProgramming.Simulator.Modules.StrategyTokens;

namespace GeneticProgramming.Simulator.Strategies
{
    public class Strategy : IComparable
    {
        public List<string> commands;
        public int index;
        public string lastCommand = "Init";
        

        public Strategy(List<string> commands)
        {
            this.commands = commands;
        }

        public string GetNextCommand(Map map, Tank tank)
        {
            if (index >= commands.Count)
                return "Finish";
            while (!IsTerminal(commands[index]))
            {
                if (IsFunction(commands[index]))
                {
                    if (StrategyFunctions.Rules[commands[index]](map, tank))
                    {
                        index++;
                        if (index >= commands.Count)
                            return "Finish";
                    }
                    else
                        while (!IsFunctionEnd(commands[index]))
                        {
                            index++;
                            if (index >= commands.Count)
                                return "Finish";
                        }
                }
                if (IsFunctionEnd(commands[index]))
                {
                    index++;
                    if (index >= commands.Count)
                        return "Finish";
                }
            }
            lastCommand = commands[index];
            index++;
            return lastCommand;
        }
        
        public int CompareTo(object obj)
        {
            return obj.GetHashCode();
        }
    }
}
