using System;
using System.Collections.Generic;
using GeneticProgramming.Genetic.Methods;
using GeneticProgramming.Panzer;

namespace GeneticProgramming.Genetic.GeneticEngine
{
    internal class BaseGeneticEngine : IGeneticEngine
    {
        private GeneticConfiguration configuration;

        private CrossoverMethods crossoverMethods;
        private MutationMethods mutationMethods;
        private SelectionMethods selectionMethods;

        public BaseGeneticEngine(GeneticConfiguration configuration)
        {
            this.configuration = configuration;
            crossoverMethods = new CrossoverMethods(configuration);
        }
        public int FitnessFunction(PanzerAlgorithm panzerAlgorithm)
        {
            throw new NotImplementedException();
        }

        public GeneticPopulation CrossoverPopulation(GeneticPopulation geneticPopulation)
        {
            var basePopulation = new List<PanzerAlgorithm>(geneticPopulation.Species);
            var resultPopulation = geneticPopulation.Species;
            
            resultPopulation.AddRange(crossoverMethods.GetPanmixia(basePopulation));
            resultPopulation.AddRange(crossoverMethods.GetInbreed(basePopulation));
            resultPopulation.AddRange(crossoverMethods.GetOutbreed(basePopulation));

            geneticPopulation.Species = resultPopulation;
            return geneticPopulation;;
        }

        public GeneticPopulation MutatePopulation(GeneticPopulation geneticPopulation)
        {
            
            var basePopulation = new List<PanzerAlgorithm>(geneticPopulation.Species);
            int mutationCount = (int)(basePopulation.Count * configuration.MutationProb);

            var mutatedSpecies = mutationMethods.GetMutatedSpecies(basePopulation, mutationCount);

            //var resultPopulation = geneticPopulation.Species.Add(CrossoverMethods.);


            return null;
        }

        public GeneticPopulation SelectPopulation(GeneticPopulation geneticPopulation)
        {
            throw new NotImplementedException();
        }
    }
}
