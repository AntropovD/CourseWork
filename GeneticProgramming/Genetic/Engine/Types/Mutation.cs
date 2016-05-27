using System;
using System.Collections.Generic;
using GeneticProgramming.Simulator.Strategies;
using static GeneticProgramming.Simulator.Modules.StrategyTokens;

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
                MakeRandomChanges(rndAlgorithm, changesCount);
                yield return rndAlgorithm;
            }
        }

        public void MakeRandomChanges(Strategy algorithm, int count)
        {
            var rnd = new Random(Guid.NewGuid().GetHashCode());
            for (var j = 0; j < count; j++)
            {
                var index = rnd.Next(algorithm.commands.Count);
                var cmd = algorithm.commands[index];
            
                if (IsFunction(cmd))
                    algorithm.commands[index] = GetRandomFunction();

                if (IsTerminal(cmd))
                    algorithm.commands[index] = GetRandomTerminal();
            }
        }
    }
}
