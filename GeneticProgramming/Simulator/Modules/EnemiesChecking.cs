using System.Linq;
using GeneticProgramming.Simulator.Maps;
using GeneticProgramming.Simulator.Tanks;

namespace GeneticProgramming.Simulator.Modules
{
    public static class EnemiesChecking
    {
        public static bool CheckEnemyFront(Map map, Tank tank)
        {
            var way = tank.Direction;
            return CheckEnemyByWay(map, tank, way);
        }

        public static bool CheckEnemyLeft(Map map, Tank tank)
        {
            var way = DirectionMethods.RotateLeft(tank.Direction);
            return CheckEnemyByWay(map, tank, way);
        }

        public static bool CheckEnemyRight(Map map, Tank tank)
        {
            var way = DirectionMethods.RotateRight(tank.Direction);
            return CheckEnemyByWay(map, tank, way);
        }

        public static bool CheckEnemyBack(Map map, Tank tank)
        {
            var way = DirectionMethods.Flip(tank.Direction);
            return CheckEnemyByWay(map, tank, way);
        }

        private static bool CheckEnemyByWay(Map map, Tank tank, Direction way)
        {
            for (int i = 1; i <= tank.fireArea; i++)
            {
                var coord = tank.Coord + i*ObstaclesChecking.wayCoords[way];
                if (map.Enemies.Any(tank1 =>  tank1.Coord == coord))
                    return true;
                if (map.Obstacles.Contains(coord))
                    return false;
            }
            return false;
        }
    }
}