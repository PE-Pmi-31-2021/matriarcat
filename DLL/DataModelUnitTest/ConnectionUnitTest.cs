using System;
using System.Linq;
using DataModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DataModelUnitTest
{
    [TestClass]
    public class ConnectionUnitTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            using (rss ctx = new rss())
            {
                var locat = ctx.location.ToList();
            }
        }
    }
}
