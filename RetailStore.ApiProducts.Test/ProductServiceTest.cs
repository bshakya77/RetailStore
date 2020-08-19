using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RetailStore.ApiProducts.BAL.Profile;
using RetailStore.ApiProducts.BAL.Repository;
using RetailStore.ApiProducts.DAL;
using RetailStore.ApiProducts.DAL.Entities;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace RetailStore.ApiProducts.Test
{
    public class ProductServiceTest
    {
        
        [Fact]
        public async Task Test_GetProductsReturnsAllProducts()
        {
            var options = new DbContextOptionsBuilder<ProductDbContext>()
                            .UseInMemoryDatabase(nameof(Test_GetProductsReturnsAllProducts)).Options;
            var dbContext = new ProductDbContext(options);
            GenerateProducts(dbContext);

            var productProfile = new ProductProfile();
            var configuration = new MapperConfiguration(c => c.AddProfile(productProfile));
            var mapper = new Mapper(configuration);

            var productRepository = new ProductRepository(dbContext, null, mapper);

            var products = await productRepository.GetProductsAsync();
            Assert.True(products.IsSuccess);
            Assert.True(products.Products.Any());
            Assert.Null(products.ErrorMessage);
        }

        [Fact]
        public async Task Test_GetProductReturnsProductUsingValidId()
        {
            var options = new DbContextOptionsBuilder<ProductDbContext>()
                            .UseInMemoryDatabase(nameof(Test_GetProductsReturnsAllProducts)).Options;
            var dbContext = new ProductDbContext(options);
            GenerateProducts(dbContext);

            var productProfile = new ProductProfile();
            var configuration = new MapperConfiguration(c => c.AddProfile(productProfile));
            var mapper = new Mapper(configuration);

            var productRepository = new ProductRepository(dbContext, null, mapper);

            var product = await productRepository.GetProductAsync(1);
            Assert.True(product.IsSuccess);
            Assert.NotNull(product.Product);
            Assert.True(product.Product.Id == 1);
            Assert.Null(product.ErrorMessage);
        }

        [Fact]
        public async Task Test_GetProductDoesNotReturnProductUsingInValidId()
        {
            var options = new DbContextOptionsBuilder<ProductDbContext>()
                            .UseInMemoryDatabase(nameof(Test_GetProductsReturnsAllProducts)).Options;
            var dbContext = new ProductDbContext(options);
            GenerateProducts(dbContext);

            var productProfile = new ProductProfile();
            var configuration = new MapperConfiguration(c => c.AddProfile(productProfile));
            var mapper = new Mapper(configuration);

            var productRepository = new ProductRepository(dbContext, null, mapper);

            var product = await productRepository.GetProductAsync(-1);
            Assert.False(product.IsSuccess);
            Assert.Null(product.Product);
            Assert.NotNull(product.ErrorMessage);
        }

        private void GenerateProducts(ProductDbContext dbContext)
        {
            for (int i = 1; i <= 10; i++)
            {
                dbContext.Products.Add(new Product()
                {
                    Id = i,
                    Name = Guid.NewGuid().ToString(),
                    Inventory = i + 10,
                    Price = (decimal)(i * 3.14)
                });
            }
            dbContext.SaveChanges();
        }
    }
}
