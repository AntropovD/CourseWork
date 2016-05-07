using System;
using System.Collections.Generic;
using GeneticProgramming.Simulator.Maps;

namespace GeneticProgramming.Simulator.Tanks
{
    public class Tank
    {
        public Coord Coord { get; set; }
        public Direction Direction { get; set; }

        public Tank(int coordX, int coordY, Direction direction = Direction.Right)
        {
            Coord = new Coord(coordX, coordY);
            Direction = direction;
        }

        public Tank(Coord coord, Direction direction = Direction.Right)
        {
            Coord = coord;
            Direction = direction;
        }

//        public TankStrategy TankStrategy { get; private set; }
//
//        private bool IsAlive = true;
//        public int VisibilityRadius = 6;
//        public int DefeatRadius = 4;
//        public int Ammunition = 20;

        public Coord NextStep(Command command)
        {
            switch (command)
            {
                case Command.Forward:
                    return Coord + Movements[Direction];
                case Command.Backward:
                    return Coord - Movements[Direction];
                case Command.TurnRight:
                    Direction = DirectionExtensions.RotateRight(Direction);
                    return Coord;
                case Command.TurnLeft:
                    Direction = DirectionExtensions.RotateLeft(Direction);
                    return Coord;
                case Command.Stay:
                    return Coord;
                default:
                    throw new Exception("Unknown Command");
            }
        }

        private static readonly Dictionary<Direction, Coord> Movements = new Dictionary<Direction, Coord>
        {
            { Direction.Up, new Coord(0, 1) },
            { Direction.Down, new Coord(0, -1) },
            { Direction.Left, new Coord(-1, 0) },
            { Direction.Right, new Coord(0, 1) }
        };

        public static Tank RandomizeTank(Coord coord)
        {
            var directions = Enum.GetValues(typeof (Direction));
            var rnd = new Random(Guid.NewGuid().GetHashCode());
            return new Tank(coord, (Tanks.Direction)directions.GetValue(rnd.Next(directions.Length)));
        }
    }
}
