using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sopot_BusStation.Data
{
    public class User:IdentityUser
    {
        //public int Id { get; set; }
        public string FullName { get; set; }
        public Roles Role { get; set; }
        public ICollection <Order> Orders { get; set; }

    }
}
