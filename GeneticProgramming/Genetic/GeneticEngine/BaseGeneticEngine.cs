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

        public Population CrossPopulation(Population population)
        {
            var basePopulation = new List<PanzerAlgorithm>(population.Species);
            var resultPopulation = population.Species;

            int crossoverCount = (int) (basePopulation.Count*configuration.CrossoverProb);

            var methods = new CrossoverMethods(configuration);
            
            resultPopulation.AddRange(methods.GetPanmixia(basePopulation));
            resultPopulation.AddRange(methods.GetInbreed(basePopulation));
            resultPopulation.AddRange(methods.GetOutbreed(basePopulation));
            
            /*
           
            */
            return null;
        }

        
        

        public Population MutatePopulation(Population population)
        {
            var basePopulation = new List<PanzerAlgorithm>(population.Species);
            int mutationCount = (int)(basePopulation.Count * configuration.MutationProb);

            return null;
        }

        public Population SelectPopulation(Population population)
        {
            throw new NotImplementedException();
        }
    }
}
