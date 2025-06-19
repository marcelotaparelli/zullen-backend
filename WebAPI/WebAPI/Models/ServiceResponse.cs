namespace WebAPI.Models
{
    public class ServiceResponse<T>
    {

        public T? Dados { get; set; }

        public string Mensagem { get; set; } = String.Empty;

        public bool Sucesso { get; set; } = true;

    }
}
