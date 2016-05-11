using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using GeneticProgramming.Configurations;
using GeneticProgramming.Simulator.Tanks;
using log4net;
using static GeneticProgramming.Extensions.MedianCounter;

namespace GeneticProgramming.Genetic
{
    public class Population
    {
        private readonly int size;
        private readonly int maxLength;
        private readonly Dictionary<Strategy, int> population;
        private static readonly FitnessFunction function = new FitnessFunction();
        private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public Population(GeneticConfig config)
        {
            size = config.PopulationSize;
            maxLength = config.MaxStrategyLength;
            population = InitiatePopulation();
        }

        private Population(int size, int maxLength, List<Strategy> selectedStrategies)
        {
            this.size = size;
            this.maxLength = maxLength;
            population = selectedStrategies.ToDictionary(strategy => strategy, strategy => function.countValue(strategy));
        }

        public List<Strategy> GetStrategies()
        {
            return population.Keys.ToList();
        }

        private Dictionary<Strategy, int> InitiatePopulation()
        {
            var generator = new StrategiesGenerator(maxLength);
            var initialPopulation = Enumerable.Range(0, size).Select(i => generator.GenerateProgram());
            return CountFitnessValues(initialPopulation);
        }

        private Dictionary<Strategy, int> CountFitnessValues(IEnumerable<Strategy> initialPopulation)
        {
            return initialPopulation.ToDictionary(strategy => strategy, strategy => function.countValue(strategy));
        }

        public Population UpdatePopulation(List<Strategy> selectedStrategies)
        {
            return new Population(size, maxLength, selectedStrategies);
        }
    
        public void LogInfo(int index)
        {
            log.Info($"Generation #{index}");
            int min = population.Min(pair => pair.Value);
            int max = population.Max(pair => pair.Value);
            double average = population.Average(pair => pair.Value);
            double median = GetMedian(population.Values.ToArray());
            log.Info($@"Population parameters: Min fitness: {min}, Max fitness: {max}, Average: {average} Median: {median}");
        }

        public void LogAllStrategies(int index)
        {
            string folderName = $"Logs\\Generation{index}";
            Directory.CreateDirectory(folderName);
            int j = 0;
            foreach (var i in population)
            {
                File.WriteAllText($"{folderName}\\{j}st-{i.Value}.gen", string.Join(" ", i.Key.commands));
                j++;
            }
        }

        public bool HasAnyFinished()
        {
            return population.Any(pair => pair.Value > 10000);
        }
    }
}
/*
public void UpdateInitialPopulation()
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
        population.AddOrUpdate(keyValuePair.Key, keyValuePair.Value);
    }
}

public void SelectPopulation()
{
    population = selectionMethods.GetTournamentSelection(population);
}
*/
