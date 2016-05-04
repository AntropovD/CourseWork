using System.Collections.Generic;
using GeneticProgramming.Tank;

namespace GeneticProgramming.Genetic.GeneticEngine
{
    public interface IGeneticEngine
    {
        List<TankStrategy> CrossoverPopulation(List<TankStrategy> strategies); 
        List<TankStrategy> MutatePopulation(List<TankStrategy> strategies);
    }
}