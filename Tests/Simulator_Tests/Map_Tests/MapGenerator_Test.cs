using System.Linq;
using GeneticProgramming.Configurations.PartialConfigs;
using GeneticProgramming.Simulator.Maps;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Simulator_Tests.Map_Tests
{
    [TestClass]
    public class MapGenerator_Test
    {
        private MapGenerator generator { get; set; }
        private MapConfig MapConfig { get; set; }

        [TestInitialize]
        public void TestInitialize()
        {
            var config = ConfigurationFactory.Configuration;
            MapConfig = config.MapConfig;
            generator = new MapGenerator(config);
        }

        [TestMethod]
        public void MapGenerator_on_width_should_return_map_with_same_width()
        {
            var map = generator.GenerateMap();
            Assert.AreEqual(MapConfig.Width, map.Width);
        }

        [TestMethod]
        public void MapGenerator_on_height_should_return_map_with_same_height()
        {
            var map = generator.GenerateMap();
            Assert.AreEqual(MapConfig.Height, map.Height);
        }

        [TestMethod]
        public void MapGeneratoron_should_return_map_with_obstacles_count()
        {
            var map = generator.GenerateMap();
            Assert.AreEqual(MapConfig.ObstaclesCount, map.Obstacles.Count);
        }

        [TestMethod]
        public void MapGenerator_should_return_map_with_same_enemies_count()
        {
            var map = generator.GenerateMap();
            Assert.AreEqual(MapConfig.EnemiesCount, map.Enemies.Count);
        }

        [TestMethod]
        public void MapGenerator_should_return_all_different_coords_in_enemies()
        {
            var map = generator.GenerateMap();
            var a = map.Enemies.Distinct().ToList();
            var b = map.Enemies.Count;
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

        [TestMethod]
        public void GenerateMap_all_coords_more_than_coord_0_0()
        {
            var map = generator.GenerateMap();

            Assert.IsTrue(NotZeroCoord(map.StartCoord));
            Assert.IsTrue(NotZeroCoord(map.FinishCoord));
            foreach (var tank in map.AllTanks)
            {
                Assert.IsTrue(NotZeroCoord(tank.Coord));
            }
            foreach (var obstacle in map.Obstacles)
            {
                Assert.IsTrue(NotZeroCoord(obstacle));
            }
        }

        [TestMethod]
        public void GenerateMap_all_coords_less_than_coord_width_height()
        {
            var map = generator.GenerateMap();

            Assert.IsTrue(LessThemMaxCoord(map.StartCoord));
            Assert.IsTrue(LessThemMaxCoord(map.FinishCoord));
            foreach (var tank in map.AllTanks)
            {
                Assert.IsTrue(LessThemMaxCoord(tank.Coord));
            }
            foreach (var obstacle in map.Obstacles)
            {
                Assert.IsTrue(LessThemMaxCoord(obstacle));
            }
        }

        private bool NotZeroCoord(Coord c)
        {
            return c.X != 0 && c.Y != 0;
        }

        private bool LessThemMaxCoord(Coord c)
        {
            return c.X <= MapConfig.Width && c.Y <= MapConfig.Height;
        }
    }
}