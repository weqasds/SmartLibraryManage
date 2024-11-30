using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Models
{

    public class BorrowRecord : IEquatable<BorrowRecord?>
    {
        public int RecordID { get; set; }
        public int UserID { get; set; }
        public int BookID { get; set; }
        public DateTime BorrowDate { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public string Status { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime UpdateTime { get; set; }
        // 导航属性
        public User User { get; set; }
        public Book Book { get; set; }

        public override bool Equals(object? obj)
        {
            return Equals(obj as BorrowRecord);
        }

        public bool Equals(BorrowRecord? other)
        {
            return other is not null &&
                   RecordID == other.RecordID &&
                   UserID == other.UserID &&
                   BookID == other.BookID &&
                   BorrowDate == other.BorrowDate &&
                   DueDate == other.DueDate &&
                   ReturnDate == other.ReturnDate &&
                   Status == other.Status &&
                   CreateTime == other.CreateTime &&
                   UpdateTime == other.UpdateTime &&
                   EqualityComparer<User>.Default.Equals(User, other.User) &&
                   EqualityComparer<Book>.Default.Equals(Book, other.Book);
        }

        public override int GetHashCode()
        {
            HashCode hash = new HashCode();
            hash.Add(RecordID);
            hash.Add(UserID);
            hash.Add(BookID);
            hash.Add(BorrowDate);
            hash.Add(DueDate);
            hash.Add(ReturnDate);
            hash.Add(Status);
            hash.Add(CreateTime);
            hash.Add(UpdateTime);
            hash.Add(User);
            hash.Add(Book);
            return hash.ToHashCode();
        }

        public static bool operator ==(BorrowRecord? left, BorrowRecord? right)
        {
            return EqualityComparer<BorrowRecord>.Default.Equals(left, right);
        }

        public static bool operator !=(BorrowRecord? left, BorrowRecord? right)
        {
            return !(left == right);
        }
    }

}
