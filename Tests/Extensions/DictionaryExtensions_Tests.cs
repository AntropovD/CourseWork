using System.Collections.Generic;
using GeneticProgramming.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Extensions
{
    [TestClass]
    public class DictionaryExtensions_Tests
    {
        [TestMethod]
        public void AddOrUpdate_on_new_key_should_add_to_dictionary()
        {
            var dictionary = new Dictionary<string, int>
            {
                {"a", 1}, {"b", 2}, {"c", 3 }
            };
            dictionary.AddOrUpdate("d", 4);
            Assert.AreEqual(4, dictionary["d"]);
        }

        [TestMethod]
        public void AddOrUpdate_on_existing_key_should_update_dictionary()
        {
            var dictionary = new Dictionary<string, int>
            {
                {"a", 1}, {"b", 2}, {"c", 3 }
            };
            dictionary.AddOrUpdate("a", 4);
            Assert.AreEqual(4, dictionary["a"]);
        }
    }
}
