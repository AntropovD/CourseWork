using System;
using System.Linq;

namespace GeneticProgramming.Map
{
    public static class MapGenerator
    {
        public static Map GenerateMap(int width, int height, int obstaclesCount, int enemiesCount)
        {
            var random = new Random();

            var coordSequence = Enumerable.Range(0, width*height)
                .OrderBy(i => random.Next())
                .Select(i => new Coord(i/width, i%width)).ToList();

            var obstacles = coordSequence.Take(obstaclesCount).ToList();
            var enemies = coordSequence.Skip(obstaclesCount).Take(enemiesCount).ToList();

            return new Map(width, height, obstacles, enemies);
        }
    }
}
