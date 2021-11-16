using HP.Services;
using HP.ViewModels;
using System.Windows;

namespace HP.Wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new CharactersViewModel(new HPService());
        }
    }
}
