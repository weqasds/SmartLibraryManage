using System.Windows.Controls;
using UserLibrary.ViewModels.Pages;
using Wpf.Ui.Controls;

namespace UserLibrary.Views.Pages
{
    public partial class SettingsPage : Page
    {
        //public SettingsViewModel ViewModel { get; }

        public SettingsPage(SettingsViewModel viewModel)
        {
            //ViewModel = viewModel;
            DataContext = viewModel;

            InitializeComponent();
        }
    }
}
