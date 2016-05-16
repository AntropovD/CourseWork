using System.Linq;
using GeneticProgramming.Extensions;
using GeneticProgramming.Simulator;
using GeneticProgramming.Simulator.Maps;
using GeneticProgramming.Simulator.Tanks;
using static System.String;

namespace GeneticProgramming.Visualiser
{
    abstract class BaseVisualiser
    {
        protected string[] GetField(Map map)
        {
            string[] result = GenerateEmptyFieldWithBorder(map.Width, map.Height);

            result[map.StartCoord.Y] = result[map.StartCoord.Y]
                .ReplaceIndex(map.StartCoord.X, 'S');
            result [map.FinishCoord.Y] = result[map.FinishCoord.Y]
                .ReplaceIndex(map.FinishCoord.X, 'F');

            foreach (var obstacle in map.Obstacles)
                result[obstacle.Y] = result[obstacle.Y].ReplaceIndex(obstacle.X, '#');

            foreach (var enemy in map.Enemies)
                result[enemy.Coord.Y] = result[enemy.Coord.Y]
                    .ReplaceIndex(enemy.Coord.X, GetEnemyChar(enemy.Direction));

            result[map.Tank.Coord.Y] = result[map.Tank.Coord.Y]
                .ReplaceIndex(map.Tank.Coord.X, GetTankChar(map.Tank.Direction));

            return result;
        }

        protected string[] GenerateEmptyFieldWithBorder(int width, int height)
        {
            string[] result = new string[height + 2];
            string emptyLine = Join("", Enumerable.Repeat(" ", width));
            result[0] = Concat(Enumerable.Repeat("#", width + 2));

            for (int i = 1; i <= height; i++)
                result[i] = Concat("#", emptyLine, "#");
            result[height + 1] = Concat(Enumerable.Repeat("#", width + 2));
            return result;
        }

        public abstract void Visualise(Battle battle);
        protected abstract char GetTankChar(Direction direction);
        protected abstract char GetEnemyChar(Direction direction);
    }
}