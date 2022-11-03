using System.ComponentModel.DataAnnotations;

namespace EF.WebAPI.Models
{
    public class User
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "nome é obrigatorio")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "senha é obrigatorio")]
        public string Senha { get; set; }
    }
}
