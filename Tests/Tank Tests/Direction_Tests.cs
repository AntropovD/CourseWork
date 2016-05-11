﻿using GeneticProgramming.Simulator;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static GeneticProgramming.Simulator.DirectionExtensions;

namespace Tests.Tank_Tests
{
    [TestClass]
    public class Direction_Tests
    {
        [TestMethod]
        public void RotateRight_on_up_should_return_right()
        {
            var direction = Direction.Up;
            var result = RotateRight(direction);
            Assert.AreEqual(Direction.Right, result);
        }

        [TestMethod]
        public void RotateRight_on_left_should_return_up()
        {
            var direction = Direction.Up;
            var result = RotateRight(direction);
            Assert.AreEqual(Direction.Right, result);
        }

        [TestMethod]
        public void RotateLeft_on_right_should_return_up()
        {
            var direction = Direction.Right;
            var result = RotateLeft(direction);
            Assert.AreEqual(Direction.Up, result);
        }

        [TestMethod]
        public void RotateLeft_on_up_should_return_left()
        {
            var direction = Direction.Up;
            var result = RotateLeft(direction);
            Assert.AreEqual(Direction.Left, result);
        }
    }
}