using Microsoft.EntityFrameworkCore;
using RetailStore.ApiOrders.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RetailStore.ApiOrders.DAL
{
    public class OrderDbContext: DbContext
    {
        public DbSet<Order> Orders { get; set; }

        public OrderDbContext(DbContextOptions options): base(options)
        {

        }
    }
}
