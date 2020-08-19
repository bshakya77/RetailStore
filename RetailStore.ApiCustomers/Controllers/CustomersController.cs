using Microsoft.AspNetCore.Mvc;
using RetailStore.ApiCustomers.BAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RetailStore.ApiCustomers.Controllers
{

    [ApiController]
    [Route("api/customers")]
    public class CustomersController: ControllerBase
    {
        private readonly ICustomerRepository customerRepository;

        public CustomersController(ICustomerRepository customerRepository)
        {
            this.customerRepository = customerRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetCustomersAysnc()
        {
            var result = await customerRepository.GetCustomersAsync();

            if (result.IsSuccess)
            {
                return Ok(result.Customers);
            }
            return NotFound();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCustomerAsync(int id)
        {
            var result = await customerRepository.GetCustomerAsync(id);
            if (result.IsSuccess)
            {
                return Ok(result.Customer);
            }
            return NotFound();
        }
    }
}
