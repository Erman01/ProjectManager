using ProjectManager.Core.Contracts;
using ProjectManager.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManager.DAL
{
    public class SQLRepository<T> : IRepository<T> where T : BaseEntity
    {
        public IQueryable<T> Collection()
        {
            throw new NotImplementedException();
        }

        public void Commit()
        {
            throw new NotImplementedException();
        }

        public void Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public T GetbyId(int Id)
        {
            throw new NotImplementedException();
        }

        public void Insert(T TEntity)
        {
            throw new NotImplementedException();
        }

        public void Update(T TEntity)
        {
            throw new NotImplementedException();
        }
    }
}
