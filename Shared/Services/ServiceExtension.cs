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
        Mangage=0,
        /// <summary>
        /// 用户类型服务
        /// </summary>
        User=1
    }
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
                else if (role == ServiceRole.Mangage)
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

    }
}
