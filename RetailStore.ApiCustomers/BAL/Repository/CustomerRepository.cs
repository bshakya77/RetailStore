using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using RetailStore.ApiCustomers.BAL.Interfaces;
using RetailStore.ApiCustomers.BAL.Models;
using RetailStore.ApiCustomers.DAL;
using RetailStore.ApiCustomers.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RetailStore.ApiCustomers.BAL.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly CustomerDbContext customerContext;
        private readonly ILogger<CustomerRepository> logger;
        private readonly IMapper mapper;

        public CustomerRepository(CustomerDbContext dbContext, ILogger<CustomerRepository> logger, IMapper mapper)
        {
            this.customerContext = dbContext;
            this.logger = logger;
            this.mapper = mapper;

            SeedData();
        }

        private void SeedData()
        {
            if (!customerContext.Customers.Any())
            {
                customerContext.Customers.Add(new DAL.Entities.Customer()
                { CustomerId = 1, CustomerName = "Bijay Shakya", CustomerAddress = "San Diego", CustomerContactNo = "5034420585" });
                customerContext.Customers.Add(new DAL.Entities.Customer()
                { CustomerId = 2, CustomerName = "Jimmy Anderson", CustomerAddress = "Reading", CustomerContactNo = "5694429605" });
               
                customerContext.SaveChanges();
            }
        }

        public async Task<(bool IsSuccess, CustomerModel Customer, string ErrorMessage)> GetCustomerAsync(int id)
        {
            try
            {
                logger?.LogInformation("Getting Customer Info");
                var customer = await customerContext.Customers.FirstOrDefaultAsync(cust => cust.CustomerId == id);
                if (customer != null)
                {
                    logger?.LogInformation($"Customer with Id: {customer.CustomerId} Found");
                    var result = mapper.Map<Customer, CustomerModel>(customer);
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

        public async Task<(bool IsSuccess, IEnumerable<CustomerModel> Customers, string ErrorMessage)> GetCustomersAsync()
        {
            try
            {
                logger?.LogInformation("Getting Customers Info");
                var customers = await customerContext.Customers.ToListAsync();
                if (customers != null && customers.Any())
                {
                    logger?.LogInformation($"{customers.Count} customer(s) found.");
                    var result = mapper.Map<IEnumerable<Customer>, IEnumerable<CustomerModel>>(customers);
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
