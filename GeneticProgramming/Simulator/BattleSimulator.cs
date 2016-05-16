using System;
using GeneticProgramming.Simulator.Maps;
using GeneticProgramming.Simulator.Strategies;
using GeneticProgramming.Visualiser;

namespace GeneticProgramming.Simulator
{
    internal class BattleSimulator
    {

        //        private readonly bool isDebug;
        // private BaseVisualiser Visualiser { get; }
        private Battle Battle { get; }
        
        public BattleSimulator(Map map, Strategy strategy, Strategy enemyStrategy)
        {
            Battle = new Battle(map, strategy, enemyStrategy);
        }

        public int Execute()
        {
            int fitnessValue = 0;
            while (!Battle.IsOver)
            {
                Battle.MakeStep(ref fitnessValue);
                fitnessValue++;
            }
            return fitnessValue;
        }
    }
}


//public int Execute()
//{
//    int fitnessValue = 0;
//    while (!Battle.IsOver)
//    {
//        Battle.MakeStep(ref fitnessValue);
//        if (isDebug)
//            Visualiser.Visualise(Battle);
//        fitnessValue++;
//        Console.WriteLine($"{Battle.Strategy.lastCommand} {fitnessValue}");
//        Console.WriteLine($"Tanks left: {Battle.Map.AllTanks.Count}");
//        Console.ReadKey();
//    }
//    return fitnessValue;
//}