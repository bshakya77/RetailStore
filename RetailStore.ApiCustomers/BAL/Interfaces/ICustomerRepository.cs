using RetailStore.ApiCustomers.BAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RetailStore.ApiCustomers.BAL.Interfaces
{
    public interface ICustomerRepository
    {
        Task<(bool IsSuccess, IEnumerable<CustomerModel> Customers, string ErrorMessage)> GetCustomersAsync();
        Task<(bool IsSuccess,  CustomerModel Customer, string ErrorMessage)> GetCustomerAsync(int id);
    }
}
