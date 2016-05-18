using GeneticProgramming.Configurations;
using GeneticProgramming.Simulator;
using GeneticProgramming.Simulator.Maps;
using GeneticProgramming.Simulator.Strategies;

namespace GeneticProgramming.Genetic
{
    public class FitnessEvaluator
    {
        private Battle Battle { get; }
        private Strategy Strategy { get; }
        private Strategy EnemyStrategy { get; }
        private Map Map { get; }

        public FitnessEvaluator(Configuration config)
        {
            var strategyGenerator = new StrategiesGenerator(config.StrategyConfig.MaxStrategySize);
            Strategy = strategyGenerator.GenerateProgram();
            EnemyStrategy = strategyGenerator.GenerateEnemyProgram();

            var mapGenerator = new MapGenerator(config);
            Map = mapGenerator.GenerateMap();
        }

        public int countFitness(Strategy tankStrategy)
        {
            ResetStrategies();
            var map = new Map(Map);
            var battleSimulator = new BattleSimulator(map, tankStrategy, EnemyStrategy);
            return battleSimulator.Execute();
        }

        private void ResetStrategies()
        {
            Strategy.Reset();
            EnemyStrategy.Reset();
        }
    }
}
