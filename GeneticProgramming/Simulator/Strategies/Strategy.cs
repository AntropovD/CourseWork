using System;
using System.Collections.Generic;
using System.Linq;

namespace GeneticProgramming.Simulator.Strategies
{
    public class Strategy : IComparable
    {
        public List<string> commands;
        public int index;

        public Strategy(IEnumerable<string> commands)
        {
            this.commands = commands.ToList();
            index = 0;
        }

        public Strategy(List<string> commands)
        {
            this.commands = commands;
        }

        public int CompareTo(object obj)
        {
            return obj.GetHashCode();
        }
    }
}
