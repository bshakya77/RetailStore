using RetailStore.ApiProducts.BAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RetailStore.ApiProducts.BAL.Interfaces
{
    public interface IProductRepository
    {
        Task<(bool IsSuccess, IEnumerable<Models.Product> Products, string ErrorMessage)> GetProductsAsync();
        Task<(bool IsSuccess, Models.Product Product, string ErrorMessage)> GetProductAsync(int id);

    }
}
