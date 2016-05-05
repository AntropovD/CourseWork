using System.Collections.Generic;
using GeneticProgramming.Simulator.Tanks;

namespace GeneticProgramming.Genetic.GeneticEngine
{
    interface IGeneticEngine
    {
        List<TankStrategy> CrossoverPopulation(List<TankStrategy> strategies); 
        List<TankStrategy> MutatePopulation(List<TankStrategy> strategies);
    }
}