using System;

namespace GeneticProgramming.Simulator.Tanks
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
        public static Direction RotateRight(Direction direction)
        {
            return (Direction) (((int)direction + 1) % Enum.GetNames(typeof(Direction)).Length);
        }

        public static Direction RotateLeft(Direction direction)
        {
            return (Direction)(((int)direction - 1) % Enum.GetNames(typeof(Direction)).Length);
        }
    }
}