using GeneticProgramming.Simulator;
using GeneticProgramming.Simulator.Tanks;

namespace GeneticProgramming.Genetic
{
    public class FitnessFunction
    {
//        private BattleSimulator simulator = new BattleSimulator();

        public FitnessFunction()
        {
            
        }

        public int countValue(TankStrategy tankStrategy)
        {
//            simulator.Execute(tankStrategy);
//            return simulator.GetFitness();
            return 100;
        }
    }
}
