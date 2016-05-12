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
            int size = population.SpeciesAndValues.Count;
            var random = new Random(Guid.NewGuid().GetHashCode());
            var array = population.SpeciesAndValues.ToList();

            while (size > populationSize)
            {
                int index1 = random.Next(size);
                int index2 = random.Next(size);
                if (array[index1].Value >= array[index2].Value)
                {
                    population.SpeciesAndValues.Remove(array[index2].Key);
                    array.RemoveAt(index2);
                    size--;
                }
            }
        }
    }
}
