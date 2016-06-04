using System;
using GeneticProgramming.Simulator.Maps;
using GeneticProgramming.Simulator.Strategies;

namespace GeneticProgramming.Simulator.Tanks
{
    [Serializable]
    public class Tank 
    {
        public Coord Coord { get; set; }
        public Direction Direction { get; set; }
        public Strategy Strategy { get; set; }

        public bool IsAlive = true;
        public int FirstMoveDead = 10;
        public int ammunition;

        public Tank(Tank tank)
        {
            Coord = new Coord(tank.Coord);
            Direction = tank.Direction;
            FirstMoveDead = tank.FirstMoveDead;
            IsAlive = true;
        }

        public Tank()
        {

        }

        public static bool operator ==(Tank firstTank, Tank secondTank)
        {
            return firstTank?.Coord == secondTank?.Coord;
        }

        public static bool operator !=(Tank firstTank, Tank secondTank)
        {
            return !(firstTank == secondTank);
        }

        protected bool Equals(Tank other)
        {
            return Equals(Coord, other.Coord) && Direction == other.Direction;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Tank)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((Coord?.GetHashCode() ?? 0) * 397) ^ (int)Direction;
            }
        }
    }
}
