using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Media;
using UserLibrary.Views.Pages;
using UserLibrary.Views.Windows;
using Wpf.Ui.Appearance;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace UserLibrary.ViewModels.Pages
{
    public partial class LoginViewModel : ObservableObject
    {
        [RelayCommand]
        private void Login()
        {
            Debug.WriteLine("登录调用");
        }
        [RelayCommand]
        private void Register()
        {
            Debug.WriteLine("注册调用");
            var window = App.GetService<PageContainer>();
            var registerPage = App.GetService<RegisterUserPage>();
            window.Content = registerPage;
            registerPage.DataContext = App.GetService<RegisterViewModel>();
            window.Show();
        }
        

        
    }
}
