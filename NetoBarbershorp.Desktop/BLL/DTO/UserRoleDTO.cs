using NetoBarbershorp.Desktop.BLL.Enums;
using System.ComponentModel.DataAnnotations;

namespace NetoBarbershorp.Desktop.BLL.DTO
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
