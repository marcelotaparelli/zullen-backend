using System.ComponentModel.DataAnnotations;


namespace WebAPI.Models
{
    public class TodoModel
    {
        [Key]
        public int Id { get; set; }

        public string Task { get; set; }

        public bool Done { get; set; } = false;
    }
}
