using NetoBarbershop.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NetoBarbershop.Application.DTO
{
    public class ServiceDoneDTO
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "{0} deve conter no minimo 2 caracteres e no maximo 50 caracteres")]
        public string ClienteNome { get; set; }
        [Required]
        public DateTime Data { get; set; }
        [Required]
        public bool Finalizado { get; set; }
        [Required]
        public bool Cancelado { get; set; }
        [Required]
        public string UsuarioID { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório"),
        Range(1, 200, ErrorMessage = "{0} não pode ser menor que 1 e nem maior que 200 R$")]
        public double ValorTotal { get; set; }
        public double Desconto { get; set; }
        public string Observacao { get; set; }
        public double Gojeta { get; set; }
        public IEnumerable<ServiceDoneServiceDTO> ServiceDoneServices { get; set; }
        public IEnumerable<ServiceDoneProductDTO> ServiceDoneProducts { get; set; }
    }
}
