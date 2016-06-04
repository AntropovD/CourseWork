using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Runtime.Serialization;
using System.Security;
using System.Xml.Serialization;
using GeneticProgramming.Simulator.Maps;
using GeneticProgramming.Simulator.Modules;
using GeneticProgramming.Simulator.Tanks;
using log4net;
using static GeneticProgramming.Simulator.Modules.StrategyTokens;

namespace GeneticProgramming.Simulator.Strategies
{
    [Serializable]
    public class Strategy : IComparable
    {
        public List<string> commands;
        private int index;

        public string LastCommand { get; set; } = "Init";

        public bool strategyOver = false;

        private Strategy()
        {
            
        }

        public Strategy(List<string> commands)
        {
            this.commands = commands;
            index = 0;
        }

        public Strategy(Strategy strategy)
        {
            commands = new List<string>(strategy.commands);
            index = 0;
        }

        public string GetNextCommand(Map map, Tank tank)
        {
            if (index >= commands.Count)
            {
                strategyOver = true;
                return "Finish";
            }
            while (!IsTerminal(commands[index]))
            {
                if (IsFunction(commands[index]))
                {
                    if (StrategyFunctions.Rules[commands[index]](map, tank))
                    {
                        index++;
                        if (index >= commands.Count)
                        {
                            strategyOver = true;
                            return "Finish";
                        }
                    }
                    else
                        while (!IsFunctionEnd(commands[index]))
                        {
                            index++;
                            if (index >= commands.Count)
                            {
                                strategyOver = true;
                                return "Finish";
                            }
                        }
                }
                if (IsFunctionEnd(commands[index]))
                {
                    index++;
                    if (index >= commands.Count)
                    {
                        strategyOver = true;
                        return "Finish";
                    }
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
