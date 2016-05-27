using System;
using GeneticProgramming.Configurations.PartialConfigs;
using GeneticProgramming.Simulator.Maps;

namespace GeneticProgramming.Simulator.Tanks
{
    class TankGenerator
    {
        private readonly MapConfig mapConfig;

        public TankGenerator(MapConfig config)
        {
            mapConfig = config;
        }

        public Tank RandomizeTank(Coord coord)
        {
            var directions = Enum.GetValues(typeof(Direction));
            var rnd = new Random(Guid.NewGuid().GetHashCode());

            return new Tank
            {
                Coord = coord,
                Direction = (Direction)directions.GetValue(rnd.Next(directions.Length))
            };
        }
    }
}
