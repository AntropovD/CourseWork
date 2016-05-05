using GeneticProgramming.Simulator.Maps;
using GeneticProgramming.Simulator.Tanks;

namespace GeneticProgramming.Simulator
{
    public class BattleSimulator
    {
        private Map Map { get; set; }
        private int fitnessValue = 0;

        public BattleSimulator()
        {
            Map = MapGenerator.GenerateMap();
        }
        
        public void Execute(TankStrategy strategy)
        {
            Map = MapGenerator.GenerateMap();
            int result = 0;
            foreach (var command in strategy.commands)
            {
                MakeStep(command);
                if (Map.Tank.Coord == Map.FinishCoord)
                    result += 1000;
                result++;
            }
            fitnessValue = result;
        }

        private void MakeStep(Command command)
        {
            Coord nextCoord = Map.Tank.NextStep(command);
            if (IsPossible(nextCoord))
            {
                Map.Tank.Coord = nextCoord;
            }
        }

        private bool IsPossible(Coord nextCoord)
        {
            return true;
        }

        public int GetFitness()
        {
            return fitnessValue;
        }
    }
}
