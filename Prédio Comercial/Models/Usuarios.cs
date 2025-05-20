using System.ComponentModel.DataAnnotations;

namespace Prédio_Comercial.Models
{
    public class Usuarios
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Login { get; set; } = "";
        [Required]
        public string Password { get; set; } = "";
        public bool Admin { get; set; } = false;
    }
}
