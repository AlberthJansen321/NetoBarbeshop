using System;
using System.Collections.Generic;
using System.Security.Authentication.ExtendedProtection;

namespace NetoBarbershop.Domain.Models
{
    public class Service
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public double Valor { get; set; }
        public string Descricao { get; set; }
        public DateTime DtCadastro { get; set; }
        public string ImagemURL { get; set; }
        public bool Habilitado { get; set; }
    }
}