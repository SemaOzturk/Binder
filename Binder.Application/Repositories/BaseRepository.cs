using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using Binder.Application.Entities.DbEntities;
using Microsoft.EntityFrameworkCore;
namespace Binder.Application.Repositories
{
    public class BaseRepository<T> : IRepository<T> where T : class, IDbEntity
    {
        private readonly DbContext _dbContext;
        private DbSet<T> Table => _dbContext.Set<T>();
        public BaseRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public T Add(T entity)
        {
            var addedEntity = Table.Add(entity);
            if (_dbContext.SaveChanges() > 0)
            {
                return addedEntity.Entity;
            }

            return null;
        }
        public int AddRange(IEnumerable<T> entities)
        {
            Table.AddRange(entities);
            return _dbContext.SaveChanges();
        }
        public bool Delete(T entity)
        {
            Table.Remove(entity);
            return _dbContext.SaveChanges() > 0;
        }
        public bool Update(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            return _dbContext.SaveChanges() > 0;
        }
        public IQueryable<T> GetAll()
        {
            return Table;
        }
        public T GetById(int id)
        {
            return Table.Find(id);
        }
    }
}
