using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NetoBarbershop.Application.DTO
{
    public class UsuarioDTO
    {
        public string? Id { get; set; }

        [MaxLength(50, ErrorMessage = "O campo {0} deve conter no maximo 30 caracteres"),
        MinLength(2, ErrorMessage = "O campo {0} deve conter no minímo 2 caracteres"),
        Required(ErrorMessage = "Campo {0} é Obrigatório")]
        [Display(Name = "Nome Completo")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Campo Email é Obrigatório")]
        [Display(Name = "E-mail")]
        [EmailAddress(ErrorMessage = "Email Inválido")]
        public string Email { get; set; }

        [StringLength(9, MinimumLength = 4, ErrorMessage = "Senha deve conter no máximo 8 caracteres e no minímo 4 caracteres")]
        [Required(ErrorMessage = "Campo Senha é Obrigatório")]
        public string Senha { get; set; }

        [Required(ErrorMessage = "Campo Confirmação de Senha é Obrigatório")]
        [Compare("Senha", ErrorMessage = "Senhas não são iguais")]
        [Display(Name = "Senha")]
        public string ConfimacaoSenha { get; set; }

        public string ImagemURL { get; set; }
    }
}
