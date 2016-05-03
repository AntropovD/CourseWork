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
    }

}
