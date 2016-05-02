using System;
using System.Linq;

namespace GeneticProgramming.Map
{
    public static class MapGenerator
    {
        public static Map GenerateMap(int width, int height, int obstaclesCount, int enemiesCount)
        {
            var random = new Random(Guid.NewGuid().GetHashCode());

            var coordSequence = Enumerable.Range(0, width*height)
                .OrderBy(i => random.Next())
                .Select(i => new Coord(i/width, i%width)).ToList();

            var obstacles = coordSequence.Take(obstaclesCount).ToList();
            var enemies = coordSequence.Skip(obstaclesCount).Take(enemiesCount).ToList();
            var startCoord = coordSequence.Skip(obstaclesCount + enemiesCount).First();
            
            Coord finishCoord;
            try
            {
                int halfOfBiggerSide = Math.Max(width, height) / 2;
                finishCoord = coordSequence
                    .Skip(obstaclesCount + enemiesCount + 1)
                    .First(coord => Distance(startCoord, coord) > halfOfBiggerSide);
            }
            catch (InvalidOperationException)
            {
                throw new Exception("Cannot create map");
            }

            return new Map(width, height, obstacles, enemies, startCoord, finishCoord);
        }

        private static int Distance(Coord a, Coord b)
        {
            return Math.Abs(a.X - b.X) + Math.Abs(a.Y - b.Y);
        }
    }
}
