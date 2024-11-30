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
    public class BookService: IService<Book>
    {
        private LibraryDbContext _context;
        public LibraryDbContext Context => _context;
        public BookService(LibraryDbContext context)=>_context = context;
        //失败码 0 成功为非0数
        public int Delete(int id)
        {

            //var book = _context.Books.Single(e => e.BookID == id);

            //_context.Entry(book).State = EntityState.Deleted;
            var deleteBook = _context.Books.Find(id);
            if (deleteBook == null) return 0;
            _context.Books.Remove(deleteBook);
            return _context.SaveChanges();
        }

        public int Delete(Book value)
        {
            var book = _context.Books.FirstOrDefault(de => de == value);
            if (book == null) return 0;
            _context.Books.Remove(book);
            return _context.SaveChanges();
        }

        public int Delete(IEnumerable<int> ids)
        {
            var deleteBooks = _context.Books.Where(b => ids.Contains(b.BookID));
            if (!deleteBooks.Any()) return 0;
            _context.Books.RemoveRange(deleteBooks);
            return _context.SaveChanges();
        }

        public int Insert(IEnumerable<Book> e)
        {
            if(!e.Any()) return 0;
            _context.Books.AddRange(e);
            return _context.SaveChanges();
        }

        public Book Select(int id)
        {
            var book = _context.Books.Find(id);
            if (book == null) return new Book();
            return book;
        }

        public Book Select(Book e)
        {
            var book = _context.Books.FirstOrDefault(s => s == e);
            return book ?? new Book();

        }

        public IEnumerable<Book> Select(IEnumerable<int> ids)
        {

            return _context.Books.Where(b => ids.Contains(b.BookID));
        }

        public int Update(int id, Book value)
        {
            var book = _context.Books.Find(id);

            if (book == null) return 0;
            value.BookID = id;
            _context.Entry(book).CurrentValues.SetValues(value);
            return _context.SaveChanges();
        }

        public int Update(Book value)
        {
            var book = _context.Books.FirstOrDefault(b => b.BookID == value.BookID);
            if (book == null) return 0;
            _context.Entry(book).CurrentValues.SetValues(value);
            book.UpdateTime = DateTime.Now;
            return _context.SaveChanges();
        }

        public int Update(IEnumerable<int> ids, IEnumerable<Book> values)
        {
            var books = from book in _context.Books
                        where ids.Contains(book.BookID)
                        select book; 
            
            foreach (var item in books)
            {
                var updateValue = values.FirstOrDefault(v => v.BookID == item.BookID);
                if (updateValue != null)
                {
                    _context.Entry(item).CurrentValues.SetValues(updateValue);
                    item.UpdateTime = DateTime.Now;
                }
            }
            return _context.SaveChanges();
        }
    }
}
