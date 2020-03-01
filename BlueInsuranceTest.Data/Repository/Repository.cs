using BlueInsuranceTest.Data.Context;
using BlueInsuranceTest.Domain.Entities;
using BlueInsuranceTest.Domain.Interfaces;
using BlueInsuranceTest.Domain.Utils;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BlueInsuranceTest.Data.Repository
{
    public class Repository : IRepository
    {
        BlueInsuranceTestContext _context { get; }

        public Repository(BlueInsuranceTestContext context)
        {
            _context = context;
        }

        public async Task Delete<T>(T obj) where T : BaseEntity
        {
            obj.DeletedDate = DateTime.Now;
            await Update(obj);            
        }

        public async Task<T> Get<T>(long id) where T : BaseEntity => (await Get<T>(x => x.Id == id)).FirstOrDefault();        
        public async Task<T> Get<T>(long id, params string[] includes) where T : BaseEntity => (await Get<T>(x => x.Id == id, includes)).FirstOrDefault();
        public async Task<IList<T>> Get<T>(Expression<Func<T, bool>> filter) where T : BaseEntity => await Get<T>(filter, "");
        
        public async Task<IList<T>> Get<T>(Expression<Func<T, bool>> filter, params string[] includes) where T : BaseEntity
        {
            var query = _context.Set<T>().Where(filter).Where(x => !x.DeletedDate.HasValue).AsQueryable();

            foreach (var item in includes)
            {
                if(!string.IsNullOrEmpty(item))
                    query = query.Include(item).AsQueryable();
            }

            return await query.ToListAsync();
        }

        public async Task Insert<T>(T obj) where T : BaseEntity
        {
            obj.CreatedDate = DateTime.Now;
            await _context.Set<T>().AddAsync(obj);
        }
        public async Task SaveChanges() => await _context.SaveChangesAsync();

        public async Task Update<T>(T obj) where T : BaseEntity
        {
            T objLocal = await Get<T>(obj.Id);

            foreach (var p in objLocal.GetType().GetProperties().Where(x => !x.GetGetMethod().GetParameters().Any() &&
                x.Name != "CreatedDate" && x.Name != "DeletedDate" && x.Name != "IsDeleted"))
            {
                objLocal
                    .GetType()
                    .GetProperty(p.Name)
                    .SetValue(objLocal, obj.GetType().GetProperty(p.Name).GetValue(obj));
            }

            objLocal.UpdatedDate = DateTime.Now;
            _context.Entry(objLocal).State = EntityState.Modified;
        }

        public async Task<User> GetUser(long studentId)
        {
            return await _context.Users.Where(x => x.StudentId == studentId).FirstOrDefaultAsync();
        }

        public async Task<PaginatedList<T>> GetPaginatedList<T>(Expression<Func<T, bool>> filter, int pageNumber, int pageSize) where T : BaseEntity
        {
            var query = _context.Set<T>().Where(filter).Where(x => !x.DeletedDate.HasValue);
            return await PaginatedList<T>.CreateAsync(query.AsNoTracking(), pageNumber, pageSize);
        }
    }
}
