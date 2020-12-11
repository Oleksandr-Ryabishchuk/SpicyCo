using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpicyCo.DataAccessLayer.Repository
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();

        Task<T> GetById(Guid id);

        Task Insert(T entity);

        void Update(T entity);

        Task Delete(Guid Id);

        Task DeleteRange();
    }
}
