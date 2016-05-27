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
        private static string folder = @"Logs\Generations\";
        private static string file = "enemy.strategy";
        private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public void Serialize()
        {
            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }
            var formatter = new XmlSerializer(typeof(Strategy));
            using (var fs = new FileStream(folder + file, FileMode.OpenOrCreate))
            {
                try
                {
                    formatter.Serialize(fs, this);
                }
                catch (SerializationException)
                {
                    log.Error("Map Serialization problems:(");
                }
                catch (SecurityException)
                {
                    log.Error("Map serialization. Cannot access to map.dat file.");
                }
            }
        }
    }
}
