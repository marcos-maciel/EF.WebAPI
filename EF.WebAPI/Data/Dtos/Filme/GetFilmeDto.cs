using System;
using System.ComponentModel.DataAnnotations;

namespace EF.WebAPI.Data.Dtos
{
    public class GetFilmeDto
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "nome é obrigatorio")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "diretor é obrigatorio"), StringLength(50)]
        public string Diretor { get; set; }

        [Range(10, 500)]
        public int Duracao { get; set; }

        public DateTime HoraConsulta { get; set; }
    }
}
