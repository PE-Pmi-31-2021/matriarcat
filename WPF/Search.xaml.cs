using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TESTWPF
{
    /// <summary>
    /// Interaction logic for Search.xaml
    /// </summary>
    public partial class Search : Page
    {
        public Search()
        {
            InitializeComponent();

            projectEntities db = new projectEntities();
            var wastes = from l in db.wastes
                         select l;

            wastes.OrderBy(w => w.Waste_Name);
            foreach (var item in wastes)
            {
                SearchBox.Items.Add(item.Waste_Name);
            }
            
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
