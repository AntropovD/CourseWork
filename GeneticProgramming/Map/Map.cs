using System.Collections.Generic;

namespace GeneticProgramming.Map
{
    public class Map
    {
        public int Width { get; private set; }
        public int Height { get; private set; }
        public List<Coord> Obstacles { get; private set; }
        public List<Coord> Enemies { get; private set; }
        public Coord Start { get; private set; }
        public Coord Finish { get; private set; }


        public Map(int width, int height, List<Coord> obstacles, List<Coord> enemies, Coord start, Coord finish)
        {
            Width = width;
            Height = height;
            Obstacles = obstacles;
            Enemies = enemies;
            Start = start;
            Finish = finish;
        }
    }
}