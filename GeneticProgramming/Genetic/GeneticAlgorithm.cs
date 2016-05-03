
using System.Collections.Generic;
using GeneticProgramming.Genetic.GeneticEngine;
using GeneticProgramming.Genetic.Methods;
using GeneticProgramming.Tank;
using log4net;

namespace GeneticProgramming.Genetic
{
    public class GeneticAlgorithm
    {
        private readonly GeneticConfiguration configuration;
        private IGeneticEngine GeneticEngine;
        private static readonly ILog log =
            LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public GeneticAlgorithm(GeneticConfiguration configuration)
        {
            this.configuration = configuration;
            GeneticEngine = new BaseGeneticEngine(configuration);
        }

        public void Run()
        {
            log.Info("Genetic Programming Started");

            var population = new GeneticPopulation(configuration);
            int index = 0;

            while (true)
            {
                var offsping = GeneticEngine.CrossoverPopulation(population);
                var mutated = GeneticEngine.MutatePopulation(population);
                
                var totalPopulation = new List<TankStrategy>(population.Species);
                totalPopulation.AddRange(offsping.Species);
                totalPopulation.AddRange(mutated.Species);

                var fitnessValue = GeneticEngine.GetFitnessDictionary(totalPopulation);

                log.Info($"Generation #{index}");
                index++;
            }
        }
    }
}
