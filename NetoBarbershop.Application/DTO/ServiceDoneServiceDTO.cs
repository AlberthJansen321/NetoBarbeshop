using NetoBarbershop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetoBarbershop.Application.DTO
{
    public class ServiceDoneServiceDTO
    {
        public int Id { get; set; }
        public int ServiceDoneID { get; set; }
        public int ServiceID { get; set; }
    }
}

