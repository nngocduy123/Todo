using Todo.Business.Constracts.Base;
using Todo.Business.Models.Todo;
using Todo.Data.Entities;

namespace Todo.Business.Constracts
{
    public interface ITodoService : IPerRequest
    {
        Task<TodoItem> Create(TodoItem todoModel);

		Task<List<TodoModel>> Get();

		Task<TodoItem> GetById(int id);

		Task Update(TodoItem todoItem);

		Task Delete(int id);
	}
}

