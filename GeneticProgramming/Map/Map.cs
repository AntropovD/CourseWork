using System.Collections.Generic;

namespace GeneticProgramming
{
    public class Map
    {
        public int Width { get; private set; }
        public int Height { get; private set; }
        public List<Coord> Obstacles { get; private set; }
        public List<Coord> Enemies { get; private set; }

        public Map(int width, int height, List<Coord> obstacles, List<Coord> enemies)
        {
            Width = width;
            Height = height;
            Obstacles = obstacles;
            Enemies = enemies;
        }
    }
}