using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Models
{
    public class Fine
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
    }
}
