using System;
using System.Collections.Generic;
using System.Linq;
using GeneticProgramming.Configurations;
using GeneticProgramming.Configurations.PartialConfigs;
using GeneticProgramming.Extensions;

namespace GeneticProgramming.Simulator.Maps
{
    public class MapGenerator
    {
        private MapConfig MapConfig { get; }
        private TankConfig TankConfig { get; }
        public MapGenerator(Configuration Config)
        {
            MapConfig = Config.MapConfig;
            TankConfig = Config.TankConfig;
        }

        private List<Coord> GenerateRandomCoords()
        {
            var width = MapConfig.Width;
            var height = MapConfig.Height;
            var rnd = new Random(Guid.NewGuid().GetHashCode());
            return Enumerable.Range(0, width*height)
                .OrderBy(i => rnd.Next())
                .Select(i => new Coord(i % width + 1, i / width + 1))
                .ToList();
        }

        public Map GenerateMap()
        {
            var coordsList = GenerateRandomCoords();
            var obstacles = coordsList.TakeRange(MapConfig.ObstaclesCount);
            var enemies = coordsList.TakeRange(MapConfig.EnemiesCount);
            var startCoord = coordsList.FirstAndRemove();
            var finishCoord = coordsList.FirstAndRemove();
            
            return new Map(MapConfig.Width, MapConfig.Height, obstacles, enemies, startCoord, finishCoord, TankConfig);
        }
    }
}
