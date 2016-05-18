using System;
using System.Collections.Generic;
using GeneticProgramming.Simulator.Strategies;

namespace GeneticProgramming.Genetic.Engine.Types
{
    public class Mutation
    {
        public IEnumerable<Strategy> GetMutatedSpecies(List<Strategy> basePopulation, int mutationCount)
        {
            var rnd = new Random(Guid.NewGuid().GetHashCode());

            for (var i = 0; i < mutationCount; i++)
            {
                var rndAlgorithm = basePopulation[rnd.Next(basePopulation.Count)];
                var changesCount = rnd.Next(rndAlgorithm.commands.Count);

                for (var j = 0; j < changesCount; j++)
                {
                    var index = rnd.Next(rndAlgorithm.commands.Count);
                    var cmd = rndAlgorithm.commands[index];
//                    if (StrategiesGenerator.IsFunction(cmd))
//                        rndAlgorithm.commands[index] = StrategiesGenerator.FunctionSet[rnd.Next(FunctionSet.Count)];

                    rndAlgorithm.commands[index] = cmd;
                }
                yield return rndAlgorithm;
            }
        }
    }
}
