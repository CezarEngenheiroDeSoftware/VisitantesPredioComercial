using System.ComponentModel.DataAnnotations.Schema;

namespace Prédio_Comercial.Models
{
    public class Proprietarios
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int Sala { get; set; }
        public string? Documento { get; set; }
        public int VisitantesId { get; set; }
        public List<Visitantes>? Visitantes { get; set; }
        [NotMapped]
        public List<int>? VisitantesSelecionados { get; set; } = new List<int>();

    }
}
