using System.Collections.Generic;
using GeneticProgramming.Genetic;

namespace GeneticProgramming.Panzer
{
    public class PanzerAlgorithm 
    {
        public List<Command> commands;

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
