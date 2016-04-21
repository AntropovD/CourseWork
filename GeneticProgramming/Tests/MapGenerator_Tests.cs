using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeneticProgramming.Map;
using NUnit.Framework;

namespace GeneticProgramming.Tests
{
    [TestFixture]
    public class MapGenerator_Tests
    {
        [Test]
        public void MapGenerator_on_width_should_return_map_with_same_width()
        {
            var map = MapGenerator.GenerateMap(10, 20, 3 ,5);
            Assert.AreEqual(map.Width, 10);
        }

        [Test]
        public void MapGenerator_on_height_should_return_map_with_same_height()
        {
            var map = MapGenerator.GenerateMap(10, 20, 3, 5);
            Assert.AreEqual(map.Height, 20);
        }

        [Test]
        public void MapGeneratoron_width_should_return_map_with_obstacles_count()
        {
            var map = MapGenerator.GenerateMap(10, 20, 3, 5);
            Assert.AreEqual(map.Obstacles.Count, 3);
        }

        [Test]
        public void MapGenerator_should_return_map_with_same_enemies_count()
        {
            var map = MapGenerator.GenerateMap(10, 20, 3, 5);
            Assert.AreEqual(map.Enemies.Count, 5);
        }

        [Test]
        public void MapGenerator_should_return_all_different_coords_in_enemies()
        {
            
        }
    }
}
