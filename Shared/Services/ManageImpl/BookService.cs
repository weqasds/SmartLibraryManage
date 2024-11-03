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
        public int Delete(int id)
        {
            throw new NotImplementedException();
        }

        public int Delete(Book e)
        {
            throw new NotImplementedException();
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
