using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Binder.Application.Entities.DbEntities;

namespace Binder.Application.Repositories
{
    public interface IRepository<T> where T : IDbEntity
    {
        T Add(T entity);
        int AddRange(IEnumerable<T> entities);
        bool Delete(T entity);
        bool Update(T entity);
        IQueryable<T> GetAll();
        T GetById(int id);
    }
}
