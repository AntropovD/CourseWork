using System.Linq;
using GeneticProgramming.Configurations;
using GeneticProgramming.Simulator;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Map_Tests
{
    [TestClass]
    public class MapGenerator_Test
    {
        private MapGenerator generator { get; set; }
        private MapConfig config { get; set; }

        [TestInitialize]
        public void TestInitialize()
        {
            config = ConfigurationFactory.Configuration.MapConfig;
            generator = new MapGenerator(config);
        }

        [TestMethod]
        public void MapGenerator_on_width_should_return_map_with_same_width()
        {
            var map = generator.GenerateMap();
            Assert.AreEqual(config.Width, map.Width);
        }

        [TestMethod]
        public void MapGenerator_on_height_should_return_map_with_same_height()
        {
            var map = generator.GenerateMap();
            Assert.AreEqual(config.Height, map.Height);
        }

        [TestMethod]
        public void MapGeneratoron_width_should_return_map_with_obstacles_count()
        {
            var map = generator.GenerateMap();
            Assert.AreEqual(config.ObstaclesCount, map.Obstacles.Count);
        }

        [TestMethod]
        public void MapGenerator_should_return_map_with_same_enemies_count()
        {
            var map = generator.GenerateMap();
            Assert.AreEqual(config.EnemiesCount, map.Enemies.Count);
        }

        [TestMethod]
        public void MapGenerator_should_return_all_different_coords_in_enemies()
        {
            var map = generator.GenerateMap();
            Assert.IsTrue(map.Enemies.Distinct().Count() == map.Enemies.Count);
        }

        [TestMethod]
        public void MapGenerator_should_return_all_different_coords_in_obstacles()
        {
            var map = generator.GenerateMap();
            Assert.IsTrue(map.Enemies.Distinct().Count() == map.Enemies.Count);
        }

        [TestMethod]
        public void MapGenerator_should_return_all_different_coords()
        {
            var map = generator.GenerateMap();
            var allCoords = map.Enemies.Select(enemy => enemy.Coord).ToList();
            allCoords.AddRange(map.Obstacles);
            allCoords.Add(map.StartCoord);
            allCoords.Add(map.FinishCoord);
            Assert.IsTrue(allCoords.Distinct().Count() == allCoords.Count);
        }
    }
}