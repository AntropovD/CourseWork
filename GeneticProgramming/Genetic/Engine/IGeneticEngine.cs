using System.Collections.Generic;
using GeneticProgramming.Simulator.Strategies;

namespace GeneticProgramming.Genetic.Engine
{
    interface IGeneticEngine
    {
        List<Strategy> CrossoverStrategies(List<Strategy> strategies); 
        List<Strategy> MutateStrategies(List<Strategy> strategies);
        Population SelectPopulation(Population population);
    }
}