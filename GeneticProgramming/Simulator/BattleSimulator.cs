using System;
using GeneticProgramming.Visualiser;

namespace GeneticProgramming.Simulator
{
    internal class BattleSimulator
    {
        private readonly bool isDebug;
        private BaseVisualiser Visualiser { get; }
        private Battle Battle { get; }

        public BattleSimulator(Battle battle, bool isDebug = false)
        {
            Battle = battle;
            Visualiser = new ConsoleVisualiser();
            this.isDebug = isDebug;
        }

        public int Execute()
        {
            int fitnessValue = 0;
            while (!Battle.IsOver)
            {
                Battle.MakeStep(ref fitnessValue);
                if (isDebug)
                    Visualiser.Visualise(Battle);
                fitnessValue++;
                Console.WriteLine($"{Battle.Strategy.lastCommand} {fitnessValue}");
                Console.WriteLine($"Tanks left: {Battle.Map.AllTanks.Count}");
                Console.ReadKey();
            }
            return fitnessValue;
        }
    }
}