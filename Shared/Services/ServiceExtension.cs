using Microsoft.Extensions.DependencyInjection;
using Shared.Models;
using Shared.Services.Interface;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Services
{
    public enum ServiceType
    {
        /// <summary>
        /// 用户
        /// </summary>
        UserService = 0,
        /// <summary>
        /// 图书
        /// </summary>
        BookService = 1,
        /// <summary>
        /// 借阅
        /// </summary>
        BorrowRecordService = 2,
        /// <summary>
        /// 罚款
        /// </summary>
        FineService = 3,
        /// <summary>
        /// 日志
        /// </summary>
        LoggingService = 4
    }
    public enum ServiceRole
    {
        /// <summary>
        /// 管理类型服务
        /// </summary>
        Manage=0,
        /// <summary>
        /// 用户类型服务
        /// </summary>
        User=1
    }
    /// <summary>
    /// 服务拓展类
    /// </summary>
    public static class ServiceExtension
    {
        public static IServiceCollection GetServices(this IServiceCollection servicesCollection, ServiceRole role, ServiceType[] services)
        {
            try
            {
                if (servicesCollection == null) throw new ArgumentNullException(nameof(servicesCollection));
                if (role == ServiceRole.User)
                {
                    foreach (var service in services)
                    {
                        switch (service)
                        {
                            case ServiceType.BookService:
                                servicesCollection.AddSingleton<IService<Book>, UserImpl.BookService>();
                                break;
                            case ServiceType.BorrowRecordService:
                                servicesCollection.AddSingleton<IService<BorrowRecord>, UserImpl.BorrowRecordService>();
                                break;
                            case ServiceType.FineService:
                                servicesCollection.AddSingleton<IService<Fine>, UserImpl.FineService>();
                                break;
                            case ServiceType.UserService:
                                servicesCollection.AddSingleton<IService<User>, UserImpl.UserService>();
                                break;
                        }
                    }
                    return servicesCollection;
                }
                else if (role == ServiceRole.Manage)
                {
                    foreach (var service in services)
                    {
                        switch (service)
                        {
                            case ServiceType.BookService:
                                servicesCollection.AddSingleton<IService<Book>, UserImpl.BookService>();
                                break;
                            case ServiceType.BorrowRecordService:
                                servicesCollection.AddSingleton<IService<BorrowRecord>, UserImpl.BorrowRecordService>();
                                break;
                            case ServiceType.FineService:
                                servicesCollection.AddSingleton<IService<Fine>, UserImpl.FineService>();
                                break;
                            case ServiceType.UserService:
                                servicesCollection.AddSingleton<IService<User>, UserImpl.UserService>();
                                break;
                            case ServiceType.LoggingService:
                                break;
                        }

                    }
                    return servicesCollection;
                }
                else {
                    throw new ArgumentException(nameof(role));
                }
            }
            catch(Exception e) {
                Debug.Write(e.ToString());
                foreach (var service in services)
                {
                    switch (service)
                    {
                        case ServiceType.BookService:
                            servicesCollection.AddSingleton<IService<Book>, UserImpl.BookService>();
                            break;
                        case ServiceType.BorrowRecordService:
                            servicesCollection.AddSingleton<IService<BorrowRecord>, UserImpl.BorrowRecordService>();
                            break;
                        case ServiceType.FineService:
                            servicesCollection.AddSingleton<IService<Fine>, UserImpl.FineService>();
                            break;
                        case ServiceType.UserService:
                            servicesCollection.AddSingleton<IService<User>, UserImpl.UserService>();
                            break;
                    }
                }
                return servicesCollection;
            }
        }
        /// <summary>
        /// 插入数据的默认实现
        /// </summary>
        /// <typeparam name="T">泛型参数T要求为类</typeparam>
        /// <param name="service">需要调用的服务实现类</param>
        /// <param name="values">将要插入的数据</param>
        /// <returns></returns>
        public static int InsertDefault<T>(this IService<T> service,IEnumerable<T> values)where T : class
        {
            if(!values.Any())return 0;
            service.Context.Set<T>().AddRange(values);
            return service.Context.SaveChanges();
        }
        /// <summary>
        /// 查询数据的默认实现
        /// </summary>
        /// <typeparam name="T">泛型参数T要求为类</typeparam>
        /// <param name="service">服务实现类</param>
        /// <param name="id">将要查询的数据(键值)</param>
        /// <returns>T类型</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static T SelectDefault<T>(this IService<T> service,int id)where T : class
        {
            if(service == null) throw new ArgumentNullException(nameof(service));
            var t=service.Context.Set<T>().Find(id);
            return t ?? default(T);
        }
        /// <summary>
        /// 删除数据的默认实现
        /// </summary>
        /// <typeparam name="T">泛型参数T要求为类</typeparam>
        /// <param name="service">服务实现类</param>
        /// <param name="id">将要查询的数据(键值)</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static int DeleteDefault<T>(this IService<T> service,int id)where T:class
        {
            if (service == null) throw new ArgumentNullException( nameof(service));
            var t = service.Context.Set<T>().Find(id);
            if (t == null) return 0;
            service.Context.Set<T>().Remove(t);
            return service.Context.SaveChanges();
        }
        
    }
}
