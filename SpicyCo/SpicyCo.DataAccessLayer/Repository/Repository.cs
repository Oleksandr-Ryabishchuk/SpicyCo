using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpicyCo.DataAccessLayer.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private DbSet<T> dbSet;

        public Repository(DbSet<T> db)
        {
            dbSet = db;
        }

        public Repository(DbContext dataContext)
        {
            dbSet = dataContext.Set<T>();
        }

        public virtual async Task<IEnumerable<T>> GetAll()
        {
            return await dbSet.ToListAsync();
        }

        public virtual async Task<T> GetById(Guid id)
        {
            return await dbSet.FindAsync(id);
        }

        public virtual async Task Insert(T entity)
        {
            await dbSet.AddAsync(entity);
        }

        public virtual void Update(T entity)
        {
            dbSet.Update(entity);
        }

        public virtual async Task Delete(Guid id)
        {
            dbSet.Remove(await GetById(id));
        }

        public virtual async Task DeleteRange()
        {
            dbSet.RemoveRange(await GetAll());
        }
    }
}
