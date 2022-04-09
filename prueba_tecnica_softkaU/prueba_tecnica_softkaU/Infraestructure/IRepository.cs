using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace prueba_tecnica_softkaU.Infraestructure
{
    public interface IRepository<T> where T :class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> InsertAsync(T entity);
        Task<IEnumerable<T>> GetAsync(Expression<Func<T, bool>> filtro, IEnumerable<string> incluciones = null);
        Task<bool> UpdateAsync(T entidad);
    }
}
