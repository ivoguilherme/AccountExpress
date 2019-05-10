using AccountExpress.Data;
using AccountExpress.Interfaces;
using AccountExpress.Models.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AccountExpress.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity
    {
        private readonly ApplicationDbContext _dbContext;

        public Repository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public TEntity Add(TEntity obj)
        {
            _dbContext.Set<TEntity>().Add(obj);
            _dbContext.SaveChanges();
            return obj;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _dbContext.Set<TEntity>().ToArray();
        }

        public TEntity GetById(int Id)
        {
            return _dbContext.Set<TEntity>().AsNoTracking().FirstOrDefault(obj => obj.Id == Id);
        }

        public void Remove(TEntity obj)
        {
            _dbContext.Set<TEntity>().Remove(obj);
            _dbContext.SaveChanges();
        }

        public IEnumerable<TEntity> Search(System.Linq.Expressions.Expression<Func<TEntity, bool>> predicate)
        {
            return _dbContext.Set<TEntity>().Where(predicate).ToArray();
        }

        public TEntity Update(TEntity obj)
        {
            _dbContext.Entry(obj).State = EntityState.Modified;
            _dbContext.SaveChanges();
            return obj;
        }
    }
}
