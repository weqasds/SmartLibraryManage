using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Shared.Models;

namespace Shared
{
    public class LibraryDbContext:DbContext
    {
        internal DbSet<User> Users { get; set; }
        internal DbSet<Book> Books { get; set; }
        internal DbSet<BorrowRecord> BorrowRecords { get; set; }
        internal DbSet<Fine> Fines { get; set; }
        public LibraryDbContext() : base() { }
        //DbContextOptions<LibraryDbContext> dbContextOptions
        public LibraryDbContext(DbContextOptions<LibraryDbContext> dbContextOptions):base(dbContextOptions)
        { }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseNpgsql();
        //}
    }
}
