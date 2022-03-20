using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sopot_BusStation.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }
        public DbSet<Order> order { get; set; }
        public DbSet<BusSchedule> busSchedules { get; set; }
        public DbSet<UserTicketBuy> userTicketBuys { get; set; }
    }
}
