using SmartLibraryManage.ViewModels.Pages.SystemSettingManage;
using Wpf.Ui.Controls;

namespace SmartLibraryManage.Views.Pages.SystemSettingManage
{
    public partial class SettingsPage : INavigableView<SettingsViewModel>
    {
        public SettingsViewModel ViewModel { get; }
        public SettingsPage(SettingsViewModel viewModel)
        {

            ViewModel = viewModel;
            DataContext = this;
            InitializeComponent();
        }

        
    }
}
