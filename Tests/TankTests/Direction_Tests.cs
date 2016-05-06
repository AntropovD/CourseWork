using System;
using GeneticProgramming.Simulator.Tanks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.TankTests
{
    [TestClass]
    public class Direction_Tests
    {
        [TestMethod]
        public void RotateRight_on_up_should_return_right()
        {
            var direction = Direction.Up;
            var result = DirectionExtensions.RotateRight(direction);
            Assert.AreEqual(Direction.Right, result);
        }

        [TestMethod]
        public void RotateRight_on_left_should_return_up()
        {
            var direction = Direction.Up;
            var result = DirectionExtensions.RotateRight(direction);
            Assert.AreEqual(Direction.Right, result);
        }

        [TestMethod]
        public void RotateLeft_on_right_should_return_up()
        {
            var direction = Direction.Right;
            var result = DirectionExtensions.RotateLeft(direction);
            Assert.AreEqual(Direction.Up, result);
        }

        [TestMethod]
        public void RotateLeft_on_down_should_return_right()
        {
            var direction = Direction.Down;
            var result = DirectionExtensions.RotateLeft(direction);
            Assert.AreEqual(Direction.Right, result);
        }
    }
}
