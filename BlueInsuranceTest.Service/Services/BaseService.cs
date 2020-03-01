using BlueInsuranceTest.Domain.Entities;
using BlueInsuranceTest.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BlueInsuranceTest.Service.Services
{
    public abstract class BaseService<T> : IBaseService<T> where T : BaseEntity
    {
        protected IRepository _repository { get; }

        public BaseService(IRepository repository) => _repository = repository;

        public async Task Delete(long id)
        {
            if (id <= 0)
                throw new ArgumentException("Id incorrect");

            var obj = await _repository.Get<T>(id);

            if (obj == null)
                throw new Exception($"{nameof(T)} not found");

            await _repository.Delete(obj);
            await _repository.SaveChanges();
        }

        public async Task<T> Get(long id) => await Get(id, "");

        public async Task<T> Get(long id, params string[] includes)
        {
            if (id <= 0)
                throw new ArgumentException("Id incorrect");

            var obj = await _repository.Get<T>(id, includes);

            if (obj == null)
                throw new Exception($"{nameof(T)} not found");

            return obj;
        }

        public async Task<IList<T>> Get(Expression<Func<T, bool>> filter) => await _repository.Get(filter);

        public async Task<IList<T>> Get(Expression<Func<T, bool>> filter, params string[] includes) => await _repository.Get(filter, includes);

        public async Task<T> Post(T obj)
        {
            if (obj == null)
                throw new ArgumentException();

            await _repository.Insert(obj);
            await _repository.SaveChanges();
            return obj;
        }

        public async Task<T> Put(T obj)
        {
            if (obj == null)
                throw new ArgumentException();

            await _repository.Update(obj);
            await _repository.SaveChanges();
            return obj;
        }
    }
}
