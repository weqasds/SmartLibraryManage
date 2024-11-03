using Microsoft.EntityFrameworkCore;
using Shared.Models;
using Shared.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Services.UserImpl
{
    public class BookService : IService<Book>
    {
        private LibraryDbContext _context;
        public BookService(LibraryDbContext dbContext) => _context = dbContext;

        public int Delete(int id)
        {

            var book = _context.Books.Single(e => e.BookID == id);
            _context.Entry(book).State = EntityState.Deleted;
            return _context.SaveChanges();
        }

        public int Delete(Book e)
        {
            var book = _context.Books.Select(de => de == e).FirstOrDefault();
            _context.Entry(book).State = EntityState.Deleted;
            return _context.SaveChanges();
        }

        public int Delete(IEnumerable<int> ids)
        {
            throw new NotImplementedException();
        }

        public int Insert(IEnumerable<Book> e)
        {
            throw new NotImplementedException();
        }

        public Book Select(int id)
        {
            throw new NotImplementedException();
        }

        public Book Select(Book e)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Book> Select(IEnumerable<int> ids)
        {
            throw new NotImplementedException();
        }

        public int Update(int id)
        {
            throw new NotImplementedException();
        }

        public int Update(Book e)
        {
            throw new NotImplementedException();
        }

        public int Update(IEnumerable<int> ids)
        {
            throw new NotImplementedException();
        }
    }
}
