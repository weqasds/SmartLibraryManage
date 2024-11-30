using Shared.Models;
using Shared.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Services.ManageImpl
{
    public class BookService : IService<Book>
    {
        private LibraryDbContext _context;
        public LibraryDbContext Context { get{return _context;} }
        public BookService(LibraryDbContext context) => _context = context;
        public int Delete(int id)=>this.DeleteDefault(id);

        public int Delete(Book value)
        {
            var book = _context.Books.FirstOrDefault(de => de == value);
            if (book == null) return 0;
            _context.Books.Remove(book);
            return _context.SaveChanges();
        }

        public int Delete(IEnumerable<int> ids)
        {
            var bookssToDelete = _context.Users.Where(u => ids.Contains(u.UserID));
            if (!bookssToDelete.Any()) return 0;
            _context.Users.RemoveRange(bookssToDelete);
            return _context.SaveChanges();
        }

        public int Insert(IEnumerable<Book> e)
        {
            if (!e.Any()) return 0;
            _context.Books.AddRange(e);
            throw new NotImplementedException();
        }

        public Book Select(int id)=>this.SelectDefault(id);

        public Book Select(Book e)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Book> Select(IEnumerable<int> ids)
        {
            throw new NotImplementedException();
        }

        public int Update(int id, Book value)
        {
            var book = _context.Books.Find(id);
            if (book == null) return 0;
            value.BookID= id;
            _context.Entry(book).CurrentValues.SetValues(value);
            book.UpdateTime = DateTime.Now;
            return _context.SaveChanges();
        }

        public int Update(Book value)
        {
            var book = _context.Books.Find(value.BookID);
            if (book == null) return 0;
            value.BookID = book.BookID;
            _context.Entry(book).CurrentValues.SetValues(value);
            book.UpdateTime = DateTime.Now;
            return _context.SaveChanges();
        }

        public int Update(IEnumerable<int> ids,IEnumerable<Book> values)
        {
            var books = from book in _context.Books
                where ids.Contains(book.BookID)
                select book;

            foreach (var item in books)
            {
                var updateBook = values.FirstOrDefault(v => v.BookID == item.BookID);
                if (updateBook != null)
                {
                    updateBook.BookID = item.BookID;
                    _context.Entry(item).CurrentValues.SetValues(updateBook);
                    item.UpdateTime = DateTime.Now; // 更新时间
                }
            }

            return _context.SaveChanges();
        }
    }
}
