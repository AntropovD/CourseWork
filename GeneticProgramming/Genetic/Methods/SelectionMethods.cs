using System;
using System.Collections.Generic;
using System.Linq;
using GeneticProgramming.Simulator.Tanks;

namespace GeneticProgramming.Genetic.Methods
{
    public class SelectionMethods
    {
        private int populationSize;

        public SelectionMethods(int populationSize)
        {
            this.populationSize = populationSize;
        }

        public Dictionary<TankStrategy, int> GetTournamentSelection(Dictionary<TankStrategy, int> population)
        {
            int size = population.Count;
            var random = new Random(Guid.NewGuid().GetHashCode());
            var array = population.ToList();

            while (size > populationSize)
            {
                int index1 = random.Next(size);
                int index2 = random.Next(size);
                if (array[index1].Value >= array[index2].Value)
                {
                    population.Remove(array[index2].Key);
                    array.RemoveAt(index2);
                    size--;
                }
            }
            return population;
        }
    }
}
