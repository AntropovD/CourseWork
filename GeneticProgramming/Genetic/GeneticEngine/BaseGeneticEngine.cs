using System;
using System.Collections.Generic;
using GeneticProgramming.Panzer;

namespace GeneticProgramming.Genetic.GeneticEngine
{
    internal class BaseGeneticEngine : IGeneticEngine
    {
        private GeneticConfiguration configuration;
        private CrossoverMethods methods;

        public BaseGeneticEngine(GeneticConfiguration configuration)
        {
            this.configuration = configuration;
            methods = new CrossoverMethods(configuration);
        }
        public int FitnessFunction(PanzerAlgorithm panzerAlgorithm)
        {
            throw new NotImplementedException();
        }

        public GeneticPopulation CrossoverPopulation(GeneticPopulation geneticPopulation)
        {
            var basePopulation = new List<PanzerAlgorithm>(geneticPopulation.Species);
            var resultPopulation = geneticPopulation.Species;;
            
            resultPopulation.AddRange(methods.GetPanmixia(basePopulation));
            resultPopulation.AddRange(methods.GetInbreed(basePopulation));
            resultPopulation.AddRange(methods.GetOutbreed(basePopulation));

            geneticPopulation.Species = resultPopulation;
            return geneticPopulation;;
        }

        public GeneticPopulation MutatePopulation(GeneticPopulation geneticPopulation)
        {
            
            var basePopulation = new List<PanzerAlgorithm>(geneticPopulation.Species);
            int mutationCount = (int)(basePopulation.Count * configuration.MutationProb);

            var mutatedSpecies = methods.Mutate(basePopulation, mutationCount);

            //var resultPopulation = geneticPopulation.Species.Add(CrossoverMethods.);


            return null;
        }

        public GeneticPopulation SelectPopulation(GeneticPopulation geneticPopulation)
        {
            throw new NotImplementedException();
        }
    }
}
