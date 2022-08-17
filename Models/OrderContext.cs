using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrdersOrganiser.Models
{
    public class OrderContext : DbContext
    {
        public OrderContext(DbContextOptions<OrderContext> options):base(options)
        {
        }

        public OrderContext()
        {
        }

        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Addresses> Addresses { get; set; }
        public DbSet<Account> Accounts { get; set; }
    }
}
