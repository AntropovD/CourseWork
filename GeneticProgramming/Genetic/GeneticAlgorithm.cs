
using System.Collections.Generic;
using System.Linq;
using GeneticProgramming.Genetic.GeneticEngine;
using GeneticProgramming.Genetic.Methods;
using GeneticProgramming.Tank;
using log4net;

namespace GeneticProgramming.Genetic
{
    public class GeneticAlgorithm
    {
        private readonly GeneticConfiguration configuration;
        private readonly IGeneticEngine GeneticEngine;
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

            List<TankStrategy> strategies = new PopulationInitializer().Initiate(configuration.PopulationSize,
                configuration.MaxStrategySize);
            int index = 0;
            /*
            while (true)
            {
                var offsping = GeneticEngine.CrossoverPopulation(strategies);
                var mutated = GeneticEngine.MutatePopulation(strategies);
                
                var totalPopulation = new List<TankStrategy>(strategies.Species);
                totalPopulation.AddRange(offsping.Species);
                totalPopulation.AddRange(mutated.Species);

                var fitnessValue = GeneticEngine.GetFitnessDictionary(totalPopulation.Distinct());

                strategies = GeneticEngine.SelectPopulation(fitnessValue);
                //LogInformation(p)
                log.Info($"Generation #{index}");
                index++;
            }*/
        }
    }
}
