using InventoryManagementAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryManagementAPI.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly InventoryManagementContext _dbcontext;
        private readonly DbSet<T> _dbSet;

        public GenericRepository(InventoryManagementContext dbcontext)
        {
            _dbcontext = dbcontext;
            _dbSet = dbcontext.Set<T>();
        }

        public async Task Add(T entity)
        {
            await _dbSet.AddAsync(entity);
            await _dbcontext.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var entityToDelete = await _dbSet.FindAsync(id);
            if (entityToDelete != null)
            {
                _dbSet.Remove(entityToDelete);
                await _dbcontext.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T> GetById(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task Save()
        {
            await _dbcontext.SaveChangesAsync();
        }

        public async Task Update(T entity)
        {
            _dbSet.Attach(entity);
            _dbcontext.Entry(entity).State = EntityState.Modified;
            await _dbcontext.SaveChangesAsync();
        }
    }
}
