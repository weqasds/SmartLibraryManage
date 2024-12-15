using Shared.Models;
using Shared.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Services.UserImpl
{
    public class FineService : IService<Fine>
    {
        private LibraryDbContext _context;

        public LibraryDbContext Context
        {
            get { return _context; }
        }

        public FineService(LibraryDbContext context) => _context = context;

        public int Insert(IEnumerable<Fine> e)
        {
            return this.InsertDefault(e);
        }
        public int Insert(Fine e)
        {
            _context.Fines.Add(e);
            return _context.SaveChanges();
        }

        public int Delete(int id)
        {
            return this.DeleteDefault(id);
        }

        public int Delete(Fine e)
        {
            var deleteFine = _context.Fines.FirstOrDefault(item => item == e);
            if (deleteFine == null) return 0;
            _context.Fines.Remove(deleteFine);
            return _context.SaveChanges();
        }

        public int Delete(IEnumerable<int> ids)
        {
            var deleteFines = _context.Fines.Where(item => ids.Contains(item.Fineid));
            if (!deleteFines.Any()) return 0;
            _context.Fines.RemoveRange(deleteFines);
            return _context.SaveChanges();
        }

        public Fine Select(int id) => this.SelectDefault(id);

        public Fine Select(Fine e)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Fine> Select(IEnumerable<int> ids)
        {
            throw new NotImplementedException();
        }

        public int Update(Fine value)
        {
            var fine = _context.Fines.Find(value.Fineid);
            if (fine == null) return 0;
            _context.Entry(fine).CurrentValues.SetValues(value);
            fine.Updatetime = DateTime.Now;
            return _context.SaveChanges();
        }

        public int Update(int id, Fine value)
        {
            var fine = _context.Fines.Find(id);
            if (fine == null) return 0;
            value.Fineid = id;
            _context.Entry(fine).CurrentValues.SetValues(value);
            return _context.SaveChanges();
        }


        public int Update(IEnumerable<int> ids, IEnumerable<Fine> values)
        {
            var fines = from value in _context.Fines
                where ids.Contains(value.Fineid)
                select value;
            // 使用Join操作来减少循环中的查询次数，提升效率
            var updatesMap = values.ToDictionary(v => v.Fineid, v => v);

            foreach (var fine in fines)
            {
                if (updatesMap.TryGetValue(fine.Fineid, out var updateValue))
                {
                    // 使用Entity Framework的SetValues方法批量更新属性
                    _context.Entry(fine).CurrentValues.SetValues(updateValue);
                    // 更新UpdateTime字段
                    fine.Updatetime = DateTime.Now;
                }
            }
           return _context.SaveChanges();
        }
    }
}