using Shared.Models;
using Shared.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Services.ManageImpl
{
    public class UserService : IService<User>
    {
        public int Delete(LibraryDbContext entity, int id)
        {
            throw new NotImplementedException();
        }

        public int Delete(LibraryDbContext entity, User e)
        {
            throw new NotImplementedException();
        }

        public int Delete(LibraryDbContext entity, IEnumerable<int> ids)
        {
            throw new NotImplementedException();
        }

        public int Insert(LibraryDbContext entity, IEnumerable<User> e)
        {
            throw new NotImplementedException();
        }

        public User Select(LibraryDbContext entity, int id)
        {
            throw new NotImplementedException();
        }

        public User Select(LibraryDbContext entity, User e)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> Select(LibraryDbContext entity, IEnumerable<int> ids)
        {
            throw new NotImplementedException();
        }

        public int Update(LibraryDbContext entity, int id)
        {
            throw new NotImplementedException();
        }

        public int Update(LibraryDbContext entity, User e)
        {
            throw new NotImplementedException();
        }

        public int Update(LibraryDbContext entity, IEnumerable<int> ids)
        {
            throw new NotImplementedException();
        }
    }
}
