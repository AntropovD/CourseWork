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
            return map.Enemies.Any(enemy => CanTankKillEnemy(tank, enemy));
        }

        public static bool CanTankKillEnemy(Tank tank, Tank enemy)
        {
            if ((tank.Coord.X == enemy.Coord.X) && (Math.Abs(tank.Coord.Y - enemy.Coord.Y) <= tank.fireArea))
                return true;
            if ((tank.Coord.Y == enemy.Coord.Y) && (Math.Abs(tank.Coord.X - enemy.Coord.X) < tank.fireArea))
                return true;
            return false;
        }

        public static bool CheckEnemyInVisibleArea(Map map, Tank tank)
        {
            return map.Enemies.Any(enemy => CanTankSeeEnemy(tank, enemy)); 
        }

        public static bool CanTankSeeEnemy(Tank tank, Tank enemy)
        {
            return (Math.Abs(tank.Coord.X - enemy.Coord.X) < tank.viewArea) &&
                   (Math.Abs(tank.Coord.Y - enemy.Coord.Y) < tank.viewArea);
        }
    }
}
