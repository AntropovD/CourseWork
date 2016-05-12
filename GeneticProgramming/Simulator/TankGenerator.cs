using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeneticProgramming.Configurations;

namespace GeneticProgramming.Simulator
{
    class TankGenerator
    {
        private TankConfig config;
        public TankGenerator(TankConfig config)
        {
            this.config = config;
        }

        public Tank RandomizeTank(Coord coord)
        {
            var directions = Enum.GetValues(typeof(Direction));
            var rnd = new Random(Guid.NewGuid().GetHashCode());
            return new Tank()
            {
                Coord = coord,
                Direction = (Direction)directions.GetValue(rnd.Next(directions.Length)),
                ammunition = config.Ammunition,
                fireArea = config.FireArea,
                viewArea = config.ViewArea
            };
        }
    }
}
