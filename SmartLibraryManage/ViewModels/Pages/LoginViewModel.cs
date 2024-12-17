using Shared.Models;
using Shared.Services.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartLibraryManage.ViewModels.Pages
{
    public partial class LoginViewModel:ObservableValidator
    {
        private readonly IService<Shared.Models.User> _userService;
        [Required]
        [ObservableProperty]
        private string? username;
        [Required]
        [ObservableProperty]
        private string? password;
        public LoginViewModel(IService<Shared.Models.User> userService) {
            _userService = userService;
        }
        [RelayCommand]
        private void Login()
        {
            ValidateAllProperties();


        }
        [RelayCommand]
        private void Register()
        {

        }

    }
}
