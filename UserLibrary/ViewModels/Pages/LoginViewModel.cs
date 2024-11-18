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
        }
        [RelayCommand]
        private async Task SettingOpen()
        {
            await App.Current.MainWindow.Dispatcher.InvokeAsync(() =>
            {
                App.Current.MainWindow.IsEnabled = false;
                App.Current.MainWindow.Background = new SolidColorBrush(Color.FromArgb(150, 0, 0, 0));
            });
            
            
            //App.Current.MainWindow.IsEnabled = false;
            //App.Current.MainWindow.Background = new SolidColorBrush(Color.FromArgb(150, 0, 0, 0));
            //Window window = new Window
            //{
            //    Owner = App.Current.MainWindow,
            //    Content = App.GetService<SettingsPage>(),
            //    //DataContext = App.GetService<SettingsViewModel>(),


            //};

            //window.Loaded += (s,e)=>{
            //    window.Closed += (s, e) =>
            //    {
            //        App.Current.MainWindow.IsEnabled = true;
            //        switch ((((window.Content as SettingsPage).DataContext as SettingsViewModel).CurrentTheme))
            //        {
            //            case ApplicationTheme.Light:
            //                ApplicationThemeManager.Apply(ApplicationTheme.Light);
            //                break;
            //            case ApplicationTheme.Dark:
            //                ApplicationThemeManager.Apply(ApplicationTheme.Dark);
            //                break;
            //            case ApplicationTheme.Unknown:
            //                ApplicationThemeManager.Apply(ApplicationTheme.Light);
            //                break;
            //            case ApplicationTheme.HighContrast:
            //                ApplicationThemeManager.Apply(ApplicationTheme.Light);
            //                break;
            //            default:
            //                ApplicationThemeManager.Apply(ApplicationTheme.Light);
            //                break;
            //        }

            //    };
            //};

            //window.ShowDialog();

            //App.Current.MainWindow.Background = Brushes.White;
        }

        
    }
}
