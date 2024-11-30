using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Services.Interface
{
    public interface IService<T> where T : class
    {
        public LibraryDbContext Context { get; }

        //插入指定一批数据
        int Insert(IEnumerable<T> e);
        //更新指定数据--三种重载 通过id 通过对象 通过一组id更新一系列
        int Update(int id,T value);
        int Update(T e);
        int Update(IEnumerable<int> ids,IEnumerable<T> values);
        //给定元素删除--两种重载 通过id 通过对象 通过一组id删除一系列
        int Delete(int id);
        int Delete(T e);
        int Delete(IEnumerable<int> ids);
        //查询数据--三种重载 通过id 通过对象 通过一组id返回一组数据
        T Select(int id);
        T Select(T e);
        IEnumerable<T> Select(IEnumerable<int> ids);


    }
}
