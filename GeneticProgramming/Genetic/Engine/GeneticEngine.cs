using System.Collections.Generic;
using System.Linq;
using GeneticProgramming.Configurations.PartialConfigs;
using GeneticProgramming.Genetic.Engine.Types;
using GeneticProgramming.Simulator.Strategies;

namespace GeneticProgramming.Genetic.Engine
{
    internal class GeneticEngine : IGeneticEngine
    {
        private readonly GeneticConfig geneticConfig;
        private Crossover Crossover { get; }
        private Mutation Mutation { get; }
        private Selection Selection { get; }

        public GeneticEngine(GeneticConfig geneticConfig)
        {
            this.geneticConfig = geneticConfig;
            Crossover = new Crossover(geneticConfig);
            Mutation = new Mutation();
            Selection = new Selection(geneticConfig.PopulationSize);
        }

        public List<Strategy> CrossoverStrategies(List<Strategy> strategies)
        {
            var result = new List<Strategy>();
            result.AddRange(Crossover.GetPanmixia(strategies));
            result.AddRange(Crossover.GetInbreed(strategies));
            result.AddRange(Crossover.GetOutbreed(strategies));
            return result;
        }

        public List<Strategy> MutateStrategies(List<Strategy> strategies)
        {
            var mutationCount = (int)(strategies.Count * geneticConfig.MutationProb);
            var mutatedSpecies = Mutation.GetMutatedSpecies(strategies, mutationCount);
            return mutatedSpecies.ToList();
        }

        public Population SelectPopulation(Population population)
        {
            Selection.MakeTournamentSelection(population);
           // Selection.MakeMaximalSelection(population);
            return population;
        }
    }
}
