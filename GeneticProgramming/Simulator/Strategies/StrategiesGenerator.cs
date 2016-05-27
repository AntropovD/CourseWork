using System;
using System.Collections.Generic;
using System.Linq;
using GeneticProgramming.Simulator.Modules;

namespace GeneticProgramming.Simulator.Strategies
{
    public class StrategiesGenerator
    {
        private readonly int maxLength;

        private const double closeBracketCoeff = 0.7;
        private const double newFunctionCoeff = 0.5; 

        public StrategiesGenerator(int MaxStrategySize)
        {
            maxLength = MaxStrategySize;
        }

        public Strategy GenerateProgram()
        {
            var result = new List<string>();
            var functionDepth = 0;
            var rnd = new Random(Guid.NewGuid().GetHashCode());
            var i = 0;
            int length = rnd.Next(1, maxLength);
        
            while (i < length)
            {
                var p = rnd.NextDouble();
                if (functionDepth != 0 && p < closeBracketCoeff)
                {
                    result.Add("}");
                    functionDepth--;
                    i++;
                    continue;
                }
                int index;
                if (p < newFunctionCoeff)
                {
                    index = rnd.Next(StrategyTokens.FunctionSet.Count);
                    result.Add(StrategyTokens.FunctionSet[index]);
                    functionDepth++;
                    i++;
                }
                index = rnd.Next(StrategyTokens.TerminalSet.Count);
                result.Add(StrategyTokens.TerminalSet[index]);
                i++;
            }
            for (i = 0; i < functionDepth; i++)
                result.Add("}");
            return new Strategy(result);
        }

        public Strategy GenerateEnemyProgram()
        {
            var result = new List<string>();
            var index = 0;
            while (index < maxLength)
            {
                result.Add("TurnRight");
                result.Add("Forward");
                result.Add("Forward");
                result.Add("Shoot");
                index += 4;
            }
            return new Strategy(result);
        }
        public static bool CheckProgram(List<string> program)
        {
            var depth = 0;
            foreach (var command in program)
            {
                if (!StrategyTokens.IsToken(command))
                    return false;
                if (command.Contains('{')) depth++;
                if (command.Contains('}')) depth--;
                if (depth < 0)
                    return false;
            }
            return true;
        }
    }
}
