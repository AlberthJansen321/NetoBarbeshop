using NetoBarbershop.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace NetoBarbershop.Application.DTO
{
    public class UserRoleDTO
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public Funcao Funcao { get; set; }
    }
}
