namespace RSSDraft
{
    using System.Windows;

    /// <summary>
    /// Interaction logic for Test.xaml.
    /// </summary>
    public partial class Test : Window
    {
        public Test()
        {
            InitializeComponent();
            this.Main.Content = new Label();
        }

        private void Main_Navigated(object sender, System.Windows.Navigation.NavigationEventArgs e)
        {
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Main.Content = new Location();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Main.Content = new Label();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            this.Main.Content = new Search();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            this.Main.Content = new Alphabet();
        }
    }
}
