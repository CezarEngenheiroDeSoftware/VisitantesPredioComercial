using System.ComponentModel.DataAnnotations;

namespace Prédio_Comercial.Models
{
    public class Visitantes
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        [MaxLength(14)]
        public string? Documento { get; set; }
        [Required]
        public string? Empresa { get; set; }
        [Required]
        public DateTime Dataentrada { get; set; } = DateTime.Now;
        public DateTime DataSaida { get; set; } = DateTime.Now;
        public string? MotivoVisita { get; set; } = "";
        public string? VisitandoQuem { get; set; } = "";

    }
}
