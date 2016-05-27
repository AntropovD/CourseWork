using GeneticProgramming.Configurations;
using GeneticProgramming.Simulator;
using GeneticProgramming.Simulator.Maps;
using GeneticProgramming.Simulator.Strategies;

namespace GeneticProgramming.Genetic
{
    public class FitnessEvaluator
    {
        private Strategy EnemyStrategy { get; }
        private Map Map { get; }

        public FitnessEvaluator(Configuration config)
        {
            var strategyGenerator = new StrategiesGenerator(config.GeneticConfig.MaxStrategySize);
            EnemyStrategy = strategyGenerator.GenerateEnemyProgram();

            var mapGenerator = new MapGenerator(config);
            Map = mapGenerator.GenerateMap();
            EnemyStrategy.Serialize();
            MapSerializator.Serialize(Map);
        }

        public int countFitness(Strategy tankStrategy)
        {
            var map = new Map(Map);
            var enemyStrategy = new Strategy(EnemyStrategy);
            var battleSimulator = new BattleSimulator(map, tankStrategy, enemyStrategy);
            return battleSimulator.Execute();
        }
    }
}
