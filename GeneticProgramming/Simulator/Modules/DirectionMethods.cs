using System;
using GeneticProgramming.Simulator.Tanks;

namespace GeneticProgramming.Simulator.Modules
{
    public class DirectionMethods
    {
        private static readonly int length = Enum.GetNames(typeof (Direction)).Length;

        public static Direction RotateRight(Direction direction)
        {
            return (Direction) (((int)direction + 1) % length);
        }

        public static Direction RotateLeft(Direction direction)
        {
            return (Direction)(((int)direction + (length - 1)) % length);
        }

        public static Direction Flip(Direction direction)
        {
            return (Direction)(((int)direction + 2) % length);
        }
    }
}