using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        static projectEntities db = new projectEntities();
        [TestMethod]
        public void TestMethod1()
        {
            
            var keyword = "HDPE 2 (Поліетилен високої щільності)";

            IDictionary<int, string> lbl = Label_List();
            var wast = from w in db.waste
                       select w;

            var ws_lb = from rs in wast.ToList()
                        join r in lbl on rs.Label_ID equals r.Key
                        select new { Name = rs.Waste_Name, Value = r.Value };

            List<string> actual = new List<string>();
            foreach (var w in ws_lb)
            {
                if (keyword == w.Value)
                {
                    actual.Add(w.Name);
                }
            }
            List<string> expected = new List<string> { "Каністра", "Кришечка з-під пляшки для напоїв",
            "Пляшки з-під засобів побутової хімії", "Флакон з-під шампуню"};

            Assert.AreEqual(expected.Count, actual.Count);
            for (var i = 0; i < expected.Count; i++)
            {
                Assert.AreEqual(expected[i], actual[i]);
            }
        }
        [TestMethod]
        public void TestMethod2()
        {

            var wast = from w in db.waste
                       select w;

            List<string> titles = new List<string>();
            foreach (var item in wast)
            {
                titles.Add(item.Waste_Name);
            }
            Assert.AreEqual(44, titles.Count);
        }
        [TestMethod]
        public void TestMethod3()
        {

            var wst = from l in db.waste
                      select l;
            var lbl = from l in db.label
                      select l;

            List<Descriptions> DescriptionsCollection = new List<Descriptions>();
            List<Descriptions> OneElement = new List<Descriptions>();

            var dcollection = from rs in wst
                              join r in lbl on rs.Label_ID equals r.Label_ID
                              select new { Name = rs.Waste_Name, D1 = r.Label_Name, D2 = rs.Waste_Info };
            foreach (var item in dcollection)
            {
                DescriptionsCollection.Add(new Descriptions { Name = item.Name, Desc1 = item.D1, Desc2 = item.D2.Replace(';', '\n') });
            }

            CollectionAssert.IsSubsetOf(OneElement, DescriptionsCollection);
        }
        static Dictionary<int, string> Label_List()
        {
            var wast = from w in db.label
                       select w;
            Dictionary<int, string> lbl = new Dictionary<int, string>();
            foreach (var item in wast)
            {
                lbl.Add(item.Label_ID, item.Label_Name);
            }

            return lbl;
        }
        public class Descriptions
        {
            public string Name { get; set; }
            public string Desc1 { get; set; }
            public string Desc2 { get; set; }
        }
    }
}
