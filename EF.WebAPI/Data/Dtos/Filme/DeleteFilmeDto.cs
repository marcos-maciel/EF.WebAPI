using System;
using System.ComponentModel.DataAnnotations;

namespace EF.WebAPI.Data.Dtos
{
    public class DeleteFilmeDto
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "nome é obrigatorio")]
        public string Nome { get; set; }
    }
}
