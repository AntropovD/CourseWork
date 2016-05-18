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
            var fitnessValue = 0;
            while (!Battle.IsOver)
            {
                Battle.MakeStep(ref fitnessValue);
                if (isDebug)
                    Visualiser.Visualise(Battle);
                fitnessValue++;
                Console.WriteLine($"{Battle.Strategy.LastCommand} {fitnessValue}");
                Console.WriteLine($"Tanks left: {Battle.Map.AllTanks.Count}");
                Console.ReadKey();
            }
            return fitnessValue;
        }

    }
}

//
//public int Execute()
//{
//    int fitnessValue = 0;
//    while (!Battle.IsOver)
//    {
//        Battle.MakeStep(ref fitnessValue);
//        fitnessValue++;
//    }
//    return fitnessValue;
//}