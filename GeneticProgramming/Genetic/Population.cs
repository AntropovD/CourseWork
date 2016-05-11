using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using GeneticProgramming.Extensions;
using GeneticProgramming.Genetic.Methods;
using GeneticProgramming.Simulator.Tanks;
using log4net;
using static GeneticProgramming.Extensions.MathExtension;

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
            LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public Population(int populationSize, int MaxStrategyLength)
        {
            size = populationSize;
            maxLength = MaxStrategyLength;
            function = new FitnessFunction();
            selectionMethods = new SelectionMethods(populationSize);
        }

        public List<TankStrategy> GetStrategies()
        {
            return population.Keys.ToList();
        }

        public void Initiate()
        {
           /* population = Enumerable.Range(0, size)
                .ToDictionary(i => GenerateRandomProgram(maxLength), i => -1);*/
            UpdateInitialPopulation();
        }

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

        public void LogInfo()
        {
            int min = population.Min(pair => pair.Value);
            int max = population.Max(pair => pair.Value);
            double average = population.Average(pair => pair.Value);
            double median = GetMedian(population.Values.ToArray());

            log.Info($@"Population parameters: Min fitness: {min}, Max fitness: {max}, Average: {average} Median: {median}");
        }
    }
}
