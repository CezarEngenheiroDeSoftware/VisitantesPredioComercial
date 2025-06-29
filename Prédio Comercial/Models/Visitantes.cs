using System.ComponentModel.DataAnnotations;

namespace Prédio_Comercial.Models
{
    public class Visitantes
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string? Name { get; set; }
        [StringLength(14)]
        public string? Documento { get; set; }
        [Required]
        public string? Empresa { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime Dataentrada { get; set; } = DateTime.Now;
        [DataType(DataType.DateTime)]
        public DateTime? DataSaida { get; set; } = DateTime.Now;
        public string? MotivoVisita { get; set; } = "";
        public string? VisitandoQuem { get; set; } = "";
        public Proprietarios? proprietarios { get; set; }
        public int? ProprietariosId { get; set; }

    }
}
