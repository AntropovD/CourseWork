using System.Collections.Generic;
using GeneticProgramming.Simulator.Tanks;

namespace GeneticProgramming.Genetic.GeneticEngine
{
    interface IGeneticEngine
    {
        List<Strategy> CrossoverPopulation(List<Strategy> strategies); 
        List<Strategy> MutatePopulation(List<Strategy> strategies);
        List<Strategy> SelectPoplulation(List<Strategy> strategies);
    }
}