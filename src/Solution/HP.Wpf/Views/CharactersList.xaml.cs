using HP.Services;
using HP.ViewModels;
using System.Windows.Controls;

namespace HP.Wpf.Views
{
    /// <summary>
    /// Interaction logic for CharactersList.xaml
    /// </summary>
    public partial class CharactersList : UserControl
    {
        public CharactersList()
        {
            InitializeComponent();
            //DataContext = new CharactersViewModel(new HPService());
        }
    }
}
