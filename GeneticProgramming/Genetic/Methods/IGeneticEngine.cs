using System.Collections.Generic;
using GeneticProgramming.Simulator;

namespace GeneticProgramming.Genetic.Methods
{
    interface IGeneticEngine
    {
        List<Strategy> CrossoverStrategies(List<Strategy> strategies); 
        List<Strategy> MutateStrategies(List<Strategy> strategies);
        Population SelectPopulation(Population population);
    }
}