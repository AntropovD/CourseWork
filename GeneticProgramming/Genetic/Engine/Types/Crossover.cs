using System;
using System.Collections.Generic;
using GeneticProgramming.Configurations.PartialConfigs;
using GeneticProgramming.Genetic.Methods;
using GeneticProgramming.Simulator.Strategies;

namespace GeneticProgramming.Genetic.Engine.Types
{
    public class Crossover
    {
        private readonly GeneticConfig geneticConfig;
        private readonly StrategyConfig strategyConfig;

        public Crossover(GeneticConfig geneticConfig, StrategyConfig strategyConfig)
        {
            this.geneticConfig = geneticConfig;
            this.strategyConfig = strategyConfig;
        }

        public IEnumerable<Strategy> GetPanmixia(List<Strategy> strategies)
        {
            int panmixiaCount = (int)(strategies.Count * geneticConfig.PanmixiaRatio * geneticConfig.CrossoverProb);
            var random = new Random(Guid.NewGuid().GetHashCode());

            for (int i = 0; i < panmixiaCount; i++)
            {
                var strategy1 = strategies[random.Next(strategies.Count)];
                var strategy2 = strategies[random.Next(strategies.Count)];
                yield return StrategyCrossoverMethods.Crossover(strategy1, strategy2, strategyConfig.MaxStrategySize);
            }
        }

        public IEnumerable<Strategy> GetInbreed(List<Strategy> strategies)
        {
            int inbreedCount = (int) (strategies.Count * geneticConfig.InbreedRatio * geneticConfig.CrossoverProb);
            var random = new Random(Guid.NewGuid().GetHashCode());

            for (int i = 0; i < inbreedCount; i++)
            {
                var strategy1 = strategies[random.Next(strategies.Count)];
                var strategy2 = strategy1.FindMostLikely(strategies);
                yield return StrategyCrossoverMethods.Crossover(strategy1, strategy2, strategyConfig.MaxStrategySize);
            }
        }

        public IEnumerable<Strategy> GetOutbreed(List<Strategy> strategies)
        {
            int outbreedCount = (int) (strategies.Count * geneticConfig.OutbreedRatio * geneticConfig.CrossoverProb);
            var random = new Random(Guid.NewGuid().GetHashCode());

            for (int i = 0; i < outbreedCount; i++)
            {
                var strategy1 = strategies[random.Next(strategies.Count)];
                var strategy2 = strategy1.FindMostUnlikely(strategies);
                yield return StrategyCrossoverMethods.Crossover(strategy1, strategy2, strategyConfig.MaxStrategySize);
            }
        }
    }
}
