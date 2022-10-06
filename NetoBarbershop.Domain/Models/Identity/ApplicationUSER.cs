using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace NetoBarbershop.Domain.Models.Identity
{
    public class ApplicationUSER : IdentityUser
    {
        public string FullName { get; set; }
        public string ImagemURL { get; set; }
        public IEnumerable<ServiceDone> ServicesDones { get; set; }
        public IEnumerable<Token> Tokens { get; set; }
    }
}
