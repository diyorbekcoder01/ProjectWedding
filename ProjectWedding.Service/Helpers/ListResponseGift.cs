using ProjectWedding.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectWedding.Service.Helpers
{
    public class ListResponseGift
    {
        // header 
        public int StatusCode { get; set; }
        public string Message { get; set; }

        // body 
        public List<Gift> Gifts { get; set; }
    }
}
