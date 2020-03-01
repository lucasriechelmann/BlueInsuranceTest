using BlueInsuranceTest.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BlueInsuranceTest.Domain.Interfaces
{
    public interface IBaseService<T> where T : BaseEntity
    {
        Task<T> Post(T obj);
        Task<T> Put(T obj);
        Task Delete(long id);
        Task<T> Get(long id);
        Task<T> Get(long id, params string[] includes);
        Task<IList<T>> Get(Expression<Func<T, bool>> filter);
        Task<IList<T>> Get(Expression<Func<T, bool>> filter, params string[] includes);
    }
}
