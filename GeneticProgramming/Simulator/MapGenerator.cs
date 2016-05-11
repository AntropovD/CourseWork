using System;
using System.Collections.Generic;
using System.Linq;
using GeneticProgramming.Configurations;
using GeneticProgramming.Extensions;

namespace GeneticProgramming.Simulator
{
    public class MapGenerator
    {
        private MapConfig MapConfig { get; set; }

        public MapGenerator(MapConfig mapConfig)
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
            var coordsList = GenerateRandomCoords();
            var obstacles = coordsList.TakeRange(MapConfig.ObstaclesCount);
            var enemies = coordsList.TakeRange(MapConfig.EnemiesCount);
            var startCoord = coordsList.FirstAndRemove();
            var finishCoord = coordsList.FirstAndRemove();
            
            return new Map(MapConfig.Width, MapConfig.Height, obstacles, enemies, startCoord, finishCoord);
        }
    }
}
