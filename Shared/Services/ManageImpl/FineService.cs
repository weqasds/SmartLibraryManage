using Shared.Models;
using Shared.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Services.ManageImpl
{
    public class FineService : IService<Fine>
    {
        public int Delete(LibraryDbContext entity, int id)
        {
            throw new NotImplementedException();
        }

        public int Delete(LibraryDbContext entity, Fine e)
        {
            throw new NotImplementedException();
        }

        public int Delete(LibraryDbContext entity, IEnumerable<int> ids)
        {
            throw new NotImplementedException();
        }

        public int Insert(LibraryDbContext entity, IEnumerable<Fine> e)
        {
            throw new NotImplementedException();
        }

        public Fine Select(LibraryDbContext entity, int id)
        {
            throw new NotImplementedException();
        }

        public Fine Select(LibraryDbContext entity, Fine e)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Fine> Select(LibraryDbContext entity, IEnumerable<int> ids)
        {
            throw new NotImplementedException();
        }

        public int Update(LibraryDbContext entity, int id)
        {
            throw new NotImplementedException();
        }

        public int Update(LibraryDbContext entity, Fine e)
        {
            throw new NotImplementedException();
        }

        public int Update(LibraryDbContext entity, IEnumerable<int> ids)
        {
            throw new NotImplementedException();
        }
    }
}
