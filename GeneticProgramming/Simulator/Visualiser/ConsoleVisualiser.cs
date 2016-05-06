using System;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using GeneticProgramming.Auxillary;
using GeneticProgramming.Simulator.Maps;
using static System.String;

namespace GeneticProgramming.Simulator
{
    abstract class BaseVisualiser
    {
        protected string[] GetField(Map map)
        {
            string[] result = GenerateEmptyFieldWithBorder(map.Width, map.Height);
            
            result [map.FinishCoord.Y] = result[map.FinishCoord.Y].ReplaceIndex(map.FinishCoord.X, 'F');
//            result [map.]
            
            return result;
        }

        protected string[] GenerateEmptyFieldWithBorder(int width, int height)
        {
            string[] result = new string[height + 2];
            result[0] = Concat(Enumerable.Repeat("#", width + 2));
            for (int i = 1; i <= height; i++)
                result[i] = Concat("#", String.Join("", Enumerable.Repeat(" ", width)), "#");
            result[height + 1] = Concat(Enumerable.Repeat("#", width + 2));

            return result;
        }

        public abstract void Visualise(Map map); 

    }

    class ConsoleVisualiser : BaseVisualiser
    {
        public override void Visualise(Map map)
        {
            string[] field = GetField(map);
            Console.Clear();
            foreach (var s in field)
            {
                Console.WriteLine(s);
            }
            Console.ReadKey();
        }
    }
}
