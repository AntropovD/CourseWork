using GeneticProgramming.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Extensions
{
    [TestClass]
    public class Median_Tests
    {
        [TestMethod]
        public void GetMedian_on_12345_should_return_3()
        {
            var data = new[] {1, 2, 3, 4, 5};
            var result = MedianCounter.GetMedian(data);
            Assert.AreEqual(3, result);
        }
    }
}
