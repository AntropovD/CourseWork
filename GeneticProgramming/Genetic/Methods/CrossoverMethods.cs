using System;
using System.Collections.Generic;
using System.Linq;
using GeneticProgramming.Tank;

namespace GeneticProgramming.Genetic.GeneticEngine
{
    public class CrossoverMethods
    {
        private readonly GeneticConfiguration configuration;

        public CrossoverMethods(GeneticConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public IEnumerable<TankStrategy> GetPanmixia(List<TankStrategy> basePopulation)
        {
            int panmixiaCount = (int)(basePopulation.Count * configuration.PanmixiaRatio * configuration.CrossoverProb);
            var random = new Random(Guid.NewGuid().GetHashCode());

            for (int i = 0; i < panmixiaCount; i++)
            {
                var strategy1 = basePopulation[random.Next(basePopulation.Count)];
                var strategy2 = basePopulation[random.Next(basePopulation.Count)];
                yield return strategy1.Crossover(strategy2, configuration.MaximumProgramSize);
            }
        }

        public IEnumerable<TankStrategy> GetInbreed(List<TankStrategy> basePopulation)
        {
            int inbreedCount = (int) (basePopulation.Count * configuration.InbreedRatio * configuration.CrossoverProb);
            var random = new Random(Guid.NewGuid().GetHashCode());

            for (int i = 0; i < inbreedCount; i++)
            {
                var strategy1 = basePopulation[random.Next(basePopulation.Count)];
                var strategy2 = strategy1.FindMostLikely(basePopulation);
                yield return strategy1.Crossover(strategy2, configuration.MaximumProgramSize);
            }
        }

        public IEnumerable<TankStrategy> GetOutbreed(List<TankStrategy> basePopulation)
        {
            int outbreedCount = (int) (basePopulation.Count * configuration.OutbreedRatio * configuration.CrossoverProb);
            var random = new Random(Guid.NewGuid().GetHashCode());

            for (int i = 0; i < outbreedCount; i++)
            {
                var strategy1 = basePopulation[random.Next(basePopulation.Count)];
                var strategy2 = strategy1.FindMostLikely(basePopulation);
                yield return strategy1.Crossover(strategy2, configuration.MaximumProgramSize);
            }
        }
    }
}
