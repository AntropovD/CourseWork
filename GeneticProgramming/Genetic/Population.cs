using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GeneticProgramming.Genetic.Methods;
using GeneticProgramming.Tank;
using log4net;

namespace GeneticProgramming.Genetic
{
    public class Population
    {
        private int size;
        private int maxLength;
        private Dictionary<TankStrategy, int> population = new Dictionary<TankStrategy, int>();
        private FitnessFunction function;
        private SelectionMethods selectionMethods;

        private static readonly ILog log =
            LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public Population(int populationSize, int maxStrategySize)
        {
            size = populationSize;
            maxLength = maxStrategySize;
            function = new FitnessFunction();
            selectionMethods = new SelectionMethods(populationSize);
        }

        public List<TankStrategy> GetStrategies()
        {
            return population.Keys.ToList();
        }

        public void Initiate()
        {
            population = Enumerable.Range(0, size)
                .ToDictionary(i => GenerateRandomProgram(maxLength), i => -1);
            UpdateCurrentPopulation();
        }
        public void UpdateCurrentPopulation()
        {
            var strategies = GetStrategies();
            population.Clear();
            UpdatePopulation(strategies);
        }

        public void UpdatePopulation(List<TankStrategy> strategies)
        {
            ConcurrentDictionary<TankStrategy, int> tempDictionary = new ConcurrentDictionary<TankStrategy, int>();
            Parallel.ForEach(strategies, strategy =>
            {
                tempDictionary.TryAdd(strategy, function.countValue(strategy));
            });
            foreach (var keyValuePair in tempDictionary)
            {
                population.Add(keyValuePair.Key, keyValuePair.Value);
            }
        }

        public TankStrategy GenerateRandomProgram(int maxStrategySize)
        {
            var commands = Enum.GetValues(typeof(Command));
            var random = new Random(Guid.NewGuid().GetHashCode());

            return new TankStrategy(Enumerable.Range(0, random.Next(maxStrategySize))
                .Select(i => (Command)commands.GetValue(random.Next(commands.Length))));
        }


        public void SelectPopulation()
        {
            population = selectionMethods.GetTournamentSelection(population);
        }

        public void LogInfo()
        {
            int min = population.Min(pair => pair.Value);
            int max = population.Max(pair => pair.Value);
            double average = population.Average(pair => pair.Value);
            double median = GetMedian(population.Values.ToArray());

            log.Info("Population parameters:");
            log.Info($"\\t min fitness: {min}");
            log.Info($"\\t max fitness: {max}");
            log.Info($"\\t average: {average}");
            log.Info($"\\t median: {median}");
        }

        private double GetMedian(int[] values)
        {
            var sorted = values.OrderBy(x => x).ToList();
            double mid = (sorted.Count - 1)/2.0;
            return (sorted[(int) (mid)] + sorted[(int) (mid + 0.5)])/2.0;
        }
    }
}
