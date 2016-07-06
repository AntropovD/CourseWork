using System;
using System.IO;
using System.Linq;
using System.Reflection;
using GeneticProgramming.Genetic.Engine;
using GeneticProgramming.Simulator.Strategies;
using log4net;

namespace GeneticProgramming.Genetic
{
    public class GeneticLogger
    {
        private static readonly string directory = "Logs\\Generations\\";

        private static readonly ILog logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public void Start()
        {
            logger.Info("Genetic Programming Started");
            try
            {
                if (Directory.Exists(directory))
                    Directory.Delete(directory, true);
            }
            catch (Exception)
            {
                logger.Error("Cannot delete folder");
            }
        }

        public void LogGeneration(Population population)
        {
            LogPopulationInfo(population);
            LogAllStrategies(population);
        }

        private void LogPopulationInfo(Population population)
        {
            logger.Info($"Generation #{population.Index}");
            var speciesAndValues = population.SpeciesAndValues;
            var min = speciesAndValues.Min(pair => pair.Value.Result);
            var max = speciesAndValues.Max(pair => pair.Value.Result);
            var average = speciesAndValues.Average(pair => pair.Value.Result);
            logger.Info($@"Min fitness: {min}, Max fitness: {max}, Average: {average}");
        }

        private void LogAllStrategies(Population population)
        {
            string folderName = $"{directory}Generation{population.Index}";
            try
            {
                if (Directory.Exists(folderName))
                    Directory.Delete(folderName, true);
                Directory.CreateDirectory(folderName);
            }
            catch (Exception)
            {
                logger.Error("Cannot create population directory");
            }
            int index = 0;
            foreach (var pair in population.SpeciesAndValues)
            {
                string filename = $"{folderName}\\#{index} - fitness={pair.Value.Result}";
                try
                {
                    StrategySerializator.SerializeToFile(filename, pair.Key, pair.Value);
                }
                catch (Exception)
                {
                    logger.Error($"Cannot create file {filename}");
                }
                index++;
            }
        }

        public void InitiateMessage()
        {
            logger.Info("Finish creating initial population");
        }
    }
}