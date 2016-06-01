using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeneticProgramming.Simulator.Maps;

namespace GeneticProgramming.Simulator
{
    public class FightStat
    {
        public int Steps { get; set; } = 0;
        public int Killed { get; set; } = 0;
        public int EnemiesKilledByEnemies { get; set; } = 0;
        public bool FinishAchieved { get; set; } = false;
        public bool IsAlive { get; set; } = true;
        
        public int Result(Battle Battle)
        {
            return Steps + Killed * 50 + countNearMetric(Battle) * 50;
        }

        private int countNearMetric(Battle Battle)
        {
            int d1 = Distance(Battle.Map.Tank.Coord, Battle.Map.FinishCoord);
            int d2 = Distance(Battle.Map.StartCoord, Battle.Map.FinishCoord);
            return (d2 - d1) * 10;
        }

        private int Distance(Coord startCoord, Coord finishCoord)
        {
            return startCoord.X - finishCoord.X + startCoord.Y - finishCoord.Y;
        }


    }
}
