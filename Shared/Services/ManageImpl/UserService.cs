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
        private LibraryDbContext _context;
        public LibraryDbContext Context{ get => _context;}
        
        public int Delete(int id)
        {
            return this.DeleteDefault(id);
            
        }

        public int Delete(User e)
        {
            var deleteUser = _context.Users.FirstOrDefault(item => item == e);
            if (deleteUser == null)return 0;
            _context.Users.Remove(deleteUser);
            return _context.SaveChanges();
        }

        public int Delete(IEnumerable<int> ids)
        {
            var deleteUsers = _context.Users.Where(item => ids.Contains(item.Userid));
            if (!deleteUsers.Any()) return 0;
            _context.Users.RemoveRange(deleteUsers);
            return _context.SaveChanges();
        }

        public int Insert(IEnumerable<User> values)
        {
            _context.Users.AddRange(values);
            return _context.SaveChanges();
        }

        public int Insert(User e)
        {
            _context.Users.Add(e);
            return _context.SaveChanges();
        }

        public User Select(int id)=> this.SelectDefault(id);


        public User Select(User e)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> Select(IEnumerable<int> ids)
        {
            throw new NotImplementedException();
        }

        public int Update(int id, User value)
        {
            var user=_context.Users.Find(id);
            if (user == null) return 0;
            _context.Entry(user).CurrentValues.SetValues(value);
            user.Updatetime = DateTime.Now;
            return _context.SaveChanges();
        }

        public int Update(User value)
        {
            var user = _context.Users.Find(value.Userid);
            if (user == null) return 0;
            _context.Entry(user).CurrentValues.SetValues(value);
            user.Updatetime = DateTime.Now;
            return _context.SaveChanges();
        }

        public int Update(IEnumerable<int> ids, IEnumerable<User> values)
        {
            var users = from user in _context.Users
                where ids.Contains(user.Userid)
                select user;

            foreach (var item in users)
            {
                var updateUser = values.FirstOrDefault(v => v.Userid == item.Userid);
                if (updateUser != null)
                {
                    _context.Entry(item).CurrentValues.SetValues(updateUser);
                    // 假设User类也有一个类似UpdateTime的字段，用于记录更新时间
                    item.Updatetime = DateTime.Now;
                }
            }

            return _context.SaveChanges();
        }
    }
}
