using System.Collections.Generic;
using GeneticProgramming.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Extensions
{
    [TestClass]
    public class ListExtension_Tests
    {
        [TestMethod]
        public void TakeRange_two_should_return_two_first_elements()
        {
            var list = new List<int> {1, 2, 3, 4, 5};
            var result = list.TakeRange(2);
            CollectionAssert.AreEqual(new List<int> {1, 2}, result);
        }

        [TestMethod]
        public void TakeRange_two_should_remove_two_first_elements()
        {
            var list = new List<int> { 1, 2, 3, 4, 5 };
            list.TakeRange(2);
            CollectionAssert.AreEqual(new List<int> { 3, 4, 5}, list);
        }
    }
}
