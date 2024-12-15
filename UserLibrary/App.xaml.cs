using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Shared;
using Shared.Services;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Windows.Threading;
using UserLibrary.Services;
using UserLibrary.ViewModels.Pages;
using UserLibrary.ViewModels.Windows;
using UserLibrary.Views.Pages;
using UserLibrary.Views.Windows;
using Wpf.Ui;

namespace UserLibrary
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        // The.NET Generic Host provides dependency injection, configuration, logging, and other services.
        // https://docs.microsoft.com/dotnet/core/extensions/generic-host
        // https://docs.microsoft.com/dotnet/core/extensions/dependency-injection
        // https://docs.microsoft.com/dotnet/core/extensions/configuration
        // https://docs.microsoft.com/dotnet/core/extensions/logging
        private static readonly IHost _host = Host
            .CreateDefaultBuilder()
            .ConfigureAppConfiguration(c => { c.SetBasePath(Path.GetDirectoryName(Assembly.GetEntryAssembly()!.Location)); })
            .ConfigureServices((context, services) =>
            {
                services.AddHostedService<ApplicationHostService>();
                services.AddDbContext<LibraryDbContext>(
                    options => {
                        options.UseNpgsql("Host=localhost;Port=5432;Username=postgres;Password=@qq13015461197;Database=LibraryManage;");
                    }
                );
                // Page resolver service
                #region 数据库服务注册
                services.GetServices(
                    ServiceRole.User, 
                    new[] {
                        ServiceType.UserService,
                        ServiceType.BookService,
                        ServiceType.BorrowRecordService,
                        ServiceType.FineService, 
                    } 
                    );
                Debug.WriteLine(services.ToString());
                #endregion
                services.AddSingleton<IPageService, PageService>();
                // Theme manipulation
                services.AddSingleton<IThemeService, ThemeService>();

                // TaskBar manipulation
                services.AddSingleton<ITaskBarService, TaskBarService>();

                // Service containing navigation, same as INavigationWindow... but without window
                services.AddSingleton<INavigationService, NavigationService>();

                // Main window with navigation
                #region 窗口注册
                services.AddSingleton<INavigationWindow, MainWindow>();
                services.AddSingleton<MainWindowViewModel>();
                services.AddTransient<PageContainer>();
                #endregion

                #region Page界面注册
                services.AddSingleton<DashboardPage>();
                services.AddSingleton<DataPage>();
                services.AddSingleton<SettingsPage>();
                services.AddSingleton<RegisterUserPage>();
                services.AddSingleton<LoginPage>();
                #endregion
                #region ViewModel注册
                services.AddSingleton<DashboardViewModel>();
                services.AddSingleton<DataViewModel>();
                services.AddSingleton<SettingsViewModel>();
                services.AddSingleton<RegisterViewModel>();
                services.AddSingleton<LoginViewModel>();
                #endregion
            }).Build();

        /// <summary>
        /// Gets registered service.
        /// </summary>
        /// <typeparam name="T">Type of the service to get.</typeparam>
        /// <returns>Instance of the service or <see langword="null"/>.</returns>
        public static T GetService<T>()
            where T : class
        {
            
            return _host.Services.GetRequiredService(typeof(T)) as T;
        }
        public static Window CreateNewWindow<T>(T page)where T:class
        {
            var window= _host.Services.GetRequiredService<PageContainer>();
            window.DataContext = page;
            return window;
        }

        /// <summary>
        /// Occurs when the application is loading.
        /// </summary>
        private void OnStartup(object sender, StartupEventArgs e)
        {
            _host.Start();
        }

        /// <summary>
        /// Occurs when the application is closing.
        /// </summary>
        private async void OnExit(object sender, ExitEventArgs e)
        {
            await _host.StopAsync();

            _host.Dispose();
        }

        /// <summary>
        /// Occurs when an exception is thrown by an application but not handled.
        /// </summary>
        private void OnDispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
            // For more info see https://docs.microsoft.com/en-us/dotnet/api/system.windows.application.dispatcherunhandledexception?view=windowsdesktop-6.0
        }
    }
}
