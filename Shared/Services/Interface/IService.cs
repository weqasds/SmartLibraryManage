using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Services.Interface
{
    public interface IService<T> where T : class
    {
        //插入指定一批数据
        int Insert(LibraryDbContext entity,IEnumerable<T> e);
        //更新指定数据--三种重载
        int Update(LibraryDbContext entity,int id);
        int Update(LibraryDbContext entity, T e);
        int Update(LibraryDbContext entity,IEnumerable<int> ids);
        //给定元素删除--两种重载
        int Delete(LibraryDbContext entity,int id);
        int Delete(LibraryDbContext entity,T e);
        int Delete(LibraryDbContext entity,IEnumerable<int> ids);
        //查询数据--三种重载
        T Select(LibraryDbContext entity,int id);
        T Select(LibraryDbContext entity,T e);
        IEnumerable<T> Select(LibraryDbContext entity,IEnumerable<int> ids);


    }
}
