using System;
using System.Collections.Generic;
using System.Linq;
using GeneticProgramming.Simulator.Strategies;

namespace GeneticProgramming.Genetic.Methods
{
    public static class StrategyCrossoverMethods
    {
        public static Strategy Crossover(Strategy firstStrategy, Strategy secondStrategy, int maxSize)
        {
            var random = new Random(Guid.NewGuid().GetHashCode());
            int firstIndex = random.Next(firstStrategy.commands.Count);
            int secondIndex = random.Next(secondStrategy.commands.Count);

            if (firstIndex + secondIndex > maxSize)
            {
                int diff = (firstIndex + secondIndex) - maxSize;
                if (diff % 2 == 1) diff++;
                firstIndex -= diff << 1;
                secondIndex -= diff << 1;
            }
            var resultStrategy = GetStrategiesConcatenation(firstStrategy, secondStrategy, firstIndex, secondIndex);

            return new Strategy(resultStrategy);
        }

        private static List<string> GetStrategiesConcatenation(Strategy firstStrategy, Strategy secondStrategy, int firstIndex, int secondIndex)
        {
            var firstPart = firstStrategy.commands.Take(firstIndex).ToList();
            firstPart = AddBracketsToEnd(firstPart);

            var secondPart = secondStrategy.commands.Skip(secondStrategy.commands.Count - secondIndex).Take(secondIndex).ToList();
            secondPart = ShiftWhileDepthNotZero(secondPart);

            return firstPart.Concat(secondPart).ToList();
        }

        public static List<string> AddBracketsToEnd(List<string> programPart)
        {
            int depth = 0;
            foreach (var command in programPart)
            {
                if (command.Contains('{'))
                    depth++;
                if (command.Contains('}'))
                    depth--;
                if (depth < 0)
                    throw new ArgumentException("ProgramPart is broken");
            }
            var result = new List<string>(programPart);
            result.AddRange(Enumerable.Range(0, depth).Select(i => "}").ToList());
            return result;
        }

        public static List<string> ShiftWhileDepthNotZero(List<string> programPart)
        {
            int depth = 0, minDepth = 0, minIndex = 0;
            for (int index = 0; index < programPart.Count; index++)
            {
                var command = programPart[index];
                if (command.Contains('{'))
                    depth++;
                if (command.Contains('}'))
                    depth--;
                if (depth < minDepth)
                    minIndex = index;
            }
            return programPart.Skip(minIndex).ToList();
        }
    }
}
