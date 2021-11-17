using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
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
        private void BtnClick(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("Read.xaml", UriKind.Relative));
        }
    }
    
   
}
