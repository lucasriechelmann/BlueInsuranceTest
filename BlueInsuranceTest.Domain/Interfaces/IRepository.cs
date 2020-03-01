using BlueInsuranceTest.Domain.Entities;
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
        Task SaveChanges();
    }
}
