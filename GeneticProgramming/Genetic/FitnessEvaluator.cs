using GeneticProgramming.Configurations;
using GeneticProgramming.Simulator;
using GeneticProgramming.Simulator.Maps;
using GeneticProgramming.Simulator.Strategies;

namespace GeneticProgramming.Genetic
{
    public class FitnessEvaluator
    {
        private Strategy EnemyStrategy { get; set; }
        private Map Map { get; set; }

        public FitnessEvaluator(Configuration config)
        {
            CreateAndSerializeMap(config);
            CreateAndSerializeEnemyStrategy(config);
        }

        private void CreateAndSerializeEnemyStrategy(Configuration config)
        {
            var strategyGenerator = new StrategiesGenerator(config.GeneticConfig.MaxStrategySize);
            EnemyStrategy = strategyGenerator.GenerateEnemyProgram();
            StrategySerializator.SerializeToFile(enemyStrategyFile, EnemyStrategy, new FightStat());
        }

        private void CreateAndSerializeMap(Configuration config)
        {
            var mapGenerator = new MapGenerator(config);
            Map = mapGenerator.GenerateMap();
            MapSerializator.Serialize(Map);
        }

        public FightStat countFitness(Strategy tankStrategy)
        {
            var map = new Map(Map);
            var enemyStrategy = new Strategy(EnemyStrategy);
            var battleSimulator = new BattleSimulator(map, tankStrategy, enemyStrategy);
            return battleSimulator.Execute();
        }
        
        private const string enemyStrategyFile = @"Logs\Generations\enemy.strategy";
    }
}
