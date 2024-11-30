using Shared.Models;
using Shared.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Services.ManageImpl
{
    public class BorrowRecordService : IService<BorrowRecord>
    {
        private LibraryDbContext _context;
        public LibraryDbContext Context { get{return _context;} }
        public BorrowRecordService(LibraryDbContext context) => _context = context;
        public int Delete(int id)=> this.DeleteDefault(id);
        public int Delete(BorrowRecord value)
        {
            var recordToDelete = _context.BorrowRecords.FirstOrDefault(item=>item == value);
            if (recordToDelete == null) return 0;
            _context.BorrowRecords.Remove(recordToDelete);
            return _context.SaveChanges();
        }

        public int Delete(IEnumerable<int> ids)
        {
            var deleteRecords = _context.BorrowRecords.Where(item=>ids.Contains(item.RecordID));
            if (!deleteRecords.Any()) return 0;
            _context.BorrowRecords.RemoveRange(deleteRecords);
            return _context.SaveChanges();
        }

        public int Insert(IEnumerable<BorrowRecord> values)
        {
            _context.BorrowRecords.AddRange(values);
            return _context.SaveChanges();
        }

        public BorrowRecord Select(int id)=> this.SelectDefault(id);

        public BorrowRecord Select(BorrowRecord e)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<BorrowRecord> Select(IEnumerable<int> ids)
        {
            throw new NotImplementedException();
        }

        public int Update(int id, BorrowRecord value)
        {
            var updateBorrowRecord = _context.BorrowRecords.Find(id); 
            if (updateBorrowRecord == null) return 0;
            _context.Entry(updateBorrowRecord).CurrentValues.SetValues(value);
            updateBorrowRecord.UpdateTime = DateTime.Now;
            return _context.SaveChanges();
        }

        public int Update(BorrowRecord value)
        {
            var updateBorrowRecord = _context.BorrowRecords.Find(value.RecordID);
            if (updateBorrowRecord == null) return 0;
            _context.Entry(updateBorrowRecord).CurrentValues.SetValues(value);
            updateBorrowRecord.UpdateTime = DateTime.Now;
            return _context.SaveChanges();
        }

        public int Update(IEnumerable<int> ids,IEnumerable<BorrowRecord> values)
        {
            var recordsToUpdate = from borrowRecord in _context.BorrowRecords
                where ids.Contains(borrowRecord.RecordID)
                select borrowRecord;
            foreach (var record in recordsToUpdate)
            {
                var newValue = values.FirstOrDefault(v => v.RecordID == record.RecordID);
                if (newValue != null)
                {
                    _context.Entry(record).CurrentValues.SetValues(newValue);
                    record.UpdateTime = DateTime.Now; 
                }
            }
            return _context.SaveChanges();
        }
    }
}
