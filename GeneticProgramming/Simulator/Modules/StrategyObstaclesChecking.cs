using System.Collections.Generic;
using GeneticProgramming.Simulator.Maps;
using GeneticProgramming.Simulator.Tanks;
using static GeneticProgramming.Simulator.Modules.DirectionMethods;

namespace GeneticProgramming.Simulator.Modules
{
    public static class StrategyObstaclesChecking
    {
        public static bool CheckObstacleFront(Map map, Tank tank)
        {
            var way = tank.Direction;
            return CheckObstacle(map, tank, way);
        }

        public static bool CheckObstacleRight(Map map, Tank tank)
        {
            var way = RotateRight(tank.Direction);
            return CheckObstacle(map, tank, way);
        }

        public static bool CheckObstacleBack(Map map, Tank tank)
        {
            var way = Flip(tank.Direction);
            return CheckObstacle(map, tank, way);
        }

        public static bool CheckObstacleLeft(Map map, Tank tank)
        {
            var way = RotateLeft(tank.Direction);
            return CheckObstacle(map, tank, way);
        }

        private static bool CheckObstacle(Map map, Tank tank, Direction way)
        {
            var coord = tank.Coord + wayCoords[way];
            return map.Obstacles.Contains(coord);
        }

        private static Dictionary<Direction, Coord> wayCoords = new Dictionary<Direction, Coord>
        {
            {Direction.Up, new Coord(0, -1)},
            {Direction.Right, new Coord(1, 0)},
            {Direction.Down, new Coord(0, 1)},
            {Direction.Left, new Coord(-1, 0)}
        };
    }
}
