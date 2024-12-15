using Shared.Models;
using Shared.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Services.UserImpl
{
    public class BorrowRecordService(LibraryDbContext _context) : IService<Borrowrecord>
    {
        
        public LibraryDbContext Context {get {return _context;}}

        public int Insert(IEnumerable<Borrowrecord> e)
        {
            return this.InsertDefault(e);
        }
        public int Insert(Borrowrecord e)
        {
            _context.BorrowRecords.Add(e);
            return _context.SaveChanges();
        }
        public int Delete(int id)
        {
            return this.DeleteDefault(id);
        }

        public int Delete(Borrowrecord e)
        {
            var deleteBorrowRecord = _context.BorrowRecords.FirstOrDefault(item => item == e);
            if (deleteBorrowRecord == null)return 0;
            _context.BorrowRecords.Remove(deleteBorrowRecord);
            return _context.SaveChanges();
        }

        public int Delete(IEnumerable<int> ids)
        {
            var deleteBorrowRecords = _context.BorrowRecords.Where(item=>ids.Contains(item.Recordid));
            if (!deleteBorrowRecords.Any()) return 0;
            _context.BorrowRecords.RemoveRange(deleteBorrowRecords);
            return _context.SaveChanges();
            
        }

        public Borrowrecord Select(int id)
        {
            return this.SelectDefault(id);
        }

        public Borrowrecord Select(Borrowrecord e)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Borrowrecord> Select(IEnumerable<int> ids)
        {
            throw new NotImplementedException();
        }
        public int Update(Borrowrecord value)
        {
            var updateBorrowRecord = _context.BorrowRecords.Find(value.Recordid);
            if (updateBorrowRecord == null) return 0;
            _context.Entry(updateBorrowRecord).CurrentValues.SetValues(value);
            updateBorrowRecord.Updatetime = DateTime.Now;
            return _context.SaveChanges();
        }

        public int Update(int id, Borrowrecord value)
        {
            var updateBorrowRecord = _context.BorrowRecords.Find(id);
            if (updateBorrowRecord == null) return 0;
            value.Recordid = id;
            _context.Entry(updateBorrowRecord).CurrentValues.SetValues(value);
            throw new NotImplementedException();
        }


        public int Update(IEnumerable<int> ids, IEnumerable<Borrowrecord> values)
        {
            var updateBorrowRecords = from record in _context.BorrowRecords
                                      join id in ids on record.Recordid equals id
                                      select record;
            foreach (var record in updateBorrowRecords)
            {
                var updateValue = values.FirstOrDefault(item => item.Recordid == record.Recordid);
                if (updateValue == null) continue;
                _context.Entry(record).CurrentValues.SetValues(updateValue);
                record.Updatetime = DateTime.Now;
            }
            return _context.SaveChanges();  
        }
    }
}
