using ProjectWedding.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectWedding.Service.Helpers
{
    public class ResponseRestaurant
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public bool isOk { get; set; }
        public Restaurant Restaurant { get; set; }
    }
}
