using Shared.Models;
using Shared.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Services.UserImpl
{
    public class UserService : IService<User>
    {
        private LibraryDbContext _context;
        public UserService(LibraryDbContext dbContext)
        {
            _context = dbContext;
        }
        public int Delete(int id)
        {
            throw new NotImplementedException();
        }

        public int Delete(User e)
        {
            throw new NotImplementedException();
        }

        public int Delete(IEnumerable<int> ids)
        {
            throw new NotImplementedException();
        }

        public int Insert(IEnumerable<User> e)
        {
            throw new NotImplementedException();
        }

        public User Select(int id)
        {
            throw new NotImplementedException();
        }

        public User Select(User e)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> Select(IEnumerable<int> ids)
        {
            throw new NotImplementedException();
        }

        public int Update(int id)
        {
            throw new NotImplementedException();
        }

        public int Update(User e)
        {
            throw new NotImplementedException();
        }

        public int Update(IEnumerable<int> ids)
        {
            throw new NotImplementedException();
        }
    }
}
