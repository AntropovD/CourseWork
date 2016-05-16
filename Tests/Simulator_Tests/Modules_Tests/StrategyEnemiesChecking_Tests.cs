using System.Collections.Generic;
using GeneticProgramming.Simulator.Maps;
using GeneticProgramming.Simulator.Modules;
using GeneticProgramming.Simulator.Tanks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Simulator_Tests.Modules_Tests
{
    [TestClass]
    public class StrategyEnemiesChecking_Tests
    {
        private Map map;
        [TestInitialize]
        public void Init()
        {
            map = new Map
            {
                Enemies = new List<Tank> { new Tank { Coord = new Coord(7, 5)} },
                Obstacles = new List<Coord> { new Coord(4, 5)}
            };
        }

        [TestMethod]
        public void CheckEnemyFront_on_enemy_7_5_and_tank_6_5_Right_should_return_true()
        {
            var tank = new Tank
            {
                Coord = new Coord(6, 5),
                Direction = Direction.Right,
                fireArea = 4
            };
            bool result = EnemiesChecking.CheckEnemyFront(map, tank);
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void CheckEnemyFront_on_enemy_7_5_and_tank_3_5_should_return_false_because_of_obstacle_on_4_5()
        {
            var tank = new Tank
            {
                Coord = new Coord(3, 5),
                Direction = Direction.Right,
                fireArea = 7
            };
            bool result = EnemiesChecking.CheckEnemyFront(map, tank);
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void CheckEnemyRight_on_enemy_7_5_and_tank_7_2_Right_fireArea_3_should_return_true()
        {
            var tank = new Tank
            {
                Coord = new Coord(7, 2),
                Direction = Direction.Right,
                fireArea = 3
            };
            bool result = EnemiesChecking.CheckEnemyRight(map, tank);
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void CheckEnemyRight_on_enemy_7_5_and_tank_7_2_Right_fireArea_2_should_return_false()
        {
            var tank = new Tank
            {
                Coord = new Coord(7, 2),
                Direction = Direction.Right,
                fireArea = 2
            };
            bool result = EnemiesChecking.CheckEnemyRight(map, tank);
            Assert.AreEqual(false, result);
        }
    }
}
