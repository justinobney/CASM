using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Jobney.Core.Domain;
using Jobney.Core.Domain.Interfaces;

namespace Jobney.Casm.Data
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity
    {
        private readonly IDbContext _context;
        private readonly IDbSet<TEntity> _dbSet;

        public Repository(IDbContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }

        public IQueryable<TEntity> Query()
        {
            return _dbSet;
        }

        public IEnumerable<TEntity> GetAll()
        {
            return Query().ToList();
        }

        public TEntity GetById(int id)
        {
            return Query().FirstOrDefault(m => m.Id == id);
        }

        public void InsertOrUpdate(TEntity entity)
        {
            if (entity.IsNew())
                _dbSet.Add(entity);
            else
                _context.Entry(entity).State = EntityState.Modified;
        }

        public void Remove(TEntity entity)
        {
            _dbSet.Remove(entity);
        }
    }
}
