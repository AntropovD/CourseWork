using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeneticProgramming.Map;

namespace Examples
{
    class Program
    {
        static void Main(string[] args)
        {
            var map = MapGenerator.GenerateMap(10, 10, 2, 3);

            foreach (var enemy in map.Enemies)
                Console.WriteLine($"{enemy.X} {enemy.Y}");

            foreach (var obstacle in map.Obstacles)
                Console.WriteLine($"{obstacle.X} {obstacle.Y}");

        }
    }
}
