using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Sopot_BusStation.Data
{
    public class BusSchedule
    {
        public int Id { get; set; }
        public string Road { get; set; }
        [Column (TypeName="decimal(10,2)")]
        public decimal Price { get; set; }
        public DateTime dateTime { get; set; }
    }
}
