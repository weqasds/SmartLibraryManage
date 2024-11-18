using Shared.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserLibrary.ViewModels.Pages
{
    public partial class RegisterViewModel : ObservableObject
    {
        [ObservableProperty]
        private string? userId;
        [ObservableProperty]
        private string? userName;
        [ObservableProperty]
        private string? passWord;
        public RegisterViewModel(string userID,string userName,string passWord)
        {
            this.userId = userID;
            this.userName = userName;
            this.passWord = passWord;   
        }
        public RegisterViewModel()
        {
            this.userId = null;
            this.userName = null;
            this.passWord = null;
        }
        [RelayCommand]
        private async Task Register()
        {
           
            
        }
    }
}
