using Microsoft.EntityFrameworkCore;
using RetailStore.ApiProducts.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RetailStore.ApiProducts.DAL
{
    public class ProductDbContext: DbContext
    {
        public DbSet<Product> Products { get; set; }

        public ProductDbContext(DbContextOptions options) : base(options)
        {

        }
    }
}
