using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Models
{

    internal class BorrowRecord
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
    }

}
