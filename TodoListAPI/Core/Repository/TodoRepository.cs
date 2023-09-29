using Microsoft.EntityFrameworkCore;
using TodoListAPI.Data;
using TodoListAPI.Model;

namespace TodoListAPI.Core.Repository
{
    public class TodoRepository : GenericRepository<Todo>, ITodoRepository
    {
        public TodoRepository(ApiDbContext context, ILogger logger) : base(context, logger)
        {

          
        }

        public override async Task<Todo?> GetById(int id)
        {
            try
            {
                return await _context.Todo.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
            }catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw;
            }

            
        }
    }
}
