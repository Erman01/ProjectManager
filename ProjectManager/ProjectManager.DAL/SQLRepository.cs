using ProjectManager.Core.Contracts;
using ProjectManager.Core.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManager.DAL
{
    public class SQLRepository<T> : IRepository<T> where T : BaseEntity
    {
        internal ProjectManagerDbContext _dbContext;
        internal DbSet<T> _dbSet;
        public SQLRepository(ProjectManagerDbContext DbContext)
        {
            _dbContext = DbContext;
            _dbSet = _dbContext.Set<T>();
        }
        public IQueryable<T> Collection()
        {
            return _dbSet;
        }

        public void Commit()
        {
            _dbContext.SaveChanges();
        }

        public void Delete(int Id)
        {
            var t = _dbSet.Find(Id);
            if (_dbContext.Entry(t).State == EntityState.Detached)
                _dbSet.Attach(t);
            _dbSet.Remove(t);
        }

        public T GetbyId(int Id)
        {
            return _dbSet.Find(Id);
        }

        public void Insert(T TEntity)
        {
            _dbSet.Add(TEntity);
        }

        public void Update(T TEntity)
        {
            _dbSet.Attach(TEntity);
            _dbContext.Entry(TEntity).State = EntityState.Modified;
        }
    }
}
