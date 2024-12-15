using Shared.Models;
using Shared.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Services.ManageImpl
{
    public class BorrowRecordService : IService<Borrowrecord>
    {
        private LibraryDbContext _context;
        public LibraryDbContext Context { get{return _context;} }
        public BorrowRecordService(LibraryDbContext context) => _context = context;
        public int Delete(int id)=> this.DeleteDefault(id);
        public int Delete(Borrowrecord value)
        {
            var recordToDelete = _context.BorrowRecords.FirstOrDefault(item=>item == value);
            if (recordToDelete == null) return 0;
            _context.BorrowRecords.Remove(recordToDelete);
            return _context.SaveChanges();
        }

        public int Delete(IEnumerable<int> ids)
        {
            var deleteRecords = _context.BorrowRecords.Where(item=>ids.Contains(item.Recordid));
            if (!deleteRecords.Any()) return 0;
            _context.BorrowRecords.RemoveRange(deleteRecords);
            return _context.SaveChanges();
        }

        public int Insert(IEnumerable<Borrowrecord> values)
        {
            return this.InsertDefault(values);
        }
        public int Insert(Borrowrecord values)
        {
            _context.BorrowRecords.Add(values);
            return _context.SaveChanges();
        }

        public Borrowrecord Select(int id)=> this.SelectDefault(id);

        public Borrowrecord Select(Borrowrecord e)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Borrowrecord> Select(IEnumerable<int> ids)
        {
            throw new NotImplementedException();
        }

        public int Update(int id, Borrowrecord value)
        {
            var updateBorrowRecord = _context.BorrowRecords.Find(id); 
            if (updateBorrowRecord == null) return 0;
            _context.Entry(updateBorrowRecord).CurrentValues.SetValues(value);
            updateBorrowRecord.Updatetime = DateTime.Now;
            return _context.SaveChanges();
        }

        public int Update(Borrowrecord value)
        {
            var updateBorrowRecord = _context.BorrowRecords.Find(value.Recordid);
            if (updateBorrowRecord == null) return 0;
            _context.Entry(updateBorrowRecord).CurrentValues.SetValues(value);
            updateBorrowRecord.Updatetime = DateTime.Now;
            return _context.SaveChanges();
        }

        public int Update(IEnumerable<int> ids,IEnumerable<Borrowrecord> values)
        {
            var recordsToUpdate = from borrowRecord in _context.BorrowRecords
                where ids.Contains(borrowRecord.Recordid)
                select borrowRecord;
            foreach (var record in recordsToUpdate)
            {
                var newValue = values.FirstOrDefault(v => v.Recordid == record.Recordid);
                if (newValue != null)
                {
                    _context.Entry(record).CurrentValues.SetValues(newValue);
                    record.Updatetime = DateTime.Now; 
                }
            }
            return _context.SaveChanges();
        }
    }
}
