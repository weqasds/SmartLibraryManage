using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Shared.Interface;

namespace Shared
{
    public class LibraryDbContext:DbContext
    {
        public DbSet<IUser> Users { get; set; }
        public DbSet<IBook> Books { get; set; }
        public DbSet<IBorrowRecord> BorrowRecords { get; set; }
        public DbSet<IFine> Fines { get; set; }

    }
}
