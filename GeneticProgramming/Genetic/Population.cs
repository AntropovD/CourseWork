using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using GeneticProgramming.Configurations;
using GeneticProgramming.Extensions;
using GeneticProgramming.Simulator;
using log4net;
using static GeneticProgramming.Extensions.MedianCounter;

namespace GeneticProgramming.Genetic
{
    public class Population
    {
        private readonly int size;
        private readonly int maxLength;
        public Dictionary<Strategy, int> SpeciesAndValues { get; set; }
        private static readonly FitnessEvaluator Evaluator = new FitnessEvaluator();
        private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public Population(GeneticConfig config)
        {
            size = config.PopulationSize;
            maxLength = config.MaxStrategyLength;
            SpeciesAndValues = new Dictionary<Strategy, int>();
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
            ConcurrentDictionary<Strategy, int> tempDictionary = new ConcurrentDictionary<Strategy, int>();
            Parallel.ForEach(strategies, strategy =>
            {
                tempDictionary.TryAdd(strategy, Evaluator.countFitness(strategy));
            });
            foreach (var keyValuePair in tempDictionary)
            {
                SpeciesAndValues.AddOrUpdate(keyValuePair.Key, keyValuePair.Value);
            }
        }
        
        public void LogInfo(int index)
        {
            log.Info($"Generation #{index}");
            int min = SpeciesAndValues.Min(pair => pair.Value);
            int max = SpeciesAndValues.Max(pair => pair.Value);
            double average = SpeciesAndValues.Average(pair => pair.Value);
            double median = GetMedian(SpeciesAndValues.Values.ToArray());
            log.Info($@"Population parameters: Min fitness: {min}, Max fitness: {max}, Average: {average} Median: {median}");
        }

        public void LogAllStrategies(int index)
        {
            string folderName = $"Logs\\Generation{index}";
            Directory.CreateDirectory(folderName);
            int j = 0;
            foreach (var pair in SpeciesAndValues)
            {
                File.WriteAllText($"{folderName}\\{j}st-{pair.Value}.gen", string.Join(" ", pair.Key.commands));
                j++;
            }
        }

        public bool HasAnyFinished()
        {
            return SpeciesAndValues.Any(pair => pair.Value > 10000);
        }
    }
}