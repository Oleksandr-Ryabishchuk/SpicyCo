using SpicyCo.DataAccessLayer.Data;
using SpicyCo.DataAccessLayer.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpicyCo.DataAccessLayer.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private bool disposed;
        private readonly DataContext _dataContext;
        private readonly Dictionary<Type, object> repositories;
        public UnitOfWork(DataContext dataContext)
        {
            _dataContext = dataContext;
            repositories = new Dictionary<Type, object>();
        }

        //~UnitOfWork()
        //{
        //    Dispose();
        //}

        public async void Dispose()
        {
            await Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual async Task Dispose(bool disposing)
        {
            if (!disposed)
                return;
            if (disposing)
            {
                await _dataContext.DisposeAsync();
            }
            disposed = true;
        }

        public IRepository<TEntity> GetRepository<TEntity>() where TEntity : class
        {
            if (repositories.ContainsKey(typeof(TEntity)))
                return repositories[typeof(TEntity)] as IRepository<TEntity>;

            var repository = new Repository<TEntity>(_dataContext);
            repositories.Add(typeof(TEntity), repository);
            return repository;
        }

        public async Task SaveAsync()
        {
            await _dataContext.SaveChangesAsync();
        }
    }
}
