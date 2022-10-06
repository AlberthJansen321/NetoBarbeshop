using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetoBarbershop.Domain.Models
{
    public class ServiceDoneProduct
    {
        public int Id { get; set; }
        public int ServiceDoneID { get; set; }
        public ServiceDone ServiceDone { get; set; }
        public int ProdutoID { get; set; }
        public Produto Produto { get; set; }
        public int Quantidade { get; set; }
    }
}
