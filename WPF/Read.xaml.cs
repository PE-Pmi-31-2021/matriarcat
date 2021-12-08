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
    /// Interaction logic for Read.xaml
    /// </summary>
    
    public partial class Read : Page
    {
        public List<Descriptions> DescriptionsCollection { get; set; }
        public Read(string text)
        {
            
            InitializeComponent();
            
            string str = text;
            projectEntities db = new projectEntities();
            var wst = from l in db.wastes
                      select l;
            var lbl = from l in db.labels
                      select l;
            var dcollection = from rs in wst
                              join r in lbl on rs.Label_ID equals r.Label_ID
                              select new { Name = rs.Waste_Name, D1 = r.Label_Name, D2 = rs.Waste_Info };
            DescriptionsCollection = new List<Descriptions>();
            foreach (var item in dcollection)
            {
                if (str == item.Name)
                {

                    DescriptionsCollection.Add(new Descriptions { Waste = item.Name, Label = item.D1, Info = item.D2.Replace(';', '\n') });
                }
            }

            
            this.DataContext = DescriptionsCollection;
        }
        
    }
    public class Descriptions
    {
        private string WasteValue;
        public string Waste
        {
            get
            {
                return WasteValue;
            }
            set
            {
                WasteValue = value;
            }
        }
        private string LabelValue;
        public string Label
        {
            get
            {
                return LabelValue;
            }
            set
            {
                LabelValue = value;
            }
        }
        private string InfoValue;
        public string Info
        {
            get
            {
                return InfoValue;
            }
            set
            {
                InfoValue = value;
            }
        }
    }
}
