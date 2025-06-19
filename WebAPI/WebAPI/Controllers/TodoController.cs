using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Models;
using WebAPI.Service.TodoService;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly ITodoInterface _todoInterface;
        public TodoController(ITodoInterface todoInterface)
        {
            _todoInterface = todoInterface;
        }

        [HttpGet]

        public async Task<ActionResult<ServiceResponse<List<TodoModel>>>> GetTodos()
        {
            return Ok(await _todoInterface.GetTodos());
        }


        [HttpGet("{id}")]

        public async Task<ActionResult<ServiceResponse<TodoModel>>> GetTodoById(int id)
        {
            ServiceResponse<TodoModel> serviceResponse = await _todoInterface.GetTodoById(id);

            return Ok(serviceResponse);
        }


        [HttpPost]

        public async Task<ActionResult<ServiceResponse<List<TodoModel>>>> CreateTodo(TodoModel newTodo)
        {
            return Ok(await _todoInterface.CreateTodo(newTodo));
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<List<ClienteModel>>>> UpdateTodo(TodoModel editedTodo)
        {
            ServiceResponse<List<TodoModel>> serviceResponse = await _todoInterface.UpdateTodo(editedTodo);

            return Ok(serviceResponse);
        }

        [HttpDelete]

        public async Task<ActionResult<ServiceResponse<List<ClienteModel>>>> DeleteTodo(int id)
        {
            ServiceResponse<List<TodoModel>> serviceResponse = await _todoInterface.DeleteTodo(id);

            return Ok(serviceResponse);
        }
    }
}
