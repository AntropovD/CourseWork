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

        public FightStat Execute()
        {
            var fitnessStat = new FightStat();
            while (!Battle.IsOver)
            {
                Battle.MakeStep(fitnessStat);
                Visualise(fitnessStat);
            }
            Visualise(fitnessStat);
            fitnessStat.CountFitness(Battle);
            return fitnessStat;
        }

        private void Visualise(FightStat fitnessValue)
        {
            if (isDebug)
            {
                Visualiser.Visualise(Battle);
                fitnessValue.CountFitness(Battle);
                Console.WriteLine($"LastCommand: {Battle.Map.Tank.Strategy.LastCommand} ");
                Console.WriteLine($"FitnessValue: {fitnessValue.Result}");
                Console.WriteLine($"Steps: {fitnessValue.Steps}");
                Console.WriteLine($"Killed: {fitnessValue.Killed}");
                Console.WriteLine($"EnemiesKilledEachOther:{fitnessValue.EnemiesKilledByEnemies} ");
                Console.WriteLine($"Tanks left: {Battle.Map.Enemies.Count} ");
                System.Threading.Thread.Sleep(1000);
            }
        }
    }
}