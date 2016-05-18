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
        public Strategy Strategy { get; }
        public Strategy EnemyStrategy { get; }

        public bool IsOver => !Map.Tank.IsAlive || isTankReachFinish;

        public bool isTankReachFinish;

        public Battle(Map map, Strategy strategy, Strategy enemyStrategy)
        {
            Map = map;
            Strategy = strategy;
            EnemyStrategy = enemyStrategy;
            isTankReachFinish = false;
        }

        public void MakeStep(ref int fitnessValue)
        {
            foreach (var tank in Map.AllTanks.Where(tank => tank.IsAlive))
            {
                var command = GetNextStrategy(tank);
                ExecuteCommand(tank, command, ref fitnessValue);
                if (Map.Tank.Coord == Map.FinishCoord)
                {
                    isTankReachFinish = true;
                    fitnessValue+=1000;
                }
            }
        }

        private void ExecuteCommand(Tank tank, string command, ref int fitnessValue)
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
                    ShootAction(tank, ref fitnessValue);
                    return;
                case "Finish":
                    if (tank == Map.Tank)
                    {
                        tank.IsAlive = false;
                    }
                    return;
                default:
                    throw new Exception("Unknown command");
            }
        }

        private void ShootAction(Tank tank, ref int fitnessValue)
        {
            var shiftCoord = Movements[tank.Direction];
            for (var i = 1; i <= tank.fireArea; i++)
            {
                var newCoord = tank.Coord + i * shiftCoord;
                if (Map.Obstacles.Contains(newCoord))
                    return;
                if (Map.AllTanks.Any(t => t.Coord == newCoord && t.IsAlive))
                {
                    if (tank == Map.Tank)
                    {
                        fitnessValue += 20;
                    }
                    var visibleTank = Map.AllTanks.First(t => t.Coord == newCoord);
                    visibleTank.IsAlive = false;
                    if (visibleTank != Map.Tank)
                        Map.Enemies.Remove(visibleTank);
                    return;
                }
            }
        }

        private string GetNextStrategy(Tank tank)
        {
            return Map.Tank == tank ? 
                Strategy.GetNextCommand(Map, tank) 
                : EnemyStrategy.GetNextCommand(Map, tank);
        }

        private void CheckAndMove(Tank tank, Coord coord)
        {
            if (IsEmpty(coord))
                tank.Coord = coord;
        }

        private bool IsEmpty(Coord coord)
        {
            return !(Map.AllTanks.Any(tank => tank.Coord == coord)
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
 