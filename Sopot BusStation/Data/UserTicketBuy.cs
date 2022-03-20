using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sopot_BusStation.Data
{
    public class UserTicketBuy
    {
        public int Id { get; set; }
        public double Price { get; set; }
        public int Amount { get; set; }
        public string Type { get; set; }
        public string Discription { get; set; }
    }
}
