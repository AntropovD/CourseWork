using System;
using System.Collections.Generic;
using System.Linq;

namespace GeneticProgramming.Simulator.Strategies
{
    public class StrategiesGenerator
    {
        private readonly int length;
        private const double closeBracketCoeff = 0.7;
        private const double newFunctionCoeff = 0.5; 

        public StrategiesGenerator(int MaxStrategySize)
        {
            length = MaxStrategySize;
        }

        public Strategy GenerateProgram()
        {
            List<string> result = new List<string>();
            int functionDepth = 0;
            var rnd = new Random();
            int i = 0;
            while (i < length)
            {
                double p = rnd.NextDouble();
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
                    index = rnd.Next(FunctionSet.Count);
                    result.Add(FunctionSet[index]);
                    functionDepth++;
                    i++;
                }
                index = rnd.Next(TerminalSet.Count);
                result.Add(TerminalSet[index]);
                i++;
            }
            for (i = 0; i < functionDepth; i++)
                result.Add("}");
            return new Strategy(result);
        }

        public Strategy GenerateEnemyProgram()
        {
            List<string> result = new List<string>();
            int index = 0;
            while (index < length)
            {
                result.Add("TurnRight");
                result.Add("Forward");
                result.Add("Shoot");
                index += 3;
            }
            return new Strategy(result);
        }
        public bool CheckProgram(List<string> program)
        {
            int depth = 0;
            foreach (var command in program)
            {
                if (!IsToken(command))
                    return false;
                if (command.Contains('{')) depth++;
                if (command.Contains('}')) depth--;
                if (depth < 0)
                    return false;
            }
            return true;
        }

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

        private static readonly List<string> TerminalSet = new List<string>
        {
            "TurnLeft", "TurnRight", "Forward", "Backward", "Stay", "Shoot"
        };

        private static readonly List<string> FunctionSet = new List<string>
        {
            "If_Enemy_In_Visible_Area{",
            "If_Enemy_In_Fire_Area{",
            "If_Enemy_Up{",
            "If_Enemy_Left{",
            "If_Enemy_Right{",
            "If_Ememy_Down{",
            "If_Obstacle_Forward{",
            "If_Obstacle_Backward{",
            "If_Obstacle_Right{",
            "If_Obstacle_Left{"
        };

    }
}
