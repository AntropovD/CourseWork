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
        private int index;

        public string LastCommand { get; set; } = "Init";

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
            LastCommand = commands[index];
            index++;
            return LastCommand;
        }
        
        public int CompareTo(object obj)
        {
            return obj.GetHashCode();
        }

        public void Reset()
        {
            index = 0;
        }
    }
}
