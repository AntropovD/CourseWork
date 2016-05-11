using System;
using System.Collections.Generic;
using GeneticProgramming.Configurations;
using GeneticProgramming.Simulator;

namespace GeneticProgramming.Genetic.Methods
{
    internal class GeneticEngine : IGeneticEngine
    {
        private readonly GeneticConfig config;
        private Crossover Crossover { get; }
        private Mutation Mutation { get; }
        private Selection Selection { get; }

        public GeneticEngine(GeneticConfig config)
        {
            this.config = config;
            Crossover = new Crossover(config);
            Mutation = new Mutation();
            Selection = new Selection(config.PopulationSize);
        }

        public List<Strategy> CrossoverStrategies(List<Strategy> strategies)
        {
            strategies.AddRange(Crossover.GetPanmixia(strategies));
            strategies.AddRange(Crossover.GetInbreed(strategies));
            strategies.AddRange(Crossover.GetOutbreed(strategies));
            return strategies;
        }

        public List<Strategy> MutateStrategies(List<Strategy> strategies)
        { 
            int mutationCount = (int)(strategies.Count * config.MutationProb);
            var mutatedSpecies = Mutation.GetMutatedSpecies(strategies, mutationCount);
            strategies.AddRange(mutatedSpecies);
            return strategies;
        }

        public Population SelectPopulation(Population population)
        {
            Selection.MakeTournamentSelection(population);
            return population;
        }
        /*
        public Dictionary<Strategy, int> SelectPoplulation(Dictionary<Strategy, int> population, List<string> strategies)
        {
            throw new NotImplementedException();
        }

        public Population SelectPoplulation(Population population)
        {
            return null;//Selection.GetTournamentSelection(population);
        }*/
    }
}
