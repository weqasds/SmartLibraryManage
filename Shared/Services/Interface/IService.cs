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
        int Insert(IEnumerable<T> e);
        //更新指定数据--三种重载
        int Update(int id);
        int Update( T e);
        int Update(IEnumerable<int> ids);
        //给定元素删除--两种重载
        int Delete(int id);
        int Delete(T e);
        int Delete(IEnumerable<int> ids);
        //查询数据--三种重载
        T Select(int id);
        T Select(T e);
        IEnumerable<T> Select(IEnumerable<int> ids);


    }
}
