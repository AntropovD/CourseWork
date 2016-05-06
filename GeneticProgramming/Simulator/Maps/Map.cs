using System;
using GeneticProgramming.Simulator.Tanks;

namespace GeneticProgramming.Simulator.Maps
{
    public class Map : ICloneable
    {
        public int Width { get; private set; }
        public int Height { get; private set; }

        //public List<Coord> Obstacles { get; private set; }
        //public List<Coord> Enemies { get; private set; }
        //public Coord Start { get; private set; }

        public Coord FinishCoord { get; private set; }
        public Tank Tank { get; set; }


        public Map(int width, int height, Tank tank, Coord finishCoord)
        {
            Width = width;
            Height = height;
            Tank = tank;
            FinishCoord = finishCoord;
        }

        //        public Map(int width, int height, List<Coord> obstacles, List<Coord> enemies, Coord start, Coord finish)
        //        {
        //            Width = width;
        //            Height = height;
        //            Obstacles = obstacles;
        //            Enemies = enemies;
        //            Start = start;
        //            FinishCoord = finish;
        //        }
        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}