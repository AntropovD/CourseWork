using System;
using System.Collections.Generic;

namespace GeneticProgramming.Simulator
{
    public class Tank
    {
        public Coord Coord { get; set; }
        public Direction Direction { get; set; }
        
        public bool IsAlive = true;
        public int viewArea;
        public int fireArea;
        public int ammunition;

        public Coord NextStep(string command)
        {
            return Coord;
            /*switch (command)
            {
                case string.Forward:
                    return Coord + Movements[Direction];
                case string.Backward:
                    return Coord - Movements[Direction];
                case string.TurnRight:
                    Direction = DirectionExtensions.RotateRight(Direction);
                    return Coord;
                case string.TurnLeft:
                    Direction = DirectionExtensions.RotateLeft(Direction);
                    return Coord;
                case string.Stay:
                    return Coord;
                default:
                    throw new Exception("Unknown string");
            }*/
        }

        private static readonly Dictionary<Direction, Coord> Movements = new Dictionary<Direction, Coord>
        {
            { Direction.Up, new Coord(0, 1) },
            { Direction.Down, new Coord(0, -1) },
            { Direction.Left, new Coord(-1, 0) },
            { Direction.Right, new Coord(0, 1) }
        };
    }
}
