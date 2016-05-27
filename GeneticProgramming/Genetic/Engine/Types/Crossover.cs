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

        public Crossover(GeneticConfig geneticConfig)
        {
            this.geneticConfig = geneticConfig;
        }

        public IEnumerable<Strategy> GetPanmixia(List<Strategy> strategies)
        {
            var panmixiaCount = (int)(strategies.Count * geneticConfig.PanmixiaRatio * geneticConfig.CrossoverProb);
            var random = new Random(Guid.NewGuid().GetHashCode());

            for (var i = 0; i < panmixiaCount; i++)
            {
                var strategy1 = strategies[random.Next(strategies.Count)];
                var strategy2 = strategies[random.Next(strategies.Count)];
                yield return StrategyCrossoverMethods.Crossover(strategy1, strategy2, geneticConfig.MaxStrategySize);
            }
        }

        public IEnumerable<Strategy> GetInbreed(List<Strategy> strategies)
        {
            var inbreedCount = (int) (strategies.Count * geneticConfig.InbreedRatio * geneticConfig.CrossoverProb);
            var random = new Random(Guid.NewGuid().GetHashCode());

            for (var i = 0; i < inbreedCount; i++)
            {
                var strategy1 = strategies[random.Next(strategies.Count)];
                var strategy2 = strategy1.FindMostLikely(strategies);
                yield return StrategyCrossoverMethods.Crossover(strategy1, strategy2, geneticConfig.MaxStrategySize);
            }
        }

        public IEnumerable<Strategy> GetOutbreed(List<Strategy> strategies)
        {
            var outbreedCount = (int) (strategies.Count * geneticConfig.OutbreedRatio * geneticConfig.CrossoverProb);
            var random = new Random(Guid.NewGuid().GetHashCode());

            for (var i = 0; i < outbreedCount; i++)
            {
                var strategy1 = strategies[random.Next(strategies.Count)];
                var strategy2 = strategy1.FindMostUnlikely(strategies);
                yield return StrategyCrossoverMethods.Crossover(strategy1, strategy2, geneticConfig.MaxStrategySize);
            }
        }
    }
}
