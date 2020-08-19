using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RetailStore.ApiSearch.BAL.Interfaces
{
    public interface ICustomersService
    {
        Task<(bool IsSuccess, dynamic Customer, string ErrorMessage)> GetCustomerAsync(int id);
    }
}
