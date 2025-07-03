using Newtonsoft.Json.Serialization;
using System.ComponentModel.DataAnnotations;

namespace Prédio_Comercial.Models
{
    public class UsuariosDTO
    {
        [Required]
        [StringLength(50, MinimumLength = 8, ErrorMessage = "O Nome deve conter no mínimo 8 caracteres")]
        public string? Login { get; set; } = "";
        [Required]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "A senha deve conter no mínio 8 caracteres")]
        public string? Password { get; set; }
        [Required]
        public bool? Admin { get; set; } = false;
    }
}
