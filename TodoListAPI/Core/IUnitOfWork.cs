namespace TodoListAPI.Core
{
    public interface IUnitOfWork
    {

        ITodoRepository Todos { get; }
        Task CompleteAsync();
    }
}
