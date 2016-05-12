using System;
using GeneticProgramming.Configurations;
using GeneticProgramming.Simulator.Maps;

namespace GeneticProgramming.Simulator.Tanks
{
    class TankGenerator
    {
        private readonly TankConfig tankConfig;

        public TankGenerator(TankConfig tankConfig)
        {
            this.tankConfig = tankConfig;
        }

        public Tank RandomizeTank(Coord coord)
        {
            var directions = Enum.GetValues(typeof(Direction));
            var rnd = new Random(Guid.NewGuid().GetHashCode());

            return new Tank
            {
                Coord = coord,
                Direction = (Direction)directions.GetValue(rnd.Next(directions.Length)),
                ammunition = tankConfig.Ammunition,
                fireArea = tankConfig.FireArea,
                viewArea = tankConfig.ViewArea
            };
        }
    }
}
