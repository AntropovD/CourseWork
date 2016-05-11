using System;

namespace GeneticProgramming.Simulator
{
    public enum Direction
    {
        Up = 0,
        Right = 1,
        Down = 2,
        Left = 3
    }

    public class DirectionExtensions
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
    }
}