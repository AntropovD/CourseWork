namespace GeneticProgramming.Panzer
{
    public class Panzer
    {
        public int CoordX { get; private set; }
        public int CoordY { get; private set; }
        public Direction Direction { get; private set; }
        public PanzerAlgorithm PanzerAlgorithm { get; private set; }

        private bool IsAlive = true;
        public int VisibilityRadius = 6;
        public int DefeatRadius = 4;
        public int Ammunition = 20;
    }

    public enum Direction
    {
        Up,
        Down,
        Left,
        Right
    }
}
