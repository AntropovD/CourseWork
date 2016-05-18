using GeneticProgramming.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Extensions
{
    [TestClass]
    public class StringExtension_Tests
    {
        [TestMethod]
        public void ReplaceIndex_on_abcde_index_4_char_D_should_return_abcDe()
        {
            var s = "abcde";
            var result = s.ReplaceIndex(3, 'D');
            Assert.AreEqual("abcDe", result);
        }

        [TestMethod] public void ReplaceIndex_on_abcde_index_10_returns_abcde()
        {
            var s = "abcde";
            var result = s.ReplaceIndex(10, 'A');
            Assert.AreEqual("abcde", result);
        }
    }
}
