namespace Prédio_Comercial.Models
{
    public class LogAuditoria
    {
        public string? Menssage { get; set; }
        public DateTime? CreatedAt { get; set; } = DateTime.Today;
        public string? NomeAtendente { get; set; }
        public int? UsuarioId { get; set; }
    }
}
