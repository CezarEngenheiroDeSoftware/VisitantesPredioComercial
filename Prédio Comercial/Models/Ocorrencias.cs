using System.ComponentModel.DataAnnotations;

namespace Prédio_Comercial.Models
{
    public class Ocorrencias
    {
        public int Id { get; set; }
        [Required]
        public string? NomeOcorrencia { get; set; } = "";
        [Required]
        [StringLength(500)]
        public string? Descricao { get; set; }
        public bool Ativa { get; set; } = false;
        public int? ProprietarioId { get; set; }
        public Proprietarios? Proprietarios { get; set; }

    }
}
