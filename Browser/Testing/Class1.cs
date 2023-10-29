using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Browser.Testing
{
    [TestClass]
    public class Class1
    {
        [TestMethod]
        public void TestMethod1()
        {
            int i = 6;
            int j = 7;
            Assert.AreEqual(i, j);
        }
    }
}
