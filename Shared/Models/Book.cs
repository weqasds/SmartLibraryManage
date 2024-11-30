using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Models
{
    public class Book : IEquatable<Book?>
    {
        public int BookID { get; set; }
        public string ISBN { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public string Publisher { get; set; } = string.Empty;
        public DateTime DATE { get; set; }
        public string Category { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int TotalCopies { get; set; }
        public int AvailableCopies { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime UpdateTime { get; set; }
        public string Description { get; set; } = string.Empty;

        public override bool Equals(object? obj)
        {
            return Equals(obj as Book);
        }

        public bool Equals(Book? other)
        {
            return other is not null &&
                   BookID == other.BookID &&
                   ISBN == other.ISBN &&
                   Title == other.Title &&
                   Author == other.Author &&
                   Publisher == other.Publisher &&
                   DATE == other.DATE &&
                   Category == other.Category &&
                   Price == other.Price &&
                   TotalCopies == other.TotalCopies &&
                   AvailableCopies == other.AvailableCopies &&
                   CreateTime == other.CreateTime &&
                   UpdateTime == other.UpdateTime &&
                   Description == other.Description;
        }

        public override int GetHashCode()
        {
            HashCode hash = new HashCode();
            hash.Add(BookID);
            hash.Add(ISBN);
            hash.Add(Title);
            hash.Add(Author);
            hash.Add(Publisher);
            hash.Add(DATE);
            hash.Add(Category);
            hash.Add(Price);
            hash.Add(TotalCopies);
            hash.Add(AvailableCopies);
            hash.Add(CreateTime);
            hash.Add(UpdateTime);
            hash.Add(Description);
            return hash.ToHashCode();
        }

        public static bool operator ==(Book? left, Book? right)
        {
            return EqualityComparer<Book>.Default.Equals(left, right);
        }

        public static bool operator !=(Book? left, Book? right)
        {
            return !(left == right);
        }

    }
}
