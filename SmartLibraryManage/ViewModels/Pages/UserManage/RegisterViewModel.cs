using Shared.Services.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartLibraryManage.Helpers;
namespace SmartLibraryManage.ViewModels.Pages.UserManage;

public partial class RegisterViewModel:ObservableValidator
{
    private readonly IService<Shared.Models.User>? _userService;
    [Required]
    [ObservableProperty]
    [MinLength(8)]
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
#if DEBUG
        Debug.WriteLine(Password);
#endif
        ValidateAllProperties();
        Secure secure = new Secure("D:\\source\\repos\\SmartLibraryManage\\keyfile.txt");

        if (Username != string.Empty && Password != string.Empty)
        {
            var user = new Shared.Models.User()
            {
                Username = Username,
                Password = secure.EncryptPassword(this.Password),
                Role = "manage"
            };
            var result = _userService.Insert(user);
            if (result == 1)
            {
                var message = "ok";
                var messageBox = new Wpf.Ui.Controls.MessageBox();
                messageBox.Content = message;
                messageBox.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                await messageBox.ShowDialogAsync();
            }
        }
    }
}
