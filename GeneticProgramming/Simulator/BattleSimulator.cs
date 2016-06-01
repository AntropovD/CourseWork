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
            var fitnessStat = new FightStat();
            while (!Battle.IsOver)
            {
                Battle.MakeStep(fitnessStat);
                Visualise(fitnessStat);
                fitnessStat.Steps++;
            }
            Visualise(fitnessStat);
            return fitnessStat.Result(Battle);
        }

       

        private void Visualise(FightStat fitnessValue)
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