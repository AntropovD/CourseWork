using System;
using System.Linq;

namespace GeneticProgramming.Genetic.Engine.Types
{
    public class Selection
    {
        private readonly int populationSize;

        public Selection(int populationSize)
        {
            this.populationSize = populationSize;
        }

        public void MakeTournamentSelection(Population population)
        {
            var size = population.SpeciesAndValues.Count;
            var random = new Random(Guid.NewGuid().GetHashCode());
            var array = population.SpeciesAndValues.ToList();

            while (size > populationSize)
            {
                var index1 = random.Next(size);
                var index2 = random.Next(size);
                if (array[index1].Value.Result >= array[index2].Value.Result)
                {
                    population.SpeciesAndValues.Remove(array[index2].Key);
                    array.RemoveAt(index2);
                    size--;
                }
            }
        }

        public void MakeMaximalSelection(Population population)
        {
            var array = population.SpeciesAndValues.
                OrderByDescending(pair => pair.Value).ToList();
            foreach (var keyValuePair in array.Skip(populationSize))
            {
                population.SpeciesAndValues.Remove(keyValuePair.Key);
            }
        }
    }
}
