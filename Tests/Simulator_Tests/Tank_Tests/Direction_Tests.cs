using GeneticProgramming.Simulator.Modules;
using GeneticProgramming.Simulator.Tanks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Simulator_Tests.Tank_Tests
{
    [TestClass]
    public class Direction_Tests
    {
        [TestMethod]
        public void RotateRight_on_up_should_return_right()
        {
            var direction = Direction.Up;
            var result = DirectionMethods.RotateRight(direction);
            Assert.AreEqual(Direction.Right, result);
        }

        [TestMethod]
        public void RotateRight_on_left_should_return_up()
        {
            var direction = Direction.Up;
            var result = DirectionMethods.RotateRight(direction);
            Assert.AreEqual(Direction.Right, result);
        }

        [TestMethod]
        public void RotateLeft_on_right_should_return_up()
        {
            var direction = Direction.Right;
            var result = DirectionMethods.RotateLeft(direction);
            Assert.AreEqual(Direction.Up, result);
        }

        [TestMethod]
        public void RotateLeft_on_up_should_return_left()
        {
            var direction = Direction.Up;
            var result = DirectionMethods.RotateLeft(direction);
            Assert.AreEqual(Direction.Left, result);
        }

        [TestMethod]
        public void Flip_on_up_should_return_down()
        {
            var direction = Direction.Up;
            var result = DirectionMethods.Flip(direction);
            Assert.AreEqual(Direction.Down, result);
        }

        [TestMethod]
        public void Flip_on_right_should_return_left()
        {
            var direction = Direction.Right;
            var result = DirectionMethods.Flip(direction);
            Assert.AreEqual(Direction.Left, result);
        }
    }
}
