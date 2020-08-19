using Microsoft.AspNetCore.Mvc;
using RetailStore.ApiOrders.BAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RetailStore.ApiOrders.Controllers
{
    [ApiController]
    [Route("api/orders")]
    public class OrdersController: ControllerBase
    {
        private readonly IOrderRepository orderRepository;

        public OrdersController(IOrderRepository orderRepository)
        {
            this.orderRepository = orderRepository;
        }

        [HttpGet("{customerId}")]
        public async Task<IActionResult> GetOrdersAsync(int customerId)
        {
            var result = await orderRepository.GetOrdersAsync(customerId);
            if (result.IsSuccess)
            {
                return Ok(result.Orders);
            }
            return NotFound();
        }
    }
}
