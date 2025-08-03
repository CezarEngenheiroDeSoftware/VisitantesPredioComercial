namespace Prédio_Comercial.Models.DTO
{
    public class AcessosGetDTO
    {
        public int id { get; set; }
        public string NomeUsuario { get; set; }
        public string NomeVisitante { get; set; }
        public string? EntrouComOQue { get; set; }
        public string SalaComercial { get; set; } = "";
    }
}
