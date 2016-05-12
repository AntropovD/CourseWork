using System;
using System.Collections.Generic;
using GeneticProgramming.Configurations;
using GeneticProgramming.Genetic.Methods;
using GeneticProgramming.Simulator.Strategies;

namespace GeneticProgramming.Genetic.Engine.Types
{
    public class Crossover
    {
        private readonly GeneticConfig config;

        public Crossover(GeneticConfig config)
        {
            this.config = config;
        }

        public IEnumerable<Strategy> GetPanmixia(List<Strategy> strategies)
        {
            int panmixiaCount = (int)(strategies.Count * config.PanmixiaRatio * config.CrossoverProb);
            var random = new Random(Guid.NewGuid().GetHashCode());

            for (int i = 0; i < panmixiaCount; i++)
            {
                var strategy1 = strategies[random.Next(strategies.Count)];
                var strategy2 = strategies[random.Next(strategies.Count)];
                yield return StrategyCrossoverMethods.Crossover(strategy1, strategy2, config.MaxStrategyLength);
            }
        }

        public IEnumerable<Strategy> GetInbreed(List<Strategy> strategies)
        {
            int inbreedCount = (int) (strategies.Count * config.InbreedRatio * config.CrossoverProb);
            var random = new Random(Guid.NewGuid().GetHashCode());

            for (int i = 0; i < inbreedCount; i++)
            {
                var strategy1 = strategies[random.Next(strategies.Count)];
                var strategy2 = strategy1.FindMostLikely(strategies);
                yield return StrategyCrossoverMethods.Crossover(strategy1, strategy2, config.MaxStrategyLength);
            }
        }

        public IEnumerable<Strategy> GetOutbreed(List<Strategy> strategies)
        {
            int outbreedCount = (int) (strategies.Count * config.OutbreedRatio * config.CrossoverProb);
            var random = new Random(Guid.NewGuid().GetHashCode());

            for (int i = 0; i < outbreedCount; i++)
            {
                var strategy1 = strategies[random.Next(strategies.Count)];
                var strategy2 = strategy1.FindMostUnlikely(strategies);
                yield return StrategyCrossoverMethods.Crossover(strategy1, strategy2, config.MaxStrategyLength);
            }
        }
    }
}
