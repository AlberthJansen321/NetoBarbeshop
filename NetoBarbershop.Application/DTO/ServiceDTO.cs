using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NetoBarbershop.Application.DTO
{
    public class ServiceDTO
    {
        public int Id { get; set; }

        [MaxLength(50, ErrorMessage = "O campo {0} deve conter no maximo 30 caracteres"),
        MinLength(2, ErrorMessage = "O campo {0} deve conter no minímo 2 caracteres"),
        Required(ErrorMessage = "Campo {0} é Obrigatório")]
        public string Nome { get; set; }
        [Required]
        public double Valor { get; set; }
        public string Descricao { get; set; }
        public DateTime DtCadastro { get; set; }
        public string ImagemURL { get; set; }
        [Required]
        public bool Habilitado { get; set; }
    }
}
