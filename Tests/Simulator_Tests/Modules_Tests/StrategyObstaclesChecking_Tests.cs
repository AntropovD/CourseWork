using System.Collections.Generic;
using GeneticProgramming.Simulator.Maps;
using GeneticProgramming.Simulator.Modules;
using GeneticProgramming.Simulator.Tanks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Simulator_Tests.Modules_Tests
{
    [TestClass]
    public class StrategyObstaclesChecking_Tests
    {
        private Map map;

        [TestInitialize]
        public void Init()
        {
            map = new Map
            {
                Obstacles = new List<Coord> { new Coord(1, 1) }
            };
        }

        [TestMethod]
        public void CheckObstacleLeft_on_obstacle_1_1_and_tank_2_1_Up_should_return_true()
        {
            var tank = new Tank
            {
                Coord = new Coord(2, 1),
                Direction = Direction.Up
            };
            var result = ObstaclesChecking.CheckObstacleLeft(map, tank);
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void CheckObstacleLeft_on_obstacle_1_1_and_tank_2_2_Up_should_return_false()
        {
            var tank = new Tank
            {
                Coord = new Coord(2, 2),
                Direction = Direction.Up
            };
            var result = ObstaclesChecking.CheckObstacleLeft(map, tank);
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void CheckObstacleRight_on_obstacle_1_1_and_tank_0_1_Up_should_return_true()
        {
            var tank = new Tank
            {
                Coord = new Coord(0, 1),
                Direction = Direction.Up
            };
            var result = ObstaclesChecking.CheckObstacleRight(map, tank);
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void CheckObstacleRight_on_obstacle_1_1_and_tank_2_1_Down_should_return_true()
        {
            var tank = new Tank
            {
                Coord = new Coord(2, 1),
                Direction = Direction.Down
            };
            var result = ObstaclesChecking.CheckObstacleRight(map, tank);
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void CheckObstacleFront_on_obstacle_1_1_and_tank_1_0_Down_should_return_true()
        {
            var tank = new Tank
            {
                Coord = new Coord(1, 0),
                Direction = Direction.Down
            };
            var result = ObstaclesChecking.CheckObstacleFront(map, tank);
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void CheckObstacleFront_on_obstacle_1_1_and_tank_1_0_Right_should_return_false()
        {
            var tank = new Tank
            {
                Coord = new Coord(1, 0),
                Direction = Direction.Right
            };
            var result = ObstaclesChecking.CheckObstacleFront(map, tank);
            Assert.AreEqual(false, result);
        }
        
        [TestMethod]
        public void CheckObstacleBack_on_obstacle_1_1_and_tank_2_1_Right_should_return_true()
        {
            var tank = new Tank
            {
                Coord = new Coord(2, 1),
                Direction = Direction.Right
            };
            var result = ObstaclesChecking.CheckObstacleBack(map, tank);
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void CheckObstacleBack_on_obstacle_1_1_and_tank_0_1_Left_should_return_true()
        {
            var tank = new Tank
            {
                Coord = new Coord(0, 1),
                Direction = Direction.Left
            };
            var result = ObstaclesChecking.CheckObstacleRight(map, tank);
            Assert.AreEqual(false, result);
        }
    }
}
