using System.Collections.Generic;
using GeneticProgramming.Genetic;

namespace GeneticProgramming.Panzer
{
    public class PanzerAlgorithm 
    {
        private List<Command> commands;
        private int maxCommandsSize;

        public PanzerAlgorithm(List<Command> commands, int maxSize)
        {
            this.commands = commands;
            maxCommandsSize = maxSize;
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
