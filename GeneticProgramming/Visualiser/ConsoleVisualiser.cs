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
            foreach (var s in field)
            {
                Console.WriteLine(s);
            }
        }
    }
}
