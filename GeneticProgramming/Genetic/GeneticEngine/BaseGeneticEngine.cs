using System;
using System.Collections.Generic;
using GeneticProgramming.Genetic.Methods;
using GeneticProgramming.Tank;

namespace GeneticProgramming.Genetic.GeneticEngine
{
    internal class BaseGeneticEngine : IGeneticEngine
    {
        private readonly GeneticConfiguration configuration;
        private readonly CrossoverMethods crossoverMethods;
        private readonly Mutation mutation;

        public BaseGeneticEngine(GeneticConfiguration configuration)
        {
            this.configuration = configuration;
            crossoverMethods = new CrossoverMethods(configuration);
            mutation = new Mutation();
        }

        public List<TankStrategy> CrossoverPopulation(List<TankStrategy> strategies)
        {
            strategies.AddRange(crossoverMethods.GetPanmixia(strategies));
            strategies.AddRange(crossoverMethods.GetInbreed(strategies));
            strategies.AddRange(crossoverMethods.GetOutbreed(strategies));
            return strategies;
        }

        public List<TankStrategy> MutatePopulation(List<TankStrategy> strategies)
        { 
            int mutationCount = (int)(strategies.Count * configuration.MutationProb);
            var mutatedSpecies = mutation.GetMutatedSpecies(strategies, mutationCount);
            strategies.AddRange(mutatedSpecies);
            return strategies;
        }
    }
}
