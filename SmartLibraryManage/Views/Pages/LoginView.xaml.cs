using SmartLibraryManage.ViewModels.Pages;
using SmartLibraryManage.ViewModels.Pages.SystemSettingManage;
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

namespace SmartLibraryManage.Views.Pages
{
    /// <summary>
    /// LoginView.xaml 的交互逻辑
    /// </summary>
    public partial class LoginView : Page
    {
        public LoginView(LoginViewModel viewModel, SettingsViewModel settingsViewModel)
        {
            DataContext = viewModel;

            InitializeComponent();
            this.Spilt_ViewContent.DataContext = settingsViewModel;
        }
        [RelayCommand]
        private void SettingOpen()
        {
            this.SplitView.IsPaneOpen = true;

        }
    }
}
