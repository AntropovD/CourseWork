﻿using GeneticProgramming.Simulator.Maps;
using GeneticProgramming.Simulator.Tanks;
using GeneticProgramming.Simulator.Visualiser;

namespace GeneticProgramming.Simulator
{
    public class BattleSimulator
    {
        private Map Map { get; set; }
        private int fitnessValue;

        private bool visual;
        private BaseVisualiser visualiser;

        public BattleSimulator(Map Map, bool visual = false)
        {
            this.Map = Map;
            this.visual = visual;
            visualiser = new ConsoleVisualiser();
        }
        
        public void Execute(TankStrategy strategy)
        {
            int result = 0;
            foreach (var command in strategy.commands)
            {
                MakeStep(command);
                if (visual) 
                    visualiser.Visualise(Map);
                if (Map.Tank.Coord == Map.FinishCoord)
                    result += 1000;
                result++;
            }
            fitnessValue = result;
        }

        private void MakeStep(string command)
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
