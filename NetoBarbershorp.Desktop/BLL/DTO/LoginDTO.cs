using System.ComponentModel.DataAnnotations;

namespace NetoBarbershorp.Desktop.BLL.DTO
{
    public class LoginDTO
    {
        [Required(ErrorMessage = "E-mail é obrigatório")]
        [EmailAddress(ErrorMessage = "Email Inválido")]
        [Display(Name = "E-mail")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Senha é obrigatório")]
        public string Senha { get; set; }
    }
}
