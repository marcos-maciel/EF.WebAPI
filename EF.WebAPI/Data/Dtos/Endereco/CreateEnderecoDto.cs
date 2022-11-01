using System.ComponentModel.DataAnnotations;

namespace EF.WebAPI.Data.Dtos
{
    public class CreateEnderecoDto
    {
        [Required(ErrorMessage = "nome é obrigatorio")]
        public string Address { get; set; }
    }
}
