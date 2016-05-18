using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeneticProgramming.Visualiser;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Visualiser_Tests
{
    [TestClass]
    public class FieldBuilder_Tests
    {
        [TestMethod]
        public void GenerateEmptyFieldWithBorder_on_1_1_return_3_3_border()
        {
            var builder = new FieldBuilder();
            var result = builder.GenerateEmptyFieldWithBorder(1, 1);

            var expected = new char[,]
            {
                {'#', '#', '#'},
                {'#', ' ', '#'},
                {'#', '#', '#'}
            };
            
            CollectionAssert.AreEqual(expected, result);
        }
    }
}
