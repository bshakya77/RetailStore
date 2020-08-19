using RetailStore.ApiSearch.BAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RetailStore.ApiSearch.BAL.Interfaces
{
    public interface IProductsService
    {
        Task<(bool IsSuccess, IEnumerable<ProductSearch> Products, string ErrorMessage)> GetProductsAsync();
    }
}
