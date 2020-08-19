using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using RetailStore.ApiProducts.BAL.Interfaces;
using RetailStore.ApiProducts.BAL.Models;
using RetailStore.ApiProducts.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RetailStore.ApiProducts.BAL.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductDbContext productContext;
        private readonly ILogger<ProductRepository> logger;
        private readonly IMapper mapper;

        public ProductRepository(ProductDbContext dbContext, ILogger<ProductRepository> logger, IMapper mapper)
        {
            this.productContext = dbContext;
            this.logger = logger;
            this.mapper = mapper;

            SeedData();
        }

        private void SeedData()
        {
            if (!productContext.Products.Any())
            {
                productContext.Products.Add(new DAL.Entities.Product() 
                { Id = 1, Name = "Laptop", Price = 1500, Inventory = 5 });
                productContext.Products.Add(new DAL.Entities.Product()
                { Id = 2, Name = "Mouse", Price = 20, Inventory = 2 });
                productContext.Products.Add(new DAL.Entities.Product()
                { Id = 3, Name = "Keyboard", Price = 200, Inventory = 3 });
                productContext.Products.Add(new DAL.Entities.Product()
                { Id = 4, Name = "Monitor", Price = 800, Inventory = 4 });
                productContext.SaveChanges();
            }
        }

        public async Task<(bool IsSuccess, IEnumerable<Models.Product> Products, string ErrorMessage)> GetProductsAsync()
        {
            try
            {
                var products = await productContext.Products.ToListAsync();

                if (products != null && products.Any())
                {
                    var result = mapper.Map<IEnumerable<DAL.Entities.Product>, IEnumerable<Models.Product>>(products);
                    return (true, result, null);
                }
                return (false, null, "Not Found");
            
            }
            catch (Exception ex)
            {
                logger?.LogError(ex.ToString());
                return (false, null, ex.Message);
            }
        }

        public async Task<(bool IsSuccess, Product Product, string ErrorMessage)> GetProductAsync(int id)
        {
            try
            {
                var product = await productContext.Products.FirstOrDefaultAsync(prod => prod.Id == id);

                if (product != null)
                {
                    var result = mapper.Map<DAL.Entities.Product, Models.Product>(product);
                    return (true, result, null);
                }
                return (false, null, "Not Found");
                
            }
            catch (Exception ex)
            {
                logger?.LogError(ex.ToString());
                return (false, null, ex.Message);
            }
        }
    }
}
