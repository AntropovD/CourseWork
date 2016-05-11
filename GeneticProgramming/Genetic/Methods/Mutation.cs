using System;
using System.Collections.Generic;
using GeneticProgramming.Simulator;

namespace GeneticProgramming.Genetic.Methods
{
    public class Mutation
    {
        public IEnumerable<Strategy> GetMutatedSpecies(List<Strategy> basePopulation, int mutationCount)
        {
            var rnd = new Random(Guid.NewGuid().GetHashCode());

            for (int i = 0; i < mutationCount; i++)
            {
                var rndAlgorithm = basePopulation[rnd.Next(basePopulation.Count)];
                int changesCount = rnd.Next(rndAlgorithm.commands.Count);

                for (int j = 0; j < changesCount; j++)
                {
                    int index = rnd.Next(rndAlgorithm.commands.Count);
                    string cmd = rndAlgorithm.commands[index];
//                    if (StrategiesGenerator.IsFunction(cmd))
//                        rndAlgorithm.commands[index] = StrategiesGenerator.FunctionSet[rnd.Next(FunctionSet.Count)];

                    rndAlgorithm.commands[index] = cmd;
                }
                yield return rndAlgorithm;
            }
        }
    }
}
