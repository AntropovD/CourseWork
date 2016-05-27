using System;
using System.Collections.Generic;
using System.Linq;

namespace GeneticProgramming.Simulator.Modules
{
    static class StrategyTokens
    {
        public static bool IsToken(string cmd)
        {
            return IsFunction(cmd) || IsFunctionEnd(cmd) || IsTerminal(cmd);
        }

        public static bool IsTerminal(string cmd)
        {
            return TerminalSet.Contains(cmd);
        }

        public static bool IsFunction(string cmd)
        {
            return FunctionSet.Contains(cmd);
        }

        public static bool IsFunctionEnd(string cmd)
        {
            return cmd.Contains('}');
        }

        public static string GetRandomTerminal()
        {
            var rnd = new Random(Guid.NewGuid().GetHashCode());
            return TerminalSet[rnd.Next(TerminalSet.Count)];
        }

        public static string GetRandomFunction()
        {
            var rnd = new Random(Guid.NewGuid().GetHashCode());
            return FunctionSet[rnd.Next(FunctionSet.Count)];
        }

        internal static readonly List<string> TerminalSet = new List<string>
        {
            "TurnLeft", "TurnRight", "Forward", "Backward", "Shoot"
        };

        internal static readonly List<string> FunctionSet = StrategyFunctions.Rules.Keys.ToList();
    }
}
