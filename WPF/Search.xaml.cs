using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;
namespace TESTWPF
{
    /// <summary>
    /// Interaction logic for Search.xaml
    /// </summary>
    public partial class Search : Page
    {
        public class Descriptions
        {
            public string Name { get; set; }
            public string Desc1 { get; set; }
            public string Desc2 { get; set; }
        }

        public List<Descriptions> DescriptionsCollection { get; set; }
        public Search()
        {
            InitializeComponent();
            projectEntities db = new projectEntities();
            var wst = from l in db.wastes
                         select l;
            var lbl = from l in db.labels
                      select l;

            DescriptionsCollection = new List<Descriptions>();

            var dcollection = from rs in wst
                         join r in lbl on rs.Label_ID equals r.Label_ID
                         select new { Name = rs.Waste_Name, D1 = r.Label_Name, D2 = rs.Waste_Info };
            foreach (var item in dcollection)
            {
                DescriptionsCollection.Add(new Descriptions { Name = item.Name, Desc1 = item.D1, Desc2 = item.D2.Replace(';', '\n') });
            }

            DataContext = this;

        }
        private void cbTest_TextChanged(object sender, TextChangedEventArgs e)
        {
            string _prevText = string.Empty;

            foreach (var item in SearchBox.Items)
            {
                if (item.ToString().StartsWith(SearchBox.Text))
                {
                    _prevText = SearchBox.Text;
                    return;
                }
            }
            SearchBox.Text = _prevText;
        }
    }
}
