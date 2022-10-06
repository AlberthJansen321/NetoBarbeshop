using NetoBarbershop.Domain.Models.Identity;
using System;

namespace NetoBarbershop.Domain.Models
{
    public class Token
    {
        public int Id { get; set; }
        public string RefreshToken { get; set; }
        public string UsuarioID { get; set; }
        public virtual ApplicationUSER Usuario { get; set; }
        public bool Ultilizado { get; set; }
        public DateTime Expiration { get; set; }
        public DateTime ExpirationRefreshToken { get; set; }
        public DateTime Criado { get; set; }
        public DateTime? Atualizado { get; set; }
    }
}
