using ProjectWedding.Domain.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace ProjectWedding.Domain.Entities
{
    public class Guest : Auditable
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public DateTime dateOfBirth { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public List<Gift> Gifts { get; set; }
    }
}
