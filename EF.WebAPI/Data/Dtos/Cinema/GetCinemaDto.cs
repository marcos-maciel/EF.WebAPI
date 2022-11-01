using EF.WebAPI.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace EF.WebAPI.Data.Dtos
{
    public class GetCinemaDto
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "nome é obrigatorio")]
        public string Nome { get; set; }

        public virtual Endereco Endereco { get; set; }

        public string EnderecoId { get; set; }

        public DateTime HoraConsulta { get; set; }


    }
}
