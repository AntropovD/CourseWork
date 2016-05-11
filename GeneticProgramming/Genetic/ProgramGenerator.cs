﻿using System;
using System.Collections.Generic;
using System.Linq;
using GeneticProgramming.Simulator.Tanks;

namespace GeneticProgramming.Genetic
{
    public class ProgramGenerator
    {
        private readonly int length;
        private const double closeBracketCoeff = 0.3;
        private const double newFunctionCoeff = 0.7; 

        public ProgramGenerator(int maxStrategyLength)
        {
            length = maxStrategyLength;
            AllTerminals = new List<string>(TerminalSet);
            AllTerminals.AddRange(FunctionSet);
            AllTerminals.Add("}");
        }

        public List<string> GenerateRandomProgram()
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
            return result;
        }

        public bool CheckProgram(List<string> program)
        {
            int depth = 0;
            foreach (var command in program)
            {
                if (!AllTerminals.Contains(command))
                    return false;
                if (command.Contains('{')) depth++;
                if (command.Contains('}')) depth--;
                if (depth < 0)
                    return false;
            }
            return true;
        }

        private List<string> AllTerminals; 
        private readonly List<string> TerminalSet = new List<string>
        {
            "TurnLeft", "TurnRight", "Forward", "Backward", "Stay", "Shoot"
        };

        private readonly List<string> FunctionSet = new List<string>
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
