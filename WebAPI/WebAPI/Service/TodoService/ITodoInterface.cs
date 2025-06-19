using WebAPI.Models;

namespace WebAPI.Service.TodoService
{
    public interface ITodoInterface
    {
        Task<ServiceResponse<List<TodoModel>>> GetTodos();

        Task<ServiceResponse<List<TodoModel>>> CreateTodo(TodoModel newTodo);

        Task<ServiceResponse<TodoModel>> GetTodoById(int id);

        Task<ServiceResponse<List<TodoModel>>> UpdateTodo(TodoModel editedTodo);

        Task<ServiceResponse<List<TodoModel>>> DeleteTodo(int id);

    }
}
