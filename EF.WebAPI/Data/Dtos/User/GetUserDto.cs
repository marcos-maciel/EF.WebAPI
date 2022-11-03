using System.ComponentModel.DataAnnotations;
using System;

namespace EF.WebAPI.Data.Dtos.User
{
    public class GetUserDto
    {
        [Required(ErrorMessage = "nome é obrigatorio")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "senha é obrigatorio")]
        public string Senha { get; set; }
    }
}
