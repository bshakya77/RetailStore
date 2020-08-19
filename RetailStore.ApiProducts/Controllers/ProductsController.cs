using Microsoft.AspNetCore.Mvc;
using RetailStore.ApiProducts.BAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RetailStore.ApiProducts.Controllers
{
    [ApiController]
    [Route("api/products")]
    public class ProductsController: ControllerBase
    {
        private readonly IProductRepository productRepository;

        public ProductsController(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }
        
        [HttpGet]
        public async Task<IActionResult> GetProductsAysnc()
        {
            var result = await productRepository.GetProductsAsync();

            if (result.IsSuccess)
            {
                return Ok(result.Products);
            }
            return NotFound();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductAsync(int id)
        {
            var result = await productRepository.GetProductAsync(id);
            if (result.IsSuccess)
            {
                return Ok(result.Product);
            }
            return NotFound();
        }
    }
}
