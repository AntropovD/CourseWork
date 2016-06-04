using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using GeneticProgramming.Configurations;
using GeneticProgramming.Configurations.PartialConfigs;
using GeneticProgramming.Extensions;
using GeneticProgramming.Simulator;
using GeneticProgramming.Simulator.Strategies;
using log4net;

namespace GeneticProgramming.Genetic.Engine
{
    public class Population
    {
        private readonly int size;
        private readonly int maxLength;
        public Dictionary<Strategy, FightStat> SpeciesAndValues { get; set; }
        private static FitnessEvaluator Evaluator;
        private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        
        public Population(Configuration config)
        {
            size = config.GeneticConfig.PopulationSize;
            maxLength = config.GeneticConfig.MaxStrategySize;
            SpeciesAndValues = new Dictionary<Strategy, FightStat>();
            Evaluator = new FitnessEvaluator(config);
            InitiatePopulation(config.StrategyGeneratorConfig);
        }

        public List<Strategy> GetStrategies()
        {
            return SpeciesAndValues.Keys.ToList();
        }

        private void InitiatePopulation(StrategyGeneratorConfig strategyGeneratorConfig)
        {
            var generator = new StrategiesGenerator(maxLength, strategyGeneratorConfig);
            var initialStrategies = Enumerable.Range(0, size).Select(i => generator.GenerateProgram());
            UpdateStrategies(initialStrategies);
        }

        public void UpdateStrategies(IEnumerable<Strategy> strategies)
        {
            ConcurrentDictionary<Strategy, FightStat> tempDictionary = new ConcurrentDictionary<Strategy, FightStat>();
            Parallel.ForEach(strategies, strategy =>
            {
                tempDictionary.TryAdd(strategy, Evaluator.countFitness(strategy));
            });
            foreach (var pair in tempDictionary)
            {
                SpeciesAndValues.AddOrUpdate(pair.Key, pair.Value);
            }
//            foreach (var strategy in strategies)
//            {
//                SpeciesAndValues.AddOrUpdate(strategy, Evaluator.countFitness(strategy));
//            }
        }
        
        public bool HasAnyFinished()
        {
            return SpeciesAndValues.Any(pair => pair.Value.Result >= 10000);
        }
    }
}