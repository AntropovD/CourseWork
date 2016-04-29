using GeneticProgramming.Panzer;

namespace GeneticProgramming.Genetic.GeneticEngine
{
    public interface IGeneticEngine
    {
        int FitnessFunction(PanzerAlgorithm panzerAlgorithm);
        Population CrossPopulation(Population population);
        Population MutatePopulation(Population population);
        Population SelectPopulation(Population population);
    }
}