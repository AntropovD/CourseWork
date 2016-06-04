using System;
using System.Collections.Generic;
using System.Linq;
using GeneticProgramming.Configurations.PartialConfigs;
using GeneticProgramming.Simulator.Tanks;

namespace GeneticProgramming.Simulator.Maps
{
    [Serializable]
    public class Map
    {
        public int Width { get; }
        public int Height { get; }
        public Coord StartCoord { get; }
        public Coord FinishCoord { get; }
        public Tank Tank { get; set; }
        public List<Tank> Enemies { get; set; }
        public List<Coord> Obstacles { get; set; }
        public List<Tank> AllTanks => Enemies.Concat(new List<Tank> { Tank }).ToList();
        public int ViewArea { get; set; }
        public int FireArea { get; set; }
        
        public Map(Map map)
        {
            Width = map.Width;
            Height = map.Height;
            Obstacles = map.Obstacles;
            StartCoord = map.StartCoord;
            FinishCoord = map.FinishCoord;
            ViewArea = map.ViewArea;
            FireArea = map.FireArea;

            Tank = new Tank(map.Tank);
            CloneEnemies(map);
        }

        public Map()
        {
        }

        public Map(MapConfig mapConfig, List<Coord> obstacles, List<Coord> enemies, Coord startCoord, Coord finishCoord)
        {
            var tankGenerator = new TankGenerator(mapConfig);
            Width = mapConfig.Width;
            Height = mapConfig.Height;
            FireArea = mapConfig.FireArea;
            ViewArea = mapConfig.ViewArea;

            Obstacles = obstacles;
            StartCoord = startCoord;
            FinishCoord = finishCoord;
            Tank = tankGenerator.RandomizeTank(startCoord);
            Enemies = enemies.Select(tankGenerator.RandomizeTank).ToList();
        }
        
        private void CloneEnemies(Map map)
        {
            Enemies = new List<Tank>();
            foreach (var enemy in map.Enemies)
            {
                Enemies.Add(new Tank(enemy));
            }
        }
    }
}