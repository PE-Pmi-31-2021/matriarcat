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

namespace RSSDraft
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();


            rssEntities db = new rssEntities();
            var wast = from w in db.wastes
                       select w;

            foreach(var it in wast)
            {
                Console.WriteLine(it.waste_id);
                Console.WriteLine(it.waste_name);
                Console.WriteLine(it.waste_info);
            }
            

            this.LocationGrid.ItemsSource = db.locations.ToList();
        }
    }
}
