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
                var specimen1 = basePopulation[random.Next(basePopulation.Count)];
                var specimen2 = basePopulation[random.Next(basePopulation.Count)];
                yield return CrossoverSpecies(specimen1, specimen2);
            }
        }

        public IEnumerable<TankStrategy> GetInbreed(List<TankStrategy> basePopulation)
        {
            int inbreedCount = (int) (basePopulation.Count * configuration.InbreedRatio * configuration.CrossoverProb);
            var random = new Random(Guid.NewGuid().GetHashCode());

            for (int i = 0; i < inbreedCount; i++)
            {
                var specimen1 = basePopulation[random.Next(basePopulation.Count)];
                var specimen2 = FindMostLikely(basePopulation, specimen1);
                yield return CrossoverSpecies(specimen1, specimen2);
            }
        }

        public IEnumerable<TankStrategy> GetOutbreed(List<TankStrategy> basePopulation)
        {
            int outbreedCount = (int) (basePopulation.Count * configuration.OutbreedRatio * configuration.CrossoverProb);
            var random = new Random(Guid.NewGuid().GetHashCode());

            for (int i = 0; i < outbreedCount; i++)
            {
                var specimen1 = basePopulation[random.Next(basePopulation.Count)];
                var specimen2 = FindMostUnlikely(basePopulation, specimen1);
                yield return CrossoverSpecies(specimen1, specimen2);
            }
        }

        public TankStrategy CrossoverSpecies(TankStrategy specimen1, TankStrategy specimen2)
        {
            var random = new Random(Guid.NewGuid().GetHashCode());
            int firstIndex = random.Next(specimen1.commands.Count);
            int secondIndex = random.Next(specimen2.commands.Count);

            if (firstIndex + secondIndex > configuration.MaximumProgramSize)
            {
                int diff = (firstIndex + secondIndex) - configuration.MaximumProgramSize;
                if (diff%2 == 1) diff++;
                firstIndex -= diff << 1;
                secondIndex -= diff << 1;
            }

            var firstPart = specimen1.commands.Take(firstIndex).ToList();
            var secondPart = specimen2.commands.Skip(specimen2.commands.Count - secondIndex).Take(secondIndex);
            firstPart.AddRange(secondPart);
            
            return new TankStrategy(firstPart);
        }
        
        public TankStrategy FindMostLikely(List<TankStrategy> basePopulation, TankStrategy specimen)
        {
            return basePopulation.Where(algo => algo != specimen)
                    .Max(algo => Tuple.Create(HammingDistance(algo, specimen), algo)).Item2;
        }
        public TankStrategy FindMostUnlikely(List<TankStrategy> basePopulation, TankStrategy specimen)
        {
            return basePopulation.Where(algo => algo != specimen)
                    .Min(algo => Tuple.Create(HammingDistance(algo, specimen), algo)).Item2;
        }

        public int HammingDistance(TankStrategy algo, TankStrategy specimen)
        {
            int count = 0;
            for (int i = 0; i < Math.Min(algo.commands.Count, specimen.commands.Count); i++)
                if (algo.commands[i] == specimen.commands[i])
                    count++;
            return count;
        }
      
    }
}
