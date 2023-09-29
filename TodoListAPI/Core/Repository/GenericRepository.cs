using Microsoft.EntityFrameworkCore;
using TodoListAPI.Data;

namespace TodoListAPI.Core.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected ApiDbContext _context;
        internal DbSet<T> _dbSet;
        protected readonly ILogger _logger;
        public GenericRepository(ApiDbContext context, ILogger logger)
        {
            _context = context;
            _logger = logger;
            this._dbSet = context.Set<T>();
        }
        public async Task<bool> Add(T entity)
        {
            await _dbSet.AddAsync(entity);
            return true;
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
           return await _dbSet.AsNoTracking().ToListAsync();
           
        }

        public virtual async Task<T?> GetById(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public Task<bool> Update(T entity)
        {
            _dbSet.Update(entity);
            return Task.FromResult(true);
        }

        public Task<bool> Delete(T entity)
        {
            _dbSet.Remove(entity);
            return Task.FromResult(true);
        }
    }
}
