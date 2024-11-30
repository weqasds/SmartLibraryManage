using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Models
{
    public class User : IEquatable<User?>
    {
        public int UserID {  get; set; }
        public string UserName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public int Role {  get; set; }
        public string Email { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } =string.Empty;
        public DateTime CreatTime { get; set; }
        public DateTime UpdateTime { get; set; }

        public override bool Equals(object? obj)
        {
            return Equals(obj as User);
        }

        public bool Equals(User? other)
        {
            return other is not null &&
                   UserID == other.UserID &&
                   UserName == other.UserName &&
                   Password == other.Password &&
                   Role == other.Role &&
                   Email == other.Email &&
                   PhoneNumber == other.PhoneNumber &&
                   CreatTime == other.CreatTime &&
                   UpdateTime == other.UpdateTime;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(UserID, UserName, Password, Role, Email, PhoneNumber, CreatTime, UpdateTime);
        }

        public static bool operator ==(User? left, User? right)
        {
            return EqualityComparer<User>.Default.Equals(left, right);
        }

        public static bool operator !=(User? left, User? right)
        {
            return !(left == right);
        }
    }
}
