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
        private GeneticConfiguration configuration;

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
                var specimen2 = basePopulation[random.Next(basePopulation.Count)];
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
                var specimen2 = basePopulation[random.Next(basePopulation.Count)];
                yield return CrossoverSpecies(specimen1, specimen2);
            }
        }

        public PanzerAlgorithm CrossoverSpecies(PanzerAlgorithm specimen1, PanzerAlgorithm specimen2)
        {
            throw new NotImplementedException();
        }
    }
}
