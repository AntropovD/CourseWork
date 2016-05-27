using System;
using GeneticProgramming.Simulator;

namespace GeneticProgramming.Visualiser
{
    class ConsoleVisualiser 
    {
        public void Visualise(Battle battle)
        {
            var fieldBuilder = new FieldBuilder();
            Console.Clear();
            var field = fieldBuilder.GetField(battle.Map);

            for (int i = 0; i < battle.Map.Height + 2; i++)
            {
                for (int j = 0; j < battle.Map.Width + 2; j++)
                    Console.Write(field[i, j]);
                Console.WriteLine();
            }
        }
    }
}
