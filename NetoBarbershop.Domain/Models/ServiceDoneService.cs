using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetoBarbershop.Domain.Models
{
    public class ServiceDoneService
    {
        public int Id { get; set; }
        public int ServiceDoneID { get; set; }
        public ServiceDone ServiceDone { get; set; }
        public int ServiceID { get; set; }
        public Service Service { get; set; }
    }
}
