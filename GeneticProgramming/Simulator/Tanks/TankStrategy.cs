using System;
using System.Collections.Generic;
using System.Linq;

namespace GeneticProgramming.Simulator.Tanks
{
    public class TankStrategy : IComparable
    {
        public List<string> commands; 

        public TankStrategy(IEnumerable<string> commands)
        {
            this.commands = commands.ToList();
        }

        public TankStrategy(List<string> commands)
        {
            this.commands = commands;
        }

        public TankStrategy Crossover(TankStrategy anotherStrategy, int maxSize)
        {
            var random = new Random(Guid.NewGuid().GetHashCode());
            int firstIndex = random.Next(commands.Count);
            int secondIndex = random.Next(anotherStrategy.commands.Count);

            if (firstIndex + secondIndex > maxSize)
            {
                int diff = (firstIndex + secondIndex) - maxSize;
                if (diff % 2 == 1) diff++;
                firstIndex -= diff << 1;
                secondIndex -= diff << 1;
            }

            var firstPart = commands.Take(firstIndex).ToList();
            var secondPart = anotherStrategy.commands.Skip(anotherStrategy.commands.Count - secondIndex).Take(secondIndex);
            firstPart.AddRange(secondPart);

            return new TankStrategy(firstPart);
        }

        public TankStrategy FindMostLikely(List<TankStrategy> basePopulation)
        {
            return basePopulation.Where(algo => algo != this)
                    .Max(algo => Tuple.Create(HammingDistance(algo), algo)).Item2;
        }
        public TankStrategy FindMostUnlikely(List<TankStrategy> basePopulation)
        {
            return basePopulation.Where(algo => algo != this)
                    .Min(algo => Tuple.Create(HammingDistance(algo), algo)).Item2;
        }

        public int HammingDistance(TankStrategy anotherStrategy)
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
