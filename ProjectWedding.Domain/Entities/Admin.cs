using ProjectWedding.Domain.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectWedding.Domain.Entities
{
    public class Admin : Auditable
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public DateTime dateOfBirth { get; set; }
    }
}
