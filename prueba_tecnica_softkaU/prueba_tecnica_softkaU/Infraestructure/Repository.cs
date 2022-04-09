using Microsoft.EntityFrameworkCore;
using prueba_tecnica_softkaU.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace prueba_tecnica_softkaU.Infraestructure
{
    public class Repository<T> : IRepository<T> where T : class, IEntity
    {
        private readonly DataContext _context;

        public Repository(DataContext context)
        {
            context.Database.EnsureCreated();
            _context = context;
        }

        private IQueryable<T> AddFilter(Expression<Func<T, bool>> filtro = null)
        {
            IQueryable<T> consulta = _context.Set<T>();
            if (filtro != null)
            {
                consulta = consulta.Where(filtro);
            }
            return consulta;
        }

        private async Task<IEnumerable<T>> GetAsync(IQueryable<T> consulta)
        {
            return await consulta.AsNoTracking().ToListAsync().ConfigureAwait(false);
        }

        public async Task<IEnumerable<T>> GetAsync(Expression<Func<T, bool>> filtro, IEnumerable<string> incluciones = null)
        {
            IQueryable<T> query = AddFilter(filtro);
            if (incluciones != null)
            {
                foreach (var incude in incluciones)
                {
                    query = query.Include(incude);
                }
            }
            var resultado = await GetAsync(query).ConfigureAwait(false);
            return resultado;
        }



        public async Task<IEnumerable<T>> GetByIdsync(int Id)
        {
            IQueryable<T> query = this._context.Set<T>();
            var result = await query.AsNoTracking().ToListAsync();
            return result;
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            IQueryable<T> query = this._context.Set<T>();
            var result = await query.AsNoTracking().ToListAsync();
            return result;
        }

        public async Task<T> InsertAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity).ConfigureAwait(false);
            await CommitAsync().ConfigureAwait(false);
            return entity;
        }

        public async Task<bool> CommitAsync()
        {
            _context.ChangeTracker.DetectChanges();

            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdateAsync(T entidad)
        {
            _context.Set<T>().Update(entidad);
            return await CommitAsync().ConfigureAwait(false);
        }
    }
}
