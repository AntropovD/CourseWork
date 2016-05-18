using System;
using System.Collections.Generic;
using System.Linq;
using GeneticProgramming.Simulator.Strategies;

namespace GeneticProgramming.Genetic.Methods
{
    public static class StrategyGeneticExtensions
    {
        public static Strategy FindMostLikely(this Strategy strategy, List<Strategy> basePopulation)
        {
            return basePopulation.Where(algo => algo != strategy)
                    .Max(algo => Tuple.Create(HammingDistance(strategy, algo), algo)).Item2;
        }

        public static Strategy FindMostUnlikely(this Strategy strategy, List<Strategy> basePopulation)
        {
            return basePopulation.Where(algo => algo != strategy)
                    .Min(algo => Tuple.Create(HammingDistance(strategy, algo), algo)).Item2;
        }

        public static int HammingDistance(Strategy firstStrategy, Strategy secondStrategy)
        {
            var count = 0;
            for (var i = 0; i < Math.Min(firstStrategy.commands.Count, secondStrategy.commands.Count); i++)
                if (firstStrategy.commands[i] == secondStrategy.commands[i])
                    count++;
            return count;
        }
    }
}
