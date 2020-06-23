using ProjectManager.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManager.Core.Contracts
{
    public interface IRepository<T> where T:BaseEntity
    {
        IQueryable<T> Collection();
        T GetbyId(int Id);
        void Commit();
        void Insert(T TEntity);
        void Update(T TEntity);
        void Delete(int Id);

    }
}
