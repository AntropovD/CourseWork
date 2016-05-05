using System;

namespace GeneticProgramming
{
    [Serializable]
    public class MapConfig
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public int ObstaclesCount { get; set; }
        public int EnemiesCount { get; set; }
    }
}