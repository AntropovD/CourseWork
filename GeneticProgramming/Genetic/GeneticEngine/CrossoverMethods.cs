using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeneticProgramming.Panzer;

namespace GeneticProgramming.Genetic.GeneticEngine
{
    public class CrossoverMethods
    {
        private readonly GeneticConfiguration configuration;

        public CrossoverMethods(GeneticConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public IEnumerable<PanzerAlgorithm> GetPanmixia(List<PanzerAlgorithm> basePopulation)
        {
            int panmixiaxCount = (int)(basePopulation.Count * configuration.PanmixiaRatio);
            var random = new Random(Guid.NewGuid().GetHashCode());

            for (int i = 0; i < panmixiaxCount; i++)
            {
                var specimen1 = basePopulation[random.Next(basePopulation.Count)];
                var specimen2 = basePopulation[random.Next(basePopulation.Count)];
                yield return CrossoverSpecies(specimen1, specimen2);
            }
        }

        public IEnumerable<PanzerAlgorithm> GetInbreed(List<PanzerAlgorithm> basePopulation)
        {
            int inbreedCount = (int) (basePopulation.Count*configuration.InbreedRatio);
            var random = new Random(Guid.NewGuid().GetHashCode());

            for (int i = 0; i < inbreedCount; i++)
            {
                var specimen1 = basePopulation[random.Next(basePopulation.Count)];
                var specimen2 = FindMostLikely(basePopulation, specimen1);
                yield return CrossoverSpecies(specimen1, specimen2);
            }
        }

        public IEnumerable<PanzerAlgorithm> GetOutbreed(List<PanzerAlgorithm> basePopulation)
        {
            int outbreedCount = (int) (basePopulation.Count*configuration.OutbreedRatio);
            var random = new Random(Guid.NewGuid().GetHashCode());

            for (int i = 0; i < outbreedCount; i++)
            {
                var specimen1 = basePopulation[random.Next(basePopulation.Count)];
                var specimen2 = FindMostUnlikely(basePopulation, specimen1);
                yield return CrossoverSpecies(specimen1, specimen2);
            }
        }

        public PanzerAlgorithm CrossoverSpecies(PanzerAlgorithm specimen1, PanzerAlgorithm specimen2)
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

            var firstPart = specimen1.commands.GetRange(0, firstIndex);
            var secondPart = specimen2.commands.GetRange(secondIndex, specimen2.commands.Count - secondIndex);
            firstPart.AddRange(secondPart);
            
            return new PanzerAlgorithm(firstPart);
        }
        
        public PanzerAlgorithm FindMostLikely(List<PanzerAlgorithm> basePopulation, PanzerAlgorithm specimen)
        {
            return basePopulation.Max(algo => Tuple.Create(HammingDistance(algo, specimen), algo)).Item2;
        }
        public PanzerAlgorithm FindMostUnlikely(List<PanzerAlgorithm> basePopulation, PanzerAlgorithm specimen)
        {
            return basePopulation.Min(algo => Tuple.Create(HammingDistance(algo, specimen), algo)).Item2;
        }

        public int HammingDistance(PanzerAlgorithm algo, PanzerAlgorithm specimen)
        {
            int count = 0;
            for (int i = 0; i < Math.Min(algo.commands.Count, specimen.commands.Count); i++)
                if (algo.commands[i] == specimen.commands[i])
                    count++;
            return count;
        }
    }
}
