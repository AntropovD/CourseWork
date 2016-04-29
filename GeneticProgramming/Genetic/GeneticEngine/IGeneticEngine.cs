namespace GeneticProgramming.Genetic
{
    public interface IGeneticTools
    {
        int FitnessFunction(PanzerAlgorithm panzerAlgorithm);
        Population CrossPopulation(Population population);
        Population MutatePopulation(Population population);
        Population SelectPopulation(Population population);

    }
}