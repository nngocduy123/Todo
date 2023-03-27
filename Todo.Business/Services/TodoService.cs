using Todo.Business.Constracts;
using Todo.Business.Models.Todo;
using Todo.Data.Constract;
using Todo.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Todo.Common.Enums;

namespace Todo.Business.Services
{
    public class TodoService : ITodoService
    {
        private IRepository<TodoItem> _todoRepository;

        public TodoService(IRepository<TodoItem> todoRepository)
        {
            _todoRepository = todoRepository;
        }

        public async Task<TodoItem> Create(TodoItem todo)
        {
            var result = await _todoRepository.Add(todo);
            await _todoRepository.SaveChanges();

            return result;
        }

        public async Task Delete(int id)
        {
            await _todoRepository.Delete(id);
            await _todoRepository.SaveChanges();
        }

        public async Task<List<TodoModel>> Get()
        {
            var todos = await _todoRepository.Query().Select(x => new 
            {
                x.Id,
                x.Title,
                x.Description,
                x.DueDate,
                x.DayConstraint,
                x.TodoStatus
            }).ToListAsync();

            var result = todos.Select(x => new TodoModel
            {
                Id = x.Id,
                Title = x.Title,
                Description = x.Description,
                DueDate = x.DueDate,
                DayConstraint = x.DayConstraint,
                TodoStatus = x.TodoStatus.ToDescription()
            }).ToList();

            return result;
        }

        public async Task<TodoItem> GetById(int id)
        {
            return await _todoRepository.Query(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task Update(TodoItem todoItem)
        {
            await _todoRepository.Update(todoItem);
            await _todoRepository.SaveChanges();
        }
    }
}

