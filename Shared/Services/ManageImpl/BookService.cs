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
            var bookssToDelete = _context.Users.Where(u => ids.Contains(u.Userid));
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
        public int Insert(Book e)
        {
            _context.Books.Add(e);
            return _context.SaveChanges();
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
            value.Bookid= id;
            _context.Entry(book).CurrentValues.SetValues(value);
            book.Updatetime = DateTime.Now;
            return _context.SaveChanges();
        }

        public int Update(Book value)
        {
            var book = _context.Books.Find(value.Bookid);
            if (book == null) return 0;
            value.Bookid = book.Bookid;
            _context.Entry(book).CurrentValues.SetValues(value);
            book.Updatetime = DateTime.Now;
            return _context.SaveChanges();
        }

        public int Update(IEnumerable<int> ids,IEnumerable<Book> values)
        {
            var books = from book in _context.Books
                where ids.Contains(book.Bookid)
                select book;

            foreach (var item in books)
            {
                var updateBook = values.FirstOrDefault(v => v.Bookid == item.Bookid);
                if (updateBook != null)
                {
                    updateBook.Bookid = item.Bookid;
                    _context.Entry(item).CurrentValues.SetValues(updateBook);
                    item.Updatetime = DateTime.Now; // 更新时间
                }
            }

            return _context.SaveChanges();
        }
    }
}
