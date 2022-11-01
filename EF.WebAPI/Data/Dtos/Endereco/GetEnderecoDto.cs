using EF.WebAPI.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace EF.WebAPI.Data.Dtos
{
    public class GetEnderecoDto
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "nome é obrigatorio")]
        public string Address { get; set; }

        [JsonIgnore]
        public virtual Cinema Cinema { get; set; }
    }
}
