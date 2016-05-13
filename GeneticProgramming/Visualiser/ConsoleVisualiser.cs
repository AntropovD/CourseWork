using System;
using GeneticProgramming.Simulator.Maps;

namespace GeneticProgramming.Visualiser
{
    class ConsoleVisualiser : BaseVisualiser
    {
        public override void Visualise(Map map)
        {
            Console.Clear();
            string[] field = GetField(map);
            foreach (var s in field)
            {
                Console.WriteLine(s);
            }
        }
    }
}
