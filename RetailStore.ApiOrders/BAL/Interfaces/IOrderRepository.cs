using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RetailStore.ApiOrders.BAL.Interfaces
{
    public interface IOrderRepository
    {
        Task<(bool IsSuccess, IEnumerable<Models.OrderModel> Orders, string ErrorMessage)> GetOrdersAsync(int customerId);
    }
}
