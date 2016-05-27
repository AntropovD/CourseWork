using System;
using GeneticProgramming.Simulator.Maps;
using GeneticProgramming.Simulator.Strategies;
using GeneticProgramming.Visualiser;

namespace GeneticProgramming.Simulator
{
    public class BattleSimulator
    {
        private readonly bool isDebug;
        private ConsoleVisualiser Visualiser { get; }
        private Battle Battle { get; }
        
        public BattleSimulator(Map map, Strategy strategy, Strategy enemyStrategy, bool isDebug = false)
        {
            Visualiser = new ConsoleVisualiser();
            Battle = new Battle(map, strategy, enemyStrategy);
            this.isDebug = isDebug;
        }

        public int Execute()
        {
            int fitnessValue = 0;
            while (!Battle.IsOver)
            {
                Battle.MakeStep(ref fitnessValue);
                Visualise(fitnessValue);
                fitnessValue++;
            }
            fitnessValue += countNearMetric();
            Visualise(fitnessValue);
            return fitnessValue;
        }

        private int countNearMetric()
        {
            int d1 = Distance(Battle.Map.Tank.Coord, Battle.Map.FinishCoord);
            int d2 = Distance(Battle.Map.StartCoord, Battle.Map.FinishCoord);
            return (d2 - d1)*10;
        }

        private int Distance(Coord startCoord, Coord finishCoord)
        {
            return startCoord.X - finishCoord.X + startCoord.Y - finishCoord.Y;
        }

        private void Visualise(int fitnessValue)
        {
            if (isDebug)
            {
                Visualiser.Visualise(Battle);
                Console.WriteLine($"{Battle.Map.Tank.Strategy.LastCommand} {fitnessValue}");
                Console.WriteLine($"Tanks left: {Battle.Map.Enemies.Count}");
                System.Threading.Thread.Sleep(100);
            }
        }
    }
}