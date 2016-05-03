using System.Collections.Generic;
using GeneticProgramming.Tank;

namespace GeneticProgramming.Genetic.GeneticEngine
{
    public interface IGeneticEngine
    {
        int FitnessFunction(TankStrategy tankStrategy);
        GeneticPopulation CrossoverPopulation(GeneticPopulation geneticPopulation);
        GeneticPopulation MutatePopulation(GeneticPopulation geneticPopulation);
        GeneticPopulation SelectPopulation(GeneticPopulation geneticPopulation);
        Dictionary<TankStrategy, int> GetFitnessDictionary(List<TankStrategy> totalPopulation);
    }
}