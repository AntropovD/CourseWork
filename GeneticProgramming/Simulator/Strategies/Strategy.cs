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
        public string Token => commands[index];

        public Strategy(List<string> commands)
        {
            this.commands = commands;
        }

        public string GetNextCommand(Map map, Tank tank)
        {
            while (!IsTerminal(Token))
            {
                if (IsFunction(Token))
                {
                    if (StrategyFunctions.Rules[Token](map, tank))
                        index++;
                    else
                        while (!IsFunctionEnd(Token))
                        {
                            index++;
                        }
                }
                if (IsFunctionEnd(Token))
                    index++;
            }
            return Token;
        }
        
        public int CompareTo(object obj)
        {
            return obj.GetHashCode();
        }
    }
}
