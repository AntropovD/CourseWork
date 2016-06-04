using System;
using System.Collections.Generic;
using System.Linq;
using GeneticProgramming.Simulator.Maps;
using GeneticProgramming.Simulator.Modules;
using GeneticProgramming.Simulator.Strategies;
using GeneticProgramming.Simulator.Tanks;

namespace GeneticProgramming.Simulator
{
    public class Battle
    {
        public Map Map { get; }

        public bool IsOver => !Map.Tank.IsAlive || hasTankReachFinish;

        public bool hasTankReachFinish;

        public Battle(Map map, Strategy strategy, Strategy enemyStrategy)
        {
            Map = map;
            Map.Tank.Strategy = new Strategy(strategy);
            foreach (var enemy in Map.Enemies)
            {
                enemy.Strategy = new Strategy(enemyStrategy);
            }
            hasTankReachFinish = false;
        }

        public void MakeStep(FightStat fitnessStat)
        {
            foreach (var tank in Map.AllTanks.Where(tank => tank.IsAlive))
            {
                var command = GetNextStrategy(tank);
                ExecuteCommand(tank, command, fitnessStat);
                if (Map.Tank.Coord == Map.FinishCoord)
                {
                    hasTankReachFinish = true;
                    fitnessStat.FinishAchieved = true;
                }
            }
            fitnessStat.Steps++;
        }

        private void ExecuteCommand(Tank tank, string command, FightStat fitnessStat)
        {
            switch (command)
            {
                case "Forward":
                    CheckAndMove(tank, tank.Coord + Movements[tank.Direction]);
                    return;
                case "Backward":
                    CheckAndMove(tank, tank.Coord - Movements[tank.Direction]);
                    return;
                case "TurnRight":
                    tank.Direction = DirectionMethods.RotateRight(tank.Direction);
                    return;
                case "TurnLeft":
                    tank.Direction = DirectionMethods.RotateLeft(tank.Direction);
                    return;
                case "Shoot":
                    ShootAction(tank, fitnessStat);
                    return;
                case "Finish":
                    tank.IsAlive = false;
                    return;
                default:
                    throw new Exception("Unknown command");
            }
        }

        private void ShootAction(Tank tank, FightStat fightStat)
        {
            var shiftCoord = Movements[tank.Direction];
            for (var i = 1; i <= Map.FireArea; i++)
            {
                var newCoord = tank.Coord + i * shiftCoord;
                if (Map.Obstacles.Contains(newCoord))
                    return;
                if (Map.AllTanks.Any(t => t.Coord == newCoord && t.IsAlive))
                {
                    if (tank == Map.Tank)
                        fightStat.Killed++;
                    else
                        fightStat.EnemiesKilledByEnemies++;
                    var visibleTank = Map.AllTanks.First(t => t.Coord == newCoord && t.IsAlive);
                    visibleTank.IsAlive = false;
                    visibleTank.FirstMoveDead = 0;
                    if (visibleTank == Map.Tank)
                        fightStat.IsAlive = false;
                    return;
                }
            }
        }

        private string GetNextStrategy(Tank tank)
        {
            return tank.Strategy.GetNextCommand(Map, tank);
        }

        private void CheckAndMove(Tank tank, Coord coord)
        {
            if (IsEmpty(coord))
                tank.Coord = coord;
        }

        private bool IsEmpty(Coord coord)
        {
            return !(Map.AllTanks.Any(tank => tank.Coord == coord && tank.IsAlive)
                   || Map.Obstacles.Any(c => c == coord)) 
                   && NotZeroCoord(coord) && LessThemMaxCoord(coord);
        }

        private bool NotZeroCoord(Coord coord)
        {
            return coord.X != 0 && coord.Y != 0;
        }

        private bool LessThemMaxCoord(Coord coord)
        {
            return coord.X <= Map.Width && coord.Y <= Map.Height;
        }
        
        private static readonly Dictionary<Direction, Coord> Movements = new Dictionary<Direction, Coord>
        {
            { Direction.Up, new Coord(0, -1) },
            { Direction.Down, new Coord(0, 1) },
            { Direction.Left, new Coord(-1, 0) },
            { Direction.Right, new Coord(1, 0) }
        };
    }
}
 