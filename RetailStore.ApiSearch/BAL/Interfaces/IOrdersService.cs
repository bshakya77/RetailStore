using RetailStore.ApiSearch.BAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RetailStore.ApiSearch.BAL.Interfaces
{
    public interface IOrdersService
    {
        Task<(bool IsSuccess, IEnumerable<OrderSearch> Orders, string ErrorMessage)> GetOrdersAsync(int customerId);
    }
}
