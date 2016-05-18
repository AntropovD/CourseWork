using System.Collections.Generic;
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

        public GeneticEngine(GeneticConfig geneticConfig, StrategyConfig strategyConfig)
        {
            this.geneticConfig = geneticConfig;
            Crossover = new Crossover(geneticConfig, strategyConfig);
            Mutation = new Mutation();
            Selection = new Selection(geneticConfig.PopulationSize);
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
            var mutationCount = (int)(strategies.Count * geneticConfig.MutationProb);
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
