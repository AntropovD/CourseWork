using System;
using GeneticProgramming.Simulator;

namespace GeneticProgramming.Genetic
{
    public class FitnessFunction
    {
//        private BattleSimulator simulator = new BattleSimulator();

        public int countValue(Strategy tankStrategy)
        {
//            simulator.Execute(tankStrategy);
//            return simulator.GetFitness();
            var rnd = new Random(Guid.NewGuid().GetHashCode());
            return rnd.Next(1000);
        }
    }
}
