using Shared.Models;
using Shared.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Shared.Services.ManageImpl
{
    public class FineService : IService<Fine>
    {
        private LibraryDbContext _context;
        public LibraryDbContext Context { get{return _context;} }
        public FineService(LibraryDbContext context) => _context = context;
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
            var deleteFines = _context.Fines.Where(item => ids.Contains(item.FineID));
            if (!deleteFines.Any()) return 0;
            _context.Fines.RemoveRange(deleteFines);
            return _context.SaveChanges();
        }

        public int Insert(IEnumerable<Fine> e)
        {
            _context.Fines.AddRange(e);
            throw new NotImplementedException();
        }

        public Fine Select(int id)=> this.SelectDefault(id);

        public Fine Select(Fine e)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Fine> Select(IEnumerable<int> ids)
        {
            throw new NotImplementedException();
        }

        public int Update(int id, Fine value)
        {
            var fine = _context.Fines.Find(id);
            if (fine == null) return 0;
            value.FineID = id;
            _context.Entry(fine).CurrentValues.SetValues(value);
            fine.UpdateTime = DateTime.Now;
            return _context.SaveChanges();
        }

        public int Update(Fine value)
        {
            var fine = _context.Fines.Find(value.FineID);
            if (fine == null) return 0;
            _context.Entry(fine).CurrentValues.SetValues(value);
            fine.UpdateTime = DateTime.Now; // 同上
            return _context.SaveChanges();
        }

        public int Update(IEnumerable<int> ids, IEnumerable<Fine> values)
        {
            var fines = from fine in _context.Fines
                where ids.Contains(fine.FineID)
                select fine;

            foreach (var item in fines)
            {
                var updateFine = values.FirstOrDefault(v => v.FineID == item.FineID);
                if (updateFine != null)
                {
                    _context.Entry(item).CurrentValues.SetValues(updateFine);
                    item.UpdateTime = DateTime.Now; // 更新时间
                }
            }

            return _context.SaveChanges();
        }
    }
}
