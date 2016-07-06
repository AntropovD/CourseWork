using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using GeneticProgramming.Configurations;
using GeneticProgramming.Genetic;
using log4net;

namespace GeneticProgramming
{
    public class Program
    {
        private const string ConfigFilename = "config.xml";

        public static void Main()
        {
            RunGeneticProgram();
            //CountStatistics();
        }

        private static void CountStatistics()
        {
            var configuration = Configuration.DeserializeFromFile(ConfigFilename);

            var times = new List<long>();
            var succeded = new List<bool>();
            var generatioons = new List<int>();

            var sw = new Stopwatch();
            for (int i = 0; i < 50; i++)
            {
                var  geneticAlgorithm = new GeneticAlgorithm(configuration);
                sw.Start();
                var pop = geneticAlgorithm.RunAndGetPopulation();
                times.Add(sw.ElapsedMilliseconds);
                sw.Stop();
                sw.Reset();
                succeded.Add(pop.HasAnyFinished());
                generatioons.Add(pop.Index);

                logger.Info($"Solution {i}");
                logger.Info($"Average time: {times.Average()}");
                logger.Info($"Success: {Percentage(succeded)}");
                logger.Info($"Averate generations: {generatioons.Average()}");
            }
            
            logger.Info(string.Join(" ", times));
            logger.Info(string.Join(" ", succeded));
            logger.Info(string.Join(" ", generatioons));
        }

        private static string Percentage(List<bool> succeded)
        {
            double res = succeded.Count(s => s) * 100.0 /succeded.Count;
            return $"{res}%";
        }


        private static readonly ILog logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private static void RunGeneticProgram()
        {
            var configuration = Configuration.DeserializeFromFile(ConfigFilename);
            var geneticAlgorithm = new GeneticAlgorithm(configuration);
            geneticAlgorithm.Run();
        }
    }
}