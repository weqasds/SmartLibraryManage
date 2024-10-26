using Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartLibraryManage.ViewModels.Pages
{
    public class LoginViewModel:ObservableObject
    {
        private User user;
        public User User {
            get { return user; }
            set { user = value; }
        }
        public LoginViewModel() { }

    }
}
