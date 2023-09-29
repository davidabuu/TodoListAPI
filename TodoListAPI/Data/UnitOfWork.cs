using TodoListAPI.Core;
using TodoListAPI.Core.Repository;

namespace TodoListAPI.Data
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly ApiDbContext _context;
        
        public ITodoRepository Todos { get; private set; }

    
        public UnitOfWork(ApiDbContext context, ILoggerFactory loggerFactory)
        {
            _context = context;
            var _logger = loggerFactory.CreateLogger("logs");


            Todos = new TodoRepository(_context, _logger);
            
        }

        public ITodoRepository Todo()
        {
            throw new NotImplementedException();
        }
        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
             _context.Dispose();
        }
    }
}
