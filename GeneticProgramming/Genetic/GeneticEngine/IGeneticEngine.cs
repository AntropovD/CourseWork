using GeneticProgramming.Panzer;

namespace GeneticProgramming.Genetic.GeneticEngine
{
    public interface IGeneticEngine
    {
        int FitnessFunction(PanzerAlgorithm panzerAlgorithm);
        GeneticPopulation CrossPopulation(GeneticPopulation geneticPopulation);
        GeneticPopulation MutatePopulation(GeneticPopulation geneticPopulation);
        GeneticPopulation SelectPopulation(GeneticPopulation geneticPopulation);
    }
}