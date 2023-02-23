using ProjectWedding.Domain.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectWedding.Domain.Entities
{
    public class ClientOrder : Auditable
    {
        public Restaurant Restaurant { get; set; }
        public DateTime Date { get; set; }
    }
}
