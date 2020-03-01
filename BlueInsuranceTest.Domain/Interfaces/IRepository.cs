using BlueInsuranceTest.Domain.Entities;
using BlueInsuranceTest.Domain.Utils;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BlueInsuranceTest.Domain.Interfaces
{
    public interface IRepository
    {
        Task Insert<T>(T obj) where T : BaseEntity;
        Task Update<T>(T obj) where T : BaseEntity;
        Task Delete<T>(T obj) where T : BaseEntity;
        Task<T> Get<T>(long id) where T : BaseEntity;
        Task<T> Get<T>(long id, params string[] includes) where T : BaseEntity;
        Task<IList<T>> Get<T>(Expression<Func<T, bool>> filter) where T : BaseEntity;
        Task<IList<T>> Get<T>(Expression<Func<T, bool>> filter, params string[] includes) where T : BaseEntity;
        Task<User> GetUser(long studentId);
        Task<PaginatedList<T>> GetPaginatedList<T>(Expression<Func<T, bool>> filter, int pageNumber, int pageSize) where T : BaseEntity;
        Task SaveChanges();
    }
}
