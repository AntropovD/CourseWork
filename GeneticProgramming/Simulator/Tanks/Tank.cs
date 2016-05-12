using System;
using System.Collections.Generic;
using GeneticProgramming.Simulator.Maps;
using GeneticProgramming.Simulator.Modules;
using GeneticProgramming.Simulator.Strategies;

namespace GeneticProgramming.Simulator.Tanks
{
    public class Tank
    {
        public Coord Coord { get; set; }
        public Direction Direction { get; set; }
        public Strategy Strategy { get; }
        
        public bool IsAlive = true;
        public int viewArea;
        public int fireArea;
        public int ammunition;

        public Coord NextStep(string command)
        {
            switch (command)
            {
                case "Forward":
                    return Coord + Movements[Direction];
                case "Backward":
                    return Coord - Movements[Direction];
                case "TurnRight":
                    Direction = DirectionExtensions.RotateRight(Direction);
                    return Coord;
                case "TurnLeft":
                    Direction = DirectionExtensions.RotateLeft(Direction);
                    return Coord;
                case "Stay":
                    return Coord;
                case "Shoot":
                    return Coord;
                default:
                    throw new Exception("Unknown command");
            }
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
