using System.Collections.Generic;
using System.Linq;
using GeneticProgramming.Genetic;

namespace GeneticProgramming.Panzer
{
    public class PanzerAlgorithm 
    {
        public List<Command> commands;

        public PanzerAlgorithm(IEnumerable<Command> enumerable)
        {
            this.commands = enumerable.ToList();
        }

        public PanzerAlgorithm(List<Command> commands)
        {
            this.commands = commands;
        }

        #region Comparer
        private sealed class CommandsEqualityComparer : IEqualityComparer<PanzerAlgorithm>
        {
            public bool Equals(PanzerAlgorithm x, PanzerAlgorithm y)
            {
                if (ReferenceEquals(x, y)) return true;
                if (ReferenceEquals(x, null)) return false;
                if (ReferenceEquals(y, null)) return false;
                if (x.GetType() != y.GetType()) return false;
                return Equals(x.commands, y.commands);
            }

            public int GetHashCode(PanzerAlgorithm obj)
            {
                return (obj.commands != null ? obj.commands.GetHashCode() : 0);
            }
        }

        private static readonly IEqualityComparer<PanzerAlgorithm> CommandsComparerInstance = new CommandsEqualityComparer();

        public static IEqualityComparer<PanzerAlgorithm> CommandsComparer => CommandsComparerInstance;

        #endregion
    }

    public enum Command
    {
        TurnLeft,
        TurnRight,
        MoveForward,
        MoveBackward,
        Stay,
        Shoot
    }
}
