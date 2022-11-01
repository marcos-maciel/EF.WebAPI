using System.ComponentModel.DataAnnotations;

namespace EF.WebAPI.Data.Dtos
{
    public class CreateCinemaDto
    {
        [Required(ErrorMessage = "nome é obrigatorio")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "enderecoId é obrigatorio")]
        public int EnderecoId { get; set; }

    }
}
