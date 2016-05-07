using System;
using System.Collections.Generic;
using System.Linq;
using GeneticProgramming.Auxillary;
using GeneticProgramming.Configurations;
using GeneticProgramming.Simulator.Tanks;

namespace GeneticProgramming.Simulator.Maps
{
    public class MapGenerator
    {
        private MapConfig MapConfig { get; set; }

        public MapGenerator(Configurations.MapConfig mapConfig)
        {
            MapConfig = mapConfig;
        }

        private List<Coord> GenerateRandomCoords()
        {
            int width = MapConfig.Width;
            int height = MapConfig.Height;
            var rnd = new Random(Guid.NewGuid().GetHashCode());
            return Enumerable.Range(0, width*height)
                .OrderBy(i => rnd.Next())
                .Select(i => new Coord(i/width, i%width))
                .ToList();
        }

        public Map GenerateMap()
        {
           /* var coordSequence = GenerateRandomCoords().ToList();

            var obstacles = coordSequence.Take(MapConfig.ObstaclesCount).ToList();
            coordSequence.RemoveRange(0, MapConfig.ObstaclesCount);
            var enemies = coordSequence.Take(MapConfig.EnemiesCount).ToList();
            coordSequence.RemoveRange(0, MapConfig.EnemiesCount);
            var startCoord = coordSequence.First();
            coordSequence.RemoveAt(0);
            var finishCoord = coordSequence.First();
            coordSequence.RemoveAt(0);
            var tankCoord = coordSequence.First();
          */

            var coordsList = GenerateRandomCoords();
            var obstacles = coordsList.TakeRange(MapConfig.ObstaclesCount);
            var enemies = coordsList.TakeRange(MapConfig.EnemiesCount);
            var startCoord = coordsList.FirstAndRemove();
            var finishCoord = coordsList.FirstAndRemove();
            
            return new Map(MapConfig.Width, MapConfig.Height, obstacles, enemies, startCoord, finishCoord);
            /*
            Coord finishCoord;
            try
            {
                int halfOfBiggerSide = Math.Max(MapConfig.Width, MapConfig.Height) / 2;
                finishCoord = coordSequence
                    .Skip(MapConfig.ObstaclesCount + MapConfig.EnemiesCount + 1)
                    .First(coord => Distance(startCoord, coord) > halfOfBiggerSide);
            }
            catch (InvalidOperationException)
            {
                throw new Exception("Cannot create map");
            }*/

        //    return new Map(MapConfig.Width, MapConfig.Height, obstacles, enemies, startCoord, finishCoord);
        }
    
        private static int Distance(Coord a, Coord b)
        {
            return Math.Abs(a.X - b.X) + Math.Abs(a.Y - b.Y);
        }
    }
}
