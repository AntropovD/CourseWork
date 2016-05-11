using System;
using System.Collections.Generic;
using GeneticProgramming.Configurations;
using GeneticProgramming.Genetic.Methods;
using GeneticProgramming.Simulator.Tanks;

namespace GeneticProgramming.Genetic.GeneticEngine
{
    internal class BaseGeneticEngine : IGeneticEngine
    {
        private readonly GeneticConfig config;
        private readonly CrossoverMethods crossoverMethods;
        private readonly Mutation mutation;

        public BaseGeneticEngine(GeneticConfig config)
        {
            this.config = config;
            crossoverMethods = new CrossoverMethods(config);
            mutation = new Mutation();
        }

        public List<Strategy> CrossoverPopulation(List<Strategy> strategies)
        {
            strategies.AddRange(crossoverMethods.GetPanmixia(strategies));
            strategies.AddRange(crossoverMethods.GetInbreed(strategies));
            strategies.AddRange(crossoverMethods.GetOutbreed(strategies));
            return strategies;
        }

        public List<Strategy> MutatePopulation(List<Strategy> strategies)
        { 
            int mutationCount = (int)(strategies.Count * config.MutationProb);
            var mutatedSpecies = mutation.GetMutatedSpecies(strategies, mutationCount);
            strategies.AddRange(mutatedSpecies);
            return strategies;
        }

        public List<Strategy> SelectPoplulation(List<Strategy> strategies)
        {
            throw new NotImplementedException();
        }
    }
}
