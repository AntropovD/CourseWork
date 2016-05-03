using System;
using System.Collections.Generic;
using System.Linq;
using GeneticProgramming.Genetic.Methods;
using GeneticProgramming.Tank;

namespace GeneticProgramming.Genetic.GeneticEngine
{
    internal class BaseGeneticEngine : IGeneticEngine
    {
        private GeneticConfiguration configuration;

        private CrossoverMethods crossoverMethods;
        private Mutation mutation;
        private SelectionMethods selectionMethods;

        public BaseGeneticEngine(GeneticConfiguration configuration)
        {
            this.configuration = configuration;
            crossoverMethods = new CrossoverMethods(configuration);
            mutation = new Mutation();
            selectionMethods = new SelectionMethods();
        }
        public int FitnessFunction(TankStrategy tankStrategy)
        {
            return new Random(Guid.NewGuid().GetHashCode()).Next();
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

        public Dictionary<TankStrategy, int> SelectPopulation(List<TankStrategy> strategies)
        {
            throw new NotImplementedException();
        }

        public Dictionary<TankStrategy, int> GetFitnessDictionary(IEnumerable<TankStrategy> totalPopulation)
        {
            return totalPopulation.ToDictionary(tankStrategy => tankStrategy, FitnessFunction);
        }
    }
}
