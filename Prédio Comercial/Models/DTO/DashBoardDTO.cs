namespace Prédio_Comercial.Models.DTO
{
    public class DashBoardDTO
    {
        public List<string>? UsuariosLogin { get; set; }
        public int? TotalUsuarios { get; set; }
        public List<string>? ProprietariosName { get; set;}
        public int? TotalProprietarios { get; set; }
        public List<string>? VisitantesName { get; set; }
        public int? TotalVisitantes { get; set; }
        public int? TotalAcessos { get; set; }
        public int? TotalOcorrencias { get; set; }
        public DateTime DataInclusao { get; set; } = DateTime.Now;


    }
}
