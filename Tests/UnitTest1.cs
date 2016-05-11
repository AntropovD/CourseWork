using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            L l = new L();
            add(l);
            foreach (var i in l.list)
            {
                Console.WriteLine(i);
            }
        }

        private void add(L l)
        {
            l.list.Clear();
        }
    }

    class L
    {
        public List<int> list = new List<int>() {1,2,3,4};
        
    }
}
