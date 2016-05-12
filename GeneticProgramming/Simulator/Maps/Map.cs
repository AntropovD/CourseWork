using System.Collections.Generic;
using System.Linq;
using GeneticProgramming.Configurations;
using GeneticProgramming.Simulator.Tanks;

namespace GeneticProgramming.Simulator.Maps
{
    public class Map
    {
        public int Width { get; private set; }
        public int Height { get; private set; }
        public Coord StartCoord { get; private set; }
        public Coord FinishCoord { get; private set; }
        public Tank Tank { get; set; }
        public List<Tank> Enemies { get; set; }
        public List<Coord> Obstacles { get; private set; }

        public Map(int width, int height, List<Coord> obstacles, List<Coord> enemies, Coord start, Coord finish, TankConfig tankConfig)
        {
            var tankGenerator = new TankGenerator(tankConfig);
            Width = width;
            Height = height;
            Obstacles = obstacles;
            StartCoord = start;
            FinishCoord = finish;
            Tank = tankGenerator.RandomizeTank(start);
            Enemies = enemies.Select(tankGenerator.RandomizeTank).ToList();
        }
    }
}