using System;
using System.Collections.Generic;
using GeneticProgramming.Configurations;
using GeneticProgramming.Simulator.Tanks;

namespace GeneticProgramming.Genetic.Methods
{
    public class CrossoverMethods
    {
        private readonly GeneticConfig _config;

        public CrossoverMethods(GeneticConfig _config)
        {
            this._config = _config;
        }

        public IEnumerable<TankStrategy> GetPanmixia(List<TankStrategy> strategies)
        {
            int panmixiaCount = (int)(strategies.Count * _config.PanmixiaRatio * _config.CrossoverProb);
            var random = new Random(Guid.NewGuid().GetHashCode());

            for (int i = 0; i < panmixiaCount; i++)
            {
                var strategy1 = strategies[random.Next(strategies.Count)];
                var strategy2 = strategies[random.Next(strategies.Count)];
                yield return strategy1.Crossover(strategy2, _config.MaxStrategySize);
            }
        }

        public IEnumerable<TankStrategy> GetInbreed(List<TankStrategy> strategies)
        {
            int inbreedCount = (int) (strategies.Count * _config.InbreedRatio * _config.CrossoverProb);
            var random = new Random(Guid.NewGuid().GetHashCode());

            for (int i = 0; i < inbreedCount; i++)
            {
                var strategy1 = strategies[random.Next(strategies.Count)];
                var strategy2 = strategy1.FindMostLikely(strategies);
                yield return strategy1.Crossover(strategy2, _config.MaxStrategySize);
            }
        }

        public IEnumerable<TankStrategy> GetOutbreed(List<TankStrategy> strategies)
        {
            int outbreedCount = (int) (strategies.Count * _config.OutbreedRatio * _config.CrossoverProb);
            var random = new Random(Guid.NewGuid().GetHashCode());

            for (int i = 0; i < outbreedCount; i++)
            {
                var strategy1 = strategies[random.Next(strategies.Count)];
                var strategy2 = strategy1.FindMostLikely(strategies);
                yield return strategy1.Crossover(strategy2, _config.MaxStrategySize);
            }
        }
    }
}
