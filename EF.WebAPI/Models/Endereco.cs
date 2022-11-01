using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace EF.WebAPI.Models
{
    public class Endereco
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "endereço é obrigatorio")]
        public string Address { get; set; }

        [JsonIgnore]
        public virtual Cinema Cinema { get; set; }
    }
}
