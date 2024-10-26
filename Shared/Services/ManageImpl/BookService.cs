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
        public int Delete(LibraryDbContext entity, int id)
        {
            throw new NotImplementedException();
        }

        public int Delete(LibraryDbContext entity, Book e)
        {
            throw new NotImplementedException();
        }

        public int Delete(LibraryDbContext entity, IEnumerable<int> ids)
        {
            throw new NotImplementedException();
        }

        public int Insert(LibraryDbContext entity, IEnumerable<Book> e)
        {
            throw new NotImplementedException();
        }

        public Book Select(LibraryDbContext entity, int id)
        {
            throw new NotImplementedException();
        }

        public Book Select(LibraryDbContext entity, Book e)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Book> Select(LibraryDbContext entity, IEnumerable<int> ids)
        {
            throw new NotImplementedException();
        }

        public int Update(LibraryDbContext entity, int id)
        {
            throw new NotImplementedException();
        }

        public int Update(LibraryDbContext entity, Book e)
        {
            throw new NotImplementedException();
        }

        public int Update(LibraryDbContext entity, IEnumerable<int> ids)
        {
            throw new NotImplementedException();
        }
    }
}
