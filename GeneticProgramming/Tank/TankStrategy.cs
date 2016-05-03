using System;
using System.Collections.Generic;
using System.Linq;

namespace GeneticProgramming.Tank
{
    public enum Command
    {
        TurnLeft,
        TurnRight,
        MoveForward,
        MoveBackward,
        Stay,
        Shoot
    }

    public class TankStrategy 
    {
        public List<Command> commands; 

        public TankStrategy(IEnumerable<Command> commands)
        {
            this.commands = commands.ToList();
        }

        public TankStrategy(List<Command> commands)
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

        #region EqualityComparer
        private sealed class CommandsEqualityComparer : IEqualityComparer<TankStrategy>
        {
            public bool Equals(TankStrategy x, TankStrategy y)
            {
                if (ReferenceEquals(x, y)) return true;
                if (ReferenceEquals(x, null)) return false;
                if (ReferenceEquals(y, null)) return false;
                if (x.GetType() != y.GetType()) return false;
                return Equals(x.commands, y.commands);
            }

            public int GetHashCode(TankStrategy obj)
            {
                return (obj.commands != null ? obj.commands.GetHashCode() : 0);
            }
        }

        private static readonly IEqualityComparer<TankStrategy> CommandsComparerInstance = new CommandsEqualityComparer();

        public static IEqualityComparer<TankStrategy> CommandsComparer
        {
            get { return CommandsComparerInstance; }
        }
        #endregion
    }
}
