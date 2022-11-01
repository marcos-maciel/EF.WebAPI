using System.ComponentModel.DataAnnotations;

namespace EF.WebAPI.Models
{
    public class Cinema
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "nome é obrigatorio")]
        public string Nome { get; set; }

        [Required]
        public virtual Endereco Endereco { get; set; }

        [Required]
        public int EnderecoId { get; set; }
    }
}
