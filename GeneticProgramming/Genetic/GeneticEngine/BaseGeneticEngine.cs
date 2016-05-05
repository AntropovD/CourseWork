using System.Collections.Generic;
using GeneticProgramming.Genetic.Methods;
using GeneticProgramming.Simulator.Tanks;

namespace GeneticProgramming.Genetic.GeneticEngine
{
    internal class BaseGeneticEngine : IGeneticEngine
    {
        private readonly GeneticConfig _config;
        private readonly CrossoverMethods crossoverMethods;
        private readonly Mutation mutation;

        public BaseGeneticEngine(GeneticConfig _config)
        {
            this._config = _config;
            crossoverMethods = new CrossoverMethods(_config);
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
            int mutationCount = (int)(strategies.Count * _config.MutationProb);
            var mutatedSpecies = mutation.GetMutatedSpecies(strategies, mutationCount);
            strategies.AddRange(mutatedSpecies);
            return strategies;
        }
    }
}
