using System;
using GeneticProgramming.Simulator;
using GeneticProgramming.Simulator.Strategies;

namespace GeneticProgramming.Genetic
{
    public class FitnessEvaluator
    {
//        private BattleSimulator simulator = new BattleSimulator();

        public int countFitness(Strategy tankStrategy)
        {
//            simulator.Execute(tankStrategy);
//            return simulator.GetFitness();
            var rnd = new Random(Guid.NewGuid().GetHashCode());
            return rnd.Next(1000);
        }
    }
}
