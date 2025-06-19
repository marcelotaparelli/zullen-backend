using Microsoft.EntityFrameworkCore;
using WebAPI.DataContext;
using WebAPI.Models;

namespace WebAPI.Service.TodoService
{
    public class TodoService : ITodoInterface
    {
        private readonly TodoDbContext _dbContext;

        public TodoService(TodoDbContext dbContext) 
        {
            _dbContext = dbContext;
        }

        public async Task<ServiceResponse<List<TodoModel>>> DeleteTodo(int id)
        {
            ServiceResponse<List<TodoModel>> serviceResponse = new();

            try
            {
                TodoModel? toDelete = _dbContext.Todos.FirstOrDefault(x => x.Id == id);

                if (toDelete == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Atividade não encontrada!";
                    serviceResponse.Sucesso = false;

                    return serviceResponse;
                }

                _dbContext.Todos.Remove(toDelete);
                await _dbContext.SaveChangesAsync();

                serviceResponse.Dados = _dbContext.Todos.ToList();
            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<TodoModel>> GetTodoById(int id)
        {
            ServiceResponse<TodoModel> serviceResponse = new();

            try
            {
                TodoModel? todo = _dbContext.Todos.FirstOrDefault(x => x.Id == id);

                if (todo == null) 
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Sucesso = true;
                    serviceResponse.Mensagem = "Atividade não encontrada!";
                }

                serviceResponse.Dados = todo;
                
            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<TodoModel>>> GetTodos()
        {
            ServiceResponse<List<TodoModel>> serviceResponse = new();
            try
            {
                serviceResponse.Dados = _dbContext.Todos.ToList();

                if (serviceResponse.Dados.Count == 0)
                {
                    serviceResponse.Mensagem = "Nenhum dado encontrado!";
                }        
   
            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }

            return serviceResponse;
            
        }

        public async Task<ServiceResponse<List<TodoModel>>> CreateTodo(TodoModel newTodo)
        {
            ServiceResponse<List<TodoModel>> serviceResponse = new();

            try
            {
                if (newTodo == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Sucesso = false;
                    serviceResponse.Mensagem = "Informar atividade a fazer";

                    return serviceResponse;
                }

                newTodo.Done = false;

                _dbContext.Add(newTodo);
                await _dbContext.SaveChangesAsync();

                serviceResponse.Dados = _dbContext.Todos.ToList(); ;
            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<TodoModel>>> UpdateTodo(TodoModel editedTodo)
        {
            ServiceResponse<List<TodoModel>> serviceResponse = new();

            try
            {
                TodoModel todo = _dbContext.Todos.AsNoTracking().FirstOrDefault(x => x.Id == editedTodo.Id);

                if (todo == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Atividade não encontrada!";
                    serviceResponse.Sucesso = false;

                    return serviceResponse;
                }

                _dbContext.Todos.Update(editedTodo);
                await _dbContext.SaveChangesAsync();

                serviceResponse.Dados = _dbContext.Todos.ToList();
            }
            catch(Exception ex) 
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }

            return serviceResponse;
        }
    }
}
