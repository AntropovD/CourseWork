using System.Collections.Generic;
using System.Linq;
using GeneticProgramming.Simulator.Maps;
using GeneticProgramming.Simulator.Tanks;

namespace GeneticProgramming.Visualiser
{
    public class FieldBuilder
    {
        public char[,] GetField(Map map)
        {
            var result = GenerateEmptyFieldWithBorder(map.Width, map.Height);

            result[map.StartCoord.Y, map.StartCoord.X] = 'S';
            result[map.FinishCoord.Y, map.FinishCoord.X] = 'F';
            result[map.Tank.Coord.Y, map.Tank.Coord.X] = GetTankChar(map.Tank.Direction);

            foreach (var obstacle in map.Obstacles)
                result[obstacle.Y, obstacle.X] = '#';
            foreach (var enemy in map.Enemies.Where(enemy => enemy.IsAlive))
                result[enemy.Coord.Y, enemy.Coord.X] = GetEnemyChar(enemy.Direction);

            return result;
        }

        public char[,] GenerateEmptyFieldWithBorder(int width, int height)
        {
            var result = new char[height+2, width+2];

            for (var i = 0; i < width + 2; i++)
            {
                result[0, i] = '#';
                result[height+1, i] = '#';
            }
            for (var i = 1; i < height + 1; i++)
            {
                result[i, 0] = result[i, width + 1] = '#';
                for (var j = 1; j < width + 1; j++)
                    result[i, j] = ' ';
            }
            return result;
        }
        

        private char GetTankChar(Direction direction)
        {
            return TankChars[direction];
        }

        private char GetEnemyChar(Direction direction)
        {
            return EnemyChars[direction];
        }

        private readonly Dictionary<Direction, char> TankChars = new Dictionary<Direction, char>
        {
            { Direction.Up, '8'},
            { Direction.Left, '4'},
            { Direction.Right, '6'},
            { Direction.Down, '2'}
        };

        private readonly Dictionary<Direction, char> EnemyChars = new Dictionary<Direction, char>
        {
            { Direction.Up, 'I'},
            { Direction.Left, 'J'},
            { Direction.Down, 'K'},
            { Direction.Right, 'L'}
        };
    }
}