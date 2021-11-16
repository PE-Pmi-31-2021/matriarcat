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
    /// Interaction logic for Waste.xaml
    /// </summary>
    public partial class Waste : Page
    {
        public Waste()
        {
            InitializeComponent();
            projectEntities db = new projectEntities();
            var wast = from w in db.wastes
                       select w;

            List<string> titles = new List<string>();
            foreach (var item in wast)
            {
                titles.Add(item.Waste_Name);
            }
            titles.Sort();
            
            DataContext = titles.Select(n => n[0]).Distinct()
                    .ToDictionary(l => l.ToString(), l => titles.Where(w => w.StartsWith(l.ToString())));
        }
    }
    
   
}
