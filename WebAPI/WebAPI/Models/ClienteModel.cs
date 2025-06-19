using System.ComponentModel.DataAnnotations;
using WebAPI.Enums;

namespace WebAPI.Models
{
    public class ClienteModel
    {
        [Key]
        public int Id { get; set; }

        public string? NomePai { get; set; }

        public string? NomeMae { get; set; }

        public string? Crianca { get; set; }

        public string? Contato { get; set; }

        public bool Ativo { get; set; }

        public TipoEnum Tipo { get; set; }

        public List<string>? Dias { get; set; }

        public List<DateTime>? Datas { get; set; }

        public string? Mensalidade { get; set; }

        public bool? Pago { get; set; } = false;

        public TurnoEnum Turno { get; set; }

        public DateTime DataDaMatricula { get; set; } = DateTime.Now.ToLocalTime();

        public DateTime DataDaAlteracao { get; set; } = DateTime.Now.ToLocalTime();

    }
}
