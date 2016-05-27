using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using GeneticProgramming.Configurations;
using GeneticProgramming.Extensions;
using GeneticProgramming.Simulator.Strategies;
using log4net;

namespace GeneticProgramming.Genetic.Engine
{
    public class Population
    {
        private readonly int size;
        private readonly int maxLength;
        public Dictionary<Strategy, int> SpeciesAndValues { get; set; }
        private static FitnessEvaluator Evaluator;
        private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        
        public Population(Configuration config)
        {
            size = config.GeneticConfig.PopulationSize;
            maxLength = config.GeneticConfig.MaxStrategySize;
            SpeciesAndValues = new Dictionary<Strategy, int>();
            Evaluator = new FitnessEvaluator(config);
            InitiatePopulation();
        }

        public List<Strategy> GetStrategies()
        {
            return SpeciesAndValues.Keys.ToList();
        }

        private void InitiatePopulation()
        {
            var generator = new StrategiesGenerator(maxLength);
            var initialStrategies = Enumerable.Range(0, size).Select(i => generator.GenerateProgram());
            UpdateStrategies(initialStrategies);
        }

        public void UpdateStrategies(IEnumerable<Strategy> strategies)
        {
//            ConcurrentDictionary<Strategy, int> tempDictionary = new ConcurrentDictionary<Strategy, int>();
//            Parallel.ForEach(strategies, strategy =>
//            {
//                tempDictionary.TryAdd(strategy, Evaluator.countFitness(strategy));
//            });
//            foreach (var pair in tempDictionary)
//            {
//                SpeciesAndValues.AddOrUpdate(pair.Key, pair.Value);
//            }
            foreach (var strategy in strategies)
            {
                SpeciesAndValues.AddOrUpdate(strategy, Evaluator.countFitness(strategy));
            }
        }
        
        public void LogInfo(int index)
        {
            log.Info($"Generation #{index}");
            var min = SpeciesAndValues.Min(pair => pair.Value);
            var max = SpeciesAndValues.Max(pair => pair.Value);
            var average = SpeciesAndValues.Average(pair => pair.Value);
            var median = MedianCounter.GetMedian(SpeciesAndValues.Values.ToArray());
            log.Info($@"Population parameters: Min fitness: {min}, Max fitness: {max}, Average: {average} Median: {median}");
        }

        public void LogAllStrategies(int index)
        {
            string folderName = $"Logs\\Generations\\Generation{index}";
            Directory.CreateDirectory(folderName);
            var j = 0;
            foreach (var pair in SpeciesAndValues)
            {
                File.WriteAllText($"{folderName}\\#{j} fitness={pair.Value}", string.Join(" ", pair.Key.commands));
                j++;
            }
        }

        public bool HasAnyFinished()
        {
            return SpeciesAndValues.Any(pair => pair.Value > 1000);
        }
    }
}