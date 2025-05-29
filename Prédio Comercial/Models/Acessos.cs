using System.ComponentModel.DataAnnotations;

namespace Prédio_Comercial.Models
{
    public class Acessos
    {
        [Key]
        public int id { get; set; }
        public int VisitanteId { get; set; }
        public Visitantes? Visitante { get; set; }

        public int UsuariosId { get; set; }
        public Usuarios? Usuarios { get; set;}

        public string SalaComercial { get; set; } = "";
        public int NumeroSalaComercial { get; set; }
        public string? EntrouComOQue { get; set; }
    }
}
