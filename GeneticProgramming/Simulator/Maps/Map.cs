using System;
using System.Collections.Generic;
using System.Linq;
using GeneticProgramming.Configurations.PartialConfigs;
using GeneticProgramming.Simulator.Tanks;

namespace GeneticProgramming.Simulator.Maps
{
    [Serializable]
    public class Map : ICloneable
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

        public Map(MapConfig mapConfig, List<Coord> obstacles, List<Coord> enemies, Coord start, Coord finish)
        {
            var tankGenerator = new TankGenerator(mapConfig);
            Width = mapConfig.Width;
            Height = mapConfig.Height;
           
            Obstacles = obstacles;
            StartCoord = start;
            FinishCoord = finish;
            Tank = tankGenerator.RandomizeTank(start);
            Enemies = enemies.Select(tankGenerator.RandomizeTank).ToList();
        }
        
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

        public object Clone()
        {
            return MemberwiseClone();
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