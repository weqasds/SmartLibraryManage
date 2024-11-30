using Shared.Models;
using Shared.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Services.UserImpl
{
    public class UserService: IService<User>
    {
        private readonly LibraryDbContext _context;
        public LibraryDbContext Context { get { return _context; } }
        public UserService(LibraryDbContext context) => _context = context;

        public int Delete(int id)
        {
            var deleteUser = _context.Users.FirstOrDefault(book => book.UserID == id);
            Console.WriteLine(deleteUser);
            IEnumerable<User> deleteUser1 = from user in _context.Users
                                            where user.UserID == id
                                            select user;
            foreach (var book in deleteUser1)
            {
                _context.Users.Remove(book);
            }
            if(deleteUser==null)return 0;
            _context.Users.Remove(deleteUser);
            return _context.SaveChanges();
        }

        public int Delete(User e)
        {
            return Delete(e.UserID);
            throw new NotImplementedException();
        }

        public int Delete(IEnumerable<int> ids)
        {
            IEnumerable<User> deleteUsers= from user in _context.Users
                                           where ids.Contains(user.UserID)
                                           select user;
            if(deleteUsers==null) return 0;
            _context.Users.RemoveRange(deleteUsers);
            return _context.SaveChanges();
        }

        public int Insert(IEnumerable<User> e)
        {
            if(e==null) return 0;
            _context.Users.AddRangeAsync(e);
            return _context.SaveChanges();
        }

        public User Select(int id)=> this.SelectDefault(id);

        public User Select(User e)
        {
            var users = from user in _context.Users
                        where user==e
                        select user;
            return users.FirstOrDefault() ?? new User();
            
        }

        public IEnumerable<User> Select(IEnumerable<int> ids)
        {
            var users= from user in _context.Users
                       where ids.Contains(user.UserID)
                       select user;
            _context.SaveChanges();
            return users;
            
        }

        public int Update(int id,User value)
        {
            var user = _context.Users.Find(id);
            if (user == null) return 0;
            value.UserID = id;
            _context.Entry(user).CurrentValues.SetValues(value);
            return _context.SaveChanges();
        }

        public int Update(User value)
        {
            var user=_context.Users.Find(value.UserID);
            if(user==null)
            {
                return _context.SaveChanges();
                //啥也没找到
            }
            _context.Entry(user).CurrentValues.SetValues(value);
            user.UpdateTime = DateTime.Now;
            return _context.SaveChanges();
        }

        public int Update(IEnumerable<int> ids,IEnumerable<User> values)
        {
            var users =from user in _context.Users
                       where ids.Contains(user.UserID)
                       select user;

            _context.Users.UpdateRange(users);
            return _context.SaveChanges();
        }
    }
}
