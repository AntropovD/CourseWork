using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using GeneticProgramming.Tank;

namespace GeneticProgramming.Genetic.GeneticEngine
{
    public interface IGeneticEngine
    {
        int FitnessFunction(TankStrategy tankStrategy);

        List<TankStrategy> CrossoverPopulation(List<TankStrategy> strategies); 
        List<TankStrategy> MutatePopulation(List<TankStrategy> strategies);
        Dictionary<TankStrategy, int> SelectPopulation(List<TankStrategy> strategies);
    }
}