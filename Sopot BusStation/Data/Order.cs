using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sopot_BusStation.Data
{
    public class Order
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public DateTime OrderOn { get; set; }
        public int UserTicketBuyId { get; set; }
        public UserTicketBuy userTicketBuy { get; set; }
    }
}
