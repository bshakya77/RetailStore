using Microsoft.EntityFrameworkCore;
using RetailStore.ApiCustomers.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RetailStore.ApiCustomers.DAL
{
    public class CustomerDbContext: DbContext
    {
        public DbSet<Customer> Customers { get; set; }

        public CustomerDbContext(DbContextOptions options) : base(options)
        {

        }
    }
}
