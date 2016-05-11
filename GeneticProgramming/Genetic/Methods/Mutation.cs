using System;
using System.Collections.Generic;
using GeneticProgramming.Simulator.Tanks;

namespace GeneticProgramming.Genetic.Methods
{
    public class Mutation
    {
        public IEnumerable<TankStrategy> GetMutatedSpecies(List<TankStrategy> basePopulation, int mutationCount)
        {
            var random = new Random(Guid.NewGuid().GetHashCode());
            var strings = Enum.GetValues(typeof(string));

            for (int i = 0; i < mutationCount; i++)
            {
                var rndAlgorithm = basePopulation[random.Next(basePopulation.Count)];
                int changesCount = random.Next(rndAlgorithm.commands.Count);

                for (int j = 0; j < changesCount; j++)
                {
                    int index = random.Next(rndAlgorithm.commands.Count);
                    string cmd = (string)strings.GetValue(random.Next(strings.Length));
                    rndAlgorithm.commands[index] = cmd;
                }
                yield return rndAlgorithm;
            }
        }
    }
}
