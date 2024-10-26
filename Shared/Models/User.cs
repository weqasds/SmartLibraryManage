using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Models
{
    public class User
    {
        public int UserID {  get; set; }
        public string UserName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public int Role {  get; set; }
        public string Email { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } =string.Empty;
        public DateTime CreatTime { get; set; }
        public DateTime UpdateTime { get; set; }


    }
}
