using System;
using System.Collections.Generic;
using System.Linq;

namespace GeneticProgramming.Simulator
{
    public class Strategy : IComparable
    {
        public List<string> commands; 

        public Strategy(IEnumerable<string> commands)
        {
            this.commands = commands.ToList();
        }

        public Strategy(List<string> commands)
        {
            this.commands = commands;
        }

        public Strategy Crossover(Strategy strategy, int maxSize)
        {
            var random = new Random(Guid.NewGuid().GetHashCode());
            int firstIndex = random.Next(commands.Count);
            int secondIndex = random.Next(strategy.commands.Count);

            if (firstIndex + secondIndex > maxSize)
            {
                int diff = (firstIndex + secondIndex) - maxSize;
                if (diff % 2 == 1) diff++;
                firstIndex -= diff << 1;
                secondIndex -= diff << 1;
            }
            var resultStrategy = GetStrategiesConcatenation(strategy, firstIndex, secondIndex);

            return new Strategy(resultStrategy);
        }

        private List<string> GetStrategiesConcatenation(Strategy strategy, int firstIndex, int secondIndex)
        {
            var firstPart = commands.Take(firstIndex).ToList();
            firstPart = AddBracketsEnd(firstPart);

            var secondPart = strategy.commands.Skip(strategy.commands.Count - secondIndex).Take(secondIndex).ToList();
            secondPart = ShiftWhileDepthNotZero(secondPart);
            
            return firstPart.Concat(secondPart).ToList();
        }

        public List<string> AddBracketsEnd(List<string> programPart)
        {
            int depth = 0;
            foreach (var command in programPart)
            {
                if (command.Contains('{'))
                    depth++;
                if (command.Contains('}'))
                    depth--;
                if (depth<0)
                    throw new ArgumentException("ProgramPart is broken");
            }
            var result = new List<string>(programPart);
            result.AddRange(Enumerable.Range(0, depth).Select(i => "}").ToList());
            return result;
        }

        public List<string> ShiftWhileDepthNotZero(List<string> programPart)
        {
            int depth = 0, minDepth = 0, minIndex=0;
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

        public Strategy FindMostLikely(List<Strategy> basePopulation)
        {
            return basePopulation.Where(algo => algo != this)
                    .Max(algo => Tuple.Create(HammingDistance(algo), algo)).Item2;
        }
        public Strategy FindMostUnlikely(List<Strategy> basePopulation)
        {
            return basePopulation.Where(algo => algo != this)
                    .Min(algo => Tuple.Create(HammingDistance(algo), algo)).Item2;
        }

        public int HammingDistance(Strategy anotherStrategy)
        {
            int count = 0;
            for (int i = 0; i < Math.Min(commands.Count, anotherStrategy.commands.Count); i++)
                if (commands[i] == anotherStrategy.commands[i])
                    count++;
            return count;
        }

        public int CompareTo(object obj)
        {
            return obj.GetHashCode();
        }
    }
}
