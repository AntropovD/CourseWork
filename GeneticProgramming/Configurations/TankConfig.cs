using System;

namespace GeneticProgramming
{
    [Serializable]
    public class TankConfig
    {
        public int ViewArea { get; set; }
        public int FireArea { get; set; }
        public int Ammunition { get; set; }
    }
}