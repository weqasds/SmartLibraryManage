using iNKORE.UI.WPF.Modern.Controls;
using Shared.Models;
using Shared.Services.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.System;

namespace UserLibrary.ViewModels.Pages
{
    public partial class RegisterViewModel : ObservableValidator
    {
        private readonly IService<Shared.Models.User> _userService;
        
        //[ObservableProperty]
        //private int? userId;
        [Required]
        [ObservableProperty]
        [MinLength(1)]
        private string? username;
        [Required]
        [MinLength(8)]
        [MaxLength(20)]
        [ObservableProperty]
        private string? password;
        public RegisterViewModel(IService<Shared.Models.User> userService)
        {
            _userService = userService;
        }
#if DESIGN



        public RegisterViewModel() { }
#endif
        [RelayCommand]
        private async Task Register()
        {
            /*var result = await App.Current.Dispatcher.InvokeAsync(() =>
            //{

            //    var user = new Shared.Models.User(){ 
            //        UserID = 100,
            //        UserName = userName,
            //        PassWord = passWord,
            //    };

            //    return _userService.Insert(user);
            //});*/
#if DEBUG
            Debug.WriteLine(Password);
#endif
            ValidateAllProperties();
            if (Username!=string.Empty&& Password != string.Empty) {
                var user = new Shared.Models.User()
                {
                    Username = Username,
                    Password = Password,
                    Role = "user"
                };
                var result = _userService.Insert(user);
                if (result == 1)
                {
                    var message = "ok";
                    var messageBox = new iNKORE.UI.WPF.Modern.Controls.MessageBox();
                    messageBox.Content = message;
                    messageBox.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                    messageBox.Show();
                }
            }
            





        }

        partial void OnPasswordChanged(string? value)
        {
            Debug.WriteLine(Password);
        }
    }
}
