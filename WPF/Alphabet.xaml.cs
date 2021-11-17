namespace RSSDraft
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows;
    using System.Windows.Controls;

    /// <summary>
    /// Interaction logic for Alphabet.xaml.
    /// </summary>
    public partial class Alphabet : Page
    {
        public Alphabet()
        {
            InitializeComponent();

            rssEntities db = new rssEntities();
            var wast = from w in db.wastes
                       select w;

            List<string> titles = new List<string>();
            foreach (var item in wast)
            {
                titles.Add(item.waste_name);
            }

            titles.Sort();

            this.DataContext = titles.Select(n => n[0]).Distinct()
                    .ToDictionary(l => l.ToString(), l => titles.Where(w => w.StartsWith(l.ToString())));
        }

        private void BtnClick(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("Read.xaml", UriKind.Relative));
        }
    }
}
