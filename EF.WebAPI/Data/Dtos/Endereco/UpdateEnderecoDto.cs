using System.ComponentModel.DataAnnotations;

namespace EF.WebAPI.Data.Dtos
{
    public class UpdateEnderecoDto
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "endereço é obrigatorio")]
        public string Address { get; set; }
    }
}
