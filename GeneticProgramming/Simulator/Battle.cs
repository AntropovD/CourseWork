using GeneticProgramming.Simulator.Maps;
using GeneticProgramming.Simulator.Strategies;

namespace GeneticProgramming.Simulator
{
    public class Battle
    {
        public bool IsOver { get; private set; }
        public Map Map { get; }
        public Strategy Strategy { get; }
        public Strategy EnemyStrategy { get; }

        public Battle(Map map, Strategy strategy, Strategy enemyStrategy)
        {
            Map = map;
            Strategy = strategy;
            EnemyStrategy = enemyStrategy;
            IsOver = false;
        }

        public void MakeStep(ref int fitnessValue)
        {
            MakeTankStep();
            MakeEnemiesStep();
        }

        private void MakeEnemiesStep()
        {
            var command = Strategy.GetNextCommand();
            if (Map.Tank.Coord == Map.FinishCoord)
                IsOver = true;
        }

        private void MakeTankStep()
        {
            throw new System.NotImplementedException();
        }
    }
}
 