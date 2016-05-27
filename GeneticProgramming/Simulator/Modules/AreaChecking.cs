using System;
using System.Linq;
using GeneticProgramming.Simulator.Maps;
using GeneticProgramming.Simulator.Tanks;

namespace GeneticProgramming.Simulator.Modules
{
    class AreaChecking
    {
        public static bool CheckEnemyInFireArea(Map map, Tank tank)
        {
            return map.Enemies.Any(enemy => CanTankKillEnemy(map, tank, enemy));
        }

        public static bool CanTankKillEnemy(Map map, Tank tank, Tank enemy)
        {
            if ((tank.Coord.X == enemy.Coord.X) && (Math.Abs(tank.Coord.Y - enemy.Coord.Y) <= map.FireArea))
                return true;
            if ((tank.Coord.Y == enemy.Coord.Y) && (Math.Abs(tank.Coord.X - enemy.Coord.X) < map.FireArea))
                return true;
            return false;
        }

        public static bool CheckEnemyInVisibleArea(Map map, Tank tank)
        {
            return map.Enemies.Any(enemy => CanTankSeeEnemy(map, tank, enemy)); 
        }

        public static bool CanTankSeeEnemy(Map map, Tank tank, Tank enemy)
        {
            return (Math.Abs(tank.Coord.X - enemy.Coord.X) < map.ViewArea) &&
                   (Math.Abs(tank.Coord.Y - enemy.Coord.Y) < map.ViewArea);
        }
    }
}
