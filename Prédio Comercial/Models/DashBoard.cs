using System.ComponentModel.DataAnnotations;

namespace Prédio_Comercial.Models
{
    public class DashBoard
    {
        [Key]
        public int Id { get; set; }
        public Proprietarios? Proprietarios { get; set; }
        public Visitantes? Visitantes { get; set; }
        public Usuarios? Usuarios { get; set; }
        public Ocorrencias? Ocorrencias {  get; set; }
        public Acessos? Acessos { get; set; }
        public DateTime? DataInclusao { get; set; }
    }
}
