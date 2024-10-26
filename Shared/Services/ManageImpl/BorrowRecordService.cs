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
        public int Delete(LibraryDbContext entity, int id)
        {
            throw new NotImplementedException();
        }

        public int Delete(LibraryDbContext entity, BorrowRecord e)
        {
            throw new NotImplementedException();
        }

        public int Delete(LibraryDbContext entity, IEnumerable<int> ids)
        {
            throw new NotImplementedException();
        }

        public int Insert(LibraryDbContext entity, IEnumerable<BorrowRecord> e)
        {
            throw new NotImplementedException();
        }

        public BorrowRecord Select(LibraryDbContext entity, int id)
        {
            throw new NotImplementedException();
        }

        public BorrowRecord Select(LibraryDbContext entity, BorrowRecord e)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<BorrowRecord> Select(LibraryDbContext entity, IEnumerable<int> ids)
        {
            throw new NotImplementedException();
        }

        public int Update(LibraryDbContext entity, int id)
        {
            throw new NotImplementedException();
        }

        public int Update(LibraryDbContext entity, BorrowRecord e)
        {
            throw new NotImplementedException();
        }

        public int Update(LibraryDbContext entity, IEnumerable<int> ids)
        {
            throw new NotImplementedException();
        }
    }
}
