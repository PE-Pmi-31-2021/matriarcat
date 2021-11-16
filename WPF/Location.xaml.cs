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
    /// Interaction logic for Location.xaml
    /// </summary>
    public partial class Location : Page
    {
        public Location()
        {
            InitializeComponent();
            projectEntities db = new projectEntities();
            //this.LocationGrid.ItemsSource = db.locations.ToList();
            var locations = from l in db.locations
                            select l;
            List<string> fran = new List<string>();
            List<string> syh = new List<string>();
            List<string> gal = new List<string>();
            List<string> shev = new List<string>();
            List<string> zaliz = new List<string>();
            foreach (var item in locations)
            {
                if (item.District == "Франківський")
                {
                    fran.Add(item.Address);
                }
                if (item.District == "Шевченкіський")
                {
                    shev.Add(item.Address);
                }
                if (item.District == "Залізничний")
                {
                    zaliz.Add(item.Address);
                }
                if (item.District == "Сихівський")
                {
                    syh.Add(item.Address);
                }
                if (item.District == "Галицький")
                {
                    gal.Add(item.Address);
                }

            }
            this.ListV.ItemsSource = fran.Distinct().ToList();
            this.ListVG.ItemsSource = gal.Distinct().ToList();
            this.ListVS.ItemsSource = syh.Distinct().ToList();
            this.ListVSH.ItemsSource = shev.Distinct().ToList();
            this.ListVZ.ItemsSource = zaliz.Distinct();
        }
    }
}
