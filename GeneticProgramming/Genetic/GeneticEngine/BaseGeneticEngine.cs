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

        public List<TankStrategy> CrossoverPopulation(List<TankStrategy> strategies)
        {
            strategies.AddRange(crossoverMethods.GetPanmixia(strategies));
            strategies.AddRange(crossoverMethods.GetInbreed(strategies));
            strategies.AddRange(crossoverMethods.GetOutbreed(strategies));
            return strategies;
        }

        public List<TankStrategy> MutatePopulation(List<TankStrategy> strategies)
        { 
            int mutationCount = (int)(strategies.Count * config.MutationProb);
            var mutatedSpecies = mutation.GetMutatedSpecies(strategies, mutationCount);
            strategies.AddRange(mutatedSpecies);
            return strategies;
        }
    }
}
