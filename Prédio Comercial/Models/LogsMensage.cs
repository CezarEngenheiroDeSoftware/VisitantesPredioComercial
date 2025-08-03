using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Prédio_Comercial.Models
{
    public class LogsMensage
    {
        [Key]
        public int Id { get; set; }
        public string? Menssage { get; set; }
        public DateTime? CreatedAt { get; set; } = DateTime.Now.Date;
        public int? UsuarioId { get; set; }
        [ForeignKey("UsuarioId")]
        public Usuarios? Usuarios { get; set; }
    }
}
