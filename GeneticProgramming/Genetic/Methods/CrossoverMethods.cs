using System;
using System.Collections.Generic;
using GeneticProgramming.Tank;

namespace GeneticProgramming.Genetic.Methods
{
    public class CrossoverMethods
    {
        private readonly GeneticConfiguration configuration;

        public CrossoverMethods(GeneticConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public IEnumerable<TankStrategy> GetPanmixia(List<TankStrategy> strategies)
        {
            int panmixiaCount = (int)(strategies.Count * configuration.PanmixiaRatio * configuration.CrossoverProb);
            var random = new Random(Guid.NewGuid().GetHashCode());

            for (int i = 0; i < panmixiaCount; i++)
            {
                var strategy1 = strategies[random.Next(strategies.Count)];
                var strategy2 = strategies[random.Next(strategies.Count)];
                yield return strategy1.Crossover(strategy2, configuration.MaxStrategySize);
            }
        }

        public IEnumerable<TankStrategy> GetInbreed(List<TankStrategy> strategies)
        {
            int inbreedCount = (int) (strategies.Count * configuration.InbreedRatio * configuration.CrossoverProb);
            var random = new Random(Guid.NewGuid().GetHashCode());

            for (int i = 0; i < inbreedCount; i++)
            {
                var strategy1 = strategies[random.Next(strategies.Count)];
                var strategy2 = strategy1.FindMostLikely(strategies);
                yield return strategy1.Crossover(strategy2, configuration.MaxStrategySize);
            }
        }

        public IEnumerable<TankStrategy> GetOutbreed(List<TankStrategy> strategies)
        {
            int outbreedCount = (int) (strategies.Count * configuration.OutbreedRatio * configuration.CrossoverProb);
            var random = new Random(Guid.NewGuid().GetHashCode());

            for (int i = 0; i < outbreedCount; i++)
            {
                var strategy1 = strategies[random.Next(strategies.Count)];
                var strategy2 = strategy1.FindMostLikely(strategies);
                yield return strategy1.Crossover(strategy2, configuration.MaxStrategySize);
            }
        }
    }
}
