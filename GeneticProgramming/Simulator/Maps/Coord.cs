namespace GeneticProgramming.Simulator.Maps
{
    public class Coord
    {
        public readonly int X;
        public readonly int Y;

        public Coord(int x, int y)
        {
            X = x;
            Y = y;
        }

        public static Coord operator +(Coord C, Coord D)
        {
            return new Coord(C.X + D.X, C.Y + D.Y);
        }
        public static Coord operator -(Coord C, Coord D)
        {
            return new Coord(C.X - D.X, C.Y - D.Y);
        }

        public static Coord operator *(Coord C, Coord D)
        {
            return new Coord(C.X * D.X, C.Y * D.Y);
        }

        public static bool operator ==(Coord C, Coord D)
        {
            return C.Equals(D);
        }

        public static bool operator !=(Coord C, Coord D)
        {
            return !(C.Equals(D));
        }

        public bool Equals(Coord other)
        {
            return X == other.X && Y == other.Y;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            return obj is Coord && Equals((Coord)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (X*397) ^ Y;
            }
        }
    }
}