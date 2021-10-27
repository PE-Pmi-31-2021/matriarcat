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

namespace WPF
{
    /// <summary>
    /// Interaction logic for Waste.xaml
    /// </summary>
    public partial class Waste : Page
    {
        public Waste()
        {
            InitializeComponent();
            projectEntities1 db = new projectEntities1();
            var wast = from w in db.wastes
                       select w;
            this.WasteGrid.ItemsSource = db.labels.ToList();
        }
    }
}
