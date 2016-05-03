namespace GeneticProgramming.Tank
{
    public class Tank
    {
        public int CoordX { get; private set; }
        public int CoordY { get; private set; }
        public Direction Direction { get; private set; }
        public TankStrategy TankStrategy { get; private set; }

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
