using Prédio_Comercial.Repository;
using Prédio_Comercial.Service;
using System.ComponentModel.DataAnnotations;

namespace Prédio_Comercial.Models
{
    public class Usuarios
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MinLength(8)]
        [StringLength(100)]
        public string Login { get; set; } = "";
        [Required]
        [MinLength(5)]
        [MaxLength(100)]
        public string Password { get; set; } = "";
        public DateTime? DataContratacao { get; set; } = DateTime.Now;
        public bool? Admin { get; set; } = false;

        //public void SenhaHash(string senha)
        //{
        //    senha = Password.GerarHashSenha();
            
        //}
    }
}
