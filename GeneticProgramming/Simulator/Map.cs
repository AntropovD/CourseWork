using System.Collections.Generic;
using System.Linq;

namespace GeneticProgramming.Simulator
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

        public Map(int width, int height, List<Coord> obstacles, List<Coord> enemies, Coord start, Coord finish)
        {
            Width = width;
            Height = height;
            Obstacles = obstacles;
            StartCoord = start;
            FinishCoord = finish;
            Tank = Tank.RandomizeTank(start);
            Enemies = enemies.Select(Tank.RandomizeTank).ToList();
        }
    }
}