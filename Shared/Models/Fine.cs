using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Models
{
    public class Fine : IEquatable<Fine?>
    {
        public int FineID { get; set; }
        public int RecordID { get; set; }
        public int UserID { get; set; }
        public decimal Amount { get; set; }
        public string Status { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime UpdateTime { get; set; }

        // 导航属性
        public virtual BorrowRecord BorrowRecord { get; set; }
        public virtual User User { get; set; }

        public override bool Equals(object? obj)
        {
            return Equals(obj as Fine);
        }

        public bool Equals(Fine? other)
        {
            return other is not null &&
                   FineID == other.FineID &&
                   RecordID == other.RecordID &&
                   UserID == other.UserID &&
                   Amount == other.Amount &&
                   Status == other.Status &&
                   CreateTime == other.CreateTime &&
                   UpdateTime == other.UpdateTime &&
                   EqualityComparer<BorrowRecord>.Default.Equals(BorrowRecord, other.BorrowRecord) &&
                   EqualityComparer<User>.Default.Equals(User, other.User);
        }

        public override int GetHashCode()
        {
            HashCode hash = new HashCode();
            hash.Add(FineID);
            hash.Add(RecordID);
            hash.Add(UserID);
            hash.Add(Amount);
            hash.Add(Status);
            hash.Add(CreateTime);
            hash.Add(UpdateTime);
            hash.Add(BorrowRecord);
            hash.Add(User);
            return hash.ToHashCode();
        }

        public static bool operator ==(Fine? left, Fine? right)
        {
            return EqualityComparer<Fine>.Default.Equals(left, right);
        }

        public static bool operator !=(Fine? left, Fine? right)
        {
            return !(left == right);
        }
    }
}
