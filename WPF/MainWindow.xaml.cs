using System.Windows;

namespace TESTWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

        }
        private void BtnClickP0(object sender, RoutedEventArgs e)
        {
            Main.Content = new Search();
        }
        private void BtnClickP1(object sender, RoutedEventArgs e)
        {
            Main.Content = new Waste();
        }
        private void BtnClickP2(object sender, RoutedEventArgs e)
        {
            Main.Content = new Label();
        }
        private void BtnClickP3(object sender, RoutedEventArgs e)
        {
            Main.Content = new Location();
        }
    }
}
