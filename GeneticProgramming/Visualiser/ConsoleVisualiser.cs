using System;
using System.Collections.Generic;
using GeneticProgramming.Simulator;
using GeneticProgramming.Simulator.Maps;
using GeneticProgramming.Simulator.Tanks;

namespace GeneticProgramming.Visualiser
{
    class ConsoleVisualiser : BaseVisualiser
    {
        public override void Visualise(Battle battle)
        {
            Console.Clear();
            string[] field = GetField(battle.Map);
            foreach (var s in field)
            {
                Console.WriteLine(s);
            }
        }

        protected override char GetTankChar(Direction direction)
        {
            return TankChars[direction];
        }

        protected override char GetEnemyChar(Direction direction)
        {
            return EnemyChars[direction];
        }

        private static readonly Dictionary<Direction, char> TankChars = new Dictionary<Direction, char>
        {
            { Direction.Up, '8'},
            { Direction.Left, '4'},
            { Direction.Right, '6'},
            { Direction.Down, '2'}
        };

        private static readonly Dictionary<Direction, char> EnemyChars = new Dictionary<Direction, char>
        {
            { Direction.Up, 'I' },
            { Direction.Left, 'J'},
            { Direction.Down, 'K'},
            { Direction.Right, 'L'}
        };
    }
}
