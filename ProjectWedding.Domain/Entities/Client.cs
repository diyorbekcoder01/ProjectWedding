using ProjectWedding.Domain.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectWedding.Domain.Entities
{
    public class Client : Auditable
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string phone { get; set; }
        public DateTime dateOfBirth { get; set; }
        public List<ClientOrder> Orders { get; set; }
        public List<Guest> Guests { get; set; }
    }
}
