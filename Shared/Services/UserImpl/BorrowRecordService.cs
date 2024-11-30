using Shared.Models;
using Shared.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Services.UserImpl
{
    public class BorrowRecordService(LibraryDbContext _context) : IService<BorrowRecord>
    {
        
        public LibraryDbContext Context {get {return _context;}}

        public int Insert(IEnumerable<BorrowRecord> e)
        {
            return this.InsertDefault(e);
        }
        public int Delete(int id)
        {
            return this.DeleteDefault(id);
        }

        public int Delete(BorrowRecord e)
        {
            var deleteBorrowRecord = _context.BorrowRecords.FirstOrDefault(item => item == e);
            if (deleteBorrowRecord == null)return 0;
            _context.BorrowRecords.Remove(deleteBorrowRecord);
            return _context.SaveChanges();
        }

        public int Delete(IEnumerable<int> ids)
        {
            var deleteBorrowRecords = _context.BorrowRecords.Where(item=>ids.Contains(item.RecordID));
            if (!deleteBorrowRecords.Any()) return 0;
            _context.BorrowRecords.RemoveRange(deleteBorrowRecords);
            return _context.SaveChanges();
            
        }

        public BorrowRecord Select(int id)
        {
            return this.SelectDefault(id);
        }

        public BorrowRecord Select(BorrowRecord e)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<BorrowRecord> Select(IEnumerable<int> ids)
        {
            throw new NotImplementedException();
        }
        public int Update(BorrowRecord value)
        {
            var updateBorrowRecord = _context.BorrowRecords.Find(value.RecordID);
            if (updateBorrowRecord == null) return 0;
            _context.Entry(updateBorrowRecord).CurrentValues.SetValues(value);
            updateBorrowRecord.UpdateTime = DateTime.Now;
            return _context.SaveChanges();
        }

        public int Update(int id, BorrowRecord value)
        {
            var updateBorrowRecord = _context.BorrowRecords.Find(id);
            if (updateBorrowRecord == null) return 0;
            value.RecordID = id;
            _context.Entry(updateBorrowRecord).CurrentValues.SetValues(value);
            throw new NotImplementedException();
        }


        public int Update(IEnumerable<int> ids, IEnumerable<BorrowRecord> values)
        {
            var updateBorrowRecords = from record in _context.BorrowRecords
                                      join id in ids on record.RecordID equals id
                                      select record;
            foreach (var record in updateBorrowRecords)
            {
                var updateValue = values.FirstOrDefault(item => item.RecordID == record.RecordID);
                if (updateValue == null) continue;
                _context.Entry(record).CurrentValues.SetValues(updateValue);
                record.UpdateTime = DateTime.Now;
            }
            return _context.SaveChanges();  
        }
    }
}
