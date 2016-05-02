using System.Collections.Generic;
using System.Linq;

namespace GeneticProgramming.Panzer
{
    public class PanzerAlgorithm 
    {
        public List<Command> commands; 

        public PanzerAlgorithm(IEnumerable<Command> commands)
        {
            this.commands = commands.ToList();
        }

        public PanzerAlgorithm(List<Command> commands)
        {
            this.commands = commands;
        }
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
