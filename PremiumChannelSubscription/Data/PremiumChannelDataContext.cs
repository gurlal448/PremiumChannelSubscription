using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PremiumChannelSubscription.BusinessLayer;

namespace PremiumChannelSubscription.Data
{
    public class PremiumChannelDataContext:DbContext
    {
        public PremiumChannelDataContext(DbContextOptions<PremiumChannelDataContext> options):base(options)
        {

        }

        public DbSet<PremiumService> PremiumServices { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<CustomerSubscription> CustomerSubscriptions { get; set; }

        public DbSet<Location> Locations { get; set; }

    }
}
