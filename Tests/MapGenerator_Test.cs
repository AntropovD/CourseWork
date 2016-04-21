using System;
using System.Linq;
using GeneticProgramming.Map;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class MapGenerator_Test
    {
        [TestMethod]
        public void MapGenerator_on_width_should_return_map_with_same_width()
        {
            var map = MapGenerator.GenerateMap(10, 20, 3, 5);
            Assert.AreEqual(map.Width, 10);
        }

        [TestMethod]
        public void MapGenerator_on_height_should_return_map_with_same_height()
        {
            var map = MapGenerator.GenerateMap(10, 20, 3, 5);
            Assert.AreEqual(map.Height, 20);
        }

        [TestMethod]
        public void MapGeneratoron_width_should_return_map_with_obstacles_count()
        {
            var map = MapGenerator.GenerateMap(10, 20, 3, 5);
            Assert.AreEqual(map.Obstacles.Count, 3);
        }

        [TestMethod]
        public void MapGenerator_should_return_map_with_same_enemies_count()
        {
            var map = MapGenerator.GenerateMap(10, 20, 3, 5);
            Assert.AreEqual(map.Enemies.Count, 5);
        }

        [TestMethod]
        [TestCategory("Unique members")]
        public void MapGenerator_should_return_all_different_coords_in_enemies()
        {
            var map = MapGenerator.GenerateMap(10, 20, 3, 5);

            Assert.IsTrue(map.Enemies.Distinct().Count() == map.Enemies.Count);
        }

        [TestMethod]
        [TestCategory("Unique members")]
        public void MapGenerator_should_return_all_different_coords_in_obstacles()
        {
            var map = MapGenerator.GenerateMap(10, 20, 3, 5);

            Assert.IsTrue(map.Enemies.Distinct().Count() == map.Enemies.Count);
        }

        [TestMethod]
        [TestCategory("Unique members")]
        public void MapGenerator_should_return_all_different_coords()
        {
            var map = MapGenerator.GenerateMap(10, 20, 3, 5);

            var allCoords = map.Enemies.Select(i => i).ToList();
            allCoords.AddRange(map.Obstacles);
            allCoords.Add(map.Start);
            allCoords.Add(map.Finish);
            
            Assert.IsTrue(allCoords.Distinct().Count() == allCoords.Count);
        }
    }
}
