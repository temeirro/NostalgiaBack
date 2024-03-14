using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        internal DataBaseContext _context;
        internal DbSet<TEntity> dbSet;

        public Repository(DataBaseContext context)
        {
            _context = context;
            dbSet = context.Set<TEntity>();
        }

        public async Task<IEnumerable<TEntity>> GetAsync(
      Expression<Func<TEntity, bool>> filter = null,
      Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
      params string[] includeProperties)
        {
            IQueryable<TEntity> query = dbSet;
            await Task.Run
                (
                    () =>
                    {
                        if (filter != null)
                        {
                            query = query.Where(filter);
                        }

                        foreach (var includeProperty in includeProperties)
                        {
                            query = query.Include(includeProperty);
                        }
                    });
            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            else
            {
                return query.ToList();
            }
        }

        public async Task<TEntity> GetByIDAsync(object id)
        {
            return await dbSet.FindAsync(id);
        }

        public async Task InsertAsync(TEntity entity)
        {
            await dbSet.AddAsync(entity);
        }

        public async Task DeleteAsync(object id)
        {
            TEntity entityToDelete = await dbSet.FindAsync(id);
            await DeleteAsync(entityToDelete);
        }

        public async Task DeleteAsync(TEntity entityToDelete)
        {
            await Task.Run
                (
                    () =>
                    {
                        if (_context.Entry(entityToDelete).State == EntityState.Detached)
                        {
                            dbSet.Attach(entityToDelete);
                        }
                        dbSet.Remove(entityToDelete);
                    });
        }

        public async Task UpdateAsync(TEntity entityToUpdate)
        {
            await Task.Run
                (
                () =>
                {
                    dbSet.Attach(entityToUpdate);
                    _context.Entry(entityToUpdate).State = EntityState.Modified;
                });
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

      
    }
}
