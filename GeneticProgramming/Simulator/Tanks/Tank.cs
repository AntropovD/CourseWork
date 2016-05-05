using System.Collections.Generic;
using GeneticProgramming.Simulator.Maps;

namespace GeneticProgramming.Simulator.Tanks
{
    public class Tank
    {
        public Coord Coord { get; set; }
        public Direction Direction { get; private set; }

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
            return Coord + Movements[Direction];
        }

        private static readonly Dictionary<Direction, Coord> Movements = new Dictionary<Direction, Coord>
        {
            { Direction.Up, new Coord(0, 1) },
            { Direction.Down, new Coord(0, -1) },
            { Direction.Left, new Coord(-1, 0) },
            { Direction.Right, new Coord(0, 1) }
        };
    }

    public enum Direction
    {
        Up,
        Down,
        Left,
        Right
    }
}
