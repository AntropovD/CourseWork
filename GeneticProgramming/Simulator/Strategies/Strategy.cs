using System;
using System.Collections.Generic;
using System.Linq;
using GeneticProgramming.Simulator.Modules;

namespace GeneticProgramming.Simulator.Strategies
{
    public class Strategy : IComparable
    {
        public List<string> commands;
        public int index;

        public Strategy(List<string> commands)
        {
            this.commands = commands;
        }

        public string GetNextCommand()
        {
            if (StrategyTokens.IsTerminal(commands[index]))
                return commands[index];
            return null;
        }
        
        public int CompareTo(object obj)
        {
            return obj.GetHashCode();
        }
    }
}
