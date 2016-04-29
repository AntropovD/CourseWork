using System;
using System.Collections.Generic;
using GeneticProgramming.Panzer;
using Ninject;

namespace GeneticProgramming.Genetic.GeneticEngine
{
    internal class BaseGeneticEngine : IGeneticEngine
    {
        private GeneticConfiguration configuration;

        public BaseGeneticEngine(GeneticConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public int FitnessFunction(PanzerAlgorithm panzerAlgorithm)
        {
            throw new NotImplementedException();
        }

        public GeneticPopulation CrossPopulation(GeneticPopulation geneticPopulation)
        {
            var basePopulation = new List<PanzerAlgorithm>(geneticPopulation.Species);
            var resultPopulation = geneticPopulation.Species;

            int crossoverCount = (int) (basePopulation.Count*configuration.CrossoverProb);

            var methods = new CrossoverMethods(configuration);
            
            resultPopulation.AddRange(methods.GetPanmixia(basePopulation));
            resultPopulation.AddRange(methods.GetInbreed(basePopulation));
            resultPopulation.AddRange(methods.GetOutbreed(basePopulation));
            
            /*
           
            */
            return null;
        }

        
        

        public GeneticPopulation MutatePopulation(GeneticPopulation geneticPopulation)
        {
            var basePopulation = new List<PanzerAlgorithm>(geneticPopulation.Species);
            int mutationCount = (int)(basePopulation.Count * configuration.MutationProb);

            return null;
        }

        public GeneticPopulation SelectPopulation(GeneticPopulation geneticPopulation)
        {
            throw new NotImplementedException();
        }
    }
}
