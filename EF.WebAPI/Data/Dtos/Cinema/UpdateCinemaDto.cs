using System.ComponentModel.DataAnnotations;

namespace EF.WebAPI.Data.Dtos
{
    public class UpdateCinemaDto
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "nome é obrigatorio")]
        public string Nome { get; set; }

        [Required]
        public int EnderecoId { get; set; }
    }
}
