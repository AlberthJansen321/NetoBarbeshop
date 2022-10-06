using NetoBarbershop.Domain.Models.Identity;
using System;
using System.Collections.Generic;

namespace NetoBarbershop.Domain.Models
{
    public class ServiceDone
    {
        public int Id { get; set; }
        public string ClienteNome { get; set; }
        public DateTime Data { get; set; }
        public bool Finalizado { get; set; }
        public bool Cancelado { get; set; }
        public string UsuarioID { get; set; }
        public virtual ApplicationUSER Usuario { get; set; }
        public double ValorTotal { get; set; }
        public double Desconto { get; set; }
        public string Observacao { get; set; }
        public double Gojeta { get; set; }
        public IEnumerable<ServiceDoneService> ServiceDoneServices { get; set; }
        public IEnumerable<ServiceDoneProduct> ServiceDoneProducts { get; set; }
    }
}
