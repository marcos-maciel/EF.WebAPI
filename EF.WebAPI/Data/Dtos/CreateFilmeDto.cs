using System.ComponentModel.DataAnnotations;

namespace EF.WebAPI.Data.Dtos
{
    public class CreateFilmeDto
    {
        [Required(ErrorMessage = "nome é obrigatorio")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "diretor é obrigatorio"), StringLength(50)]
        public string Diretor { get; set; }

        [Range(10, 500)]
        public int Duracao { get; set; }
    }
}
