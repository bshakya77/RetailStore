using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using RetailStore.ApiOrders.BAL.Interfaces;
using RetailStore.ApiOrders.BAL.Models;
using RetailStore.ApiOrders.DAL;
using RetailStore.ApiOrders.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RetailStore.ApiOrders.BAL.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly OrderDbContext orderContext;
        private readonly ILogger<OrderRepository> logger;
        private readonly IMapper mapper;

        public OrderRepository(OrderDbContext dbContext, ILogger<OrderRepository> logger, IMapper mapper)
        {
            this.orderContext = dbContext;
            this.logger = logger;
            this.mapper = mapper;

            SeedData();
        }

        private void SeedData()
        {

            if (!orderContext.Orders.Any())
            {
                orderContext.Orders.Add(new Order()
                { Id = 1, CustomerId = 1, OrderDate = DateTime.Now, Total = 1500,
                   Items = new List<OrderItem>() {
                        new OrderItem() { OrderId = 1, ProductId = 1, Quantity = 10, UnitPrice = 10 },
                        new OrderItem() { OrderId = 1, ProductId = 2, Quantity = 6, UnitPrice = 15 },
                        new OrderItem() { OrderId = 1, ProductId = 3, Quantity = 3, UnitPrice = 20 },
                        new OrderItem() { OrderId = 2, ProductId = 2, Quantity = 5, UnitPrice = 50 },
                        new OrderItem() { OrderId = 3, ProductId = 3, Quantity = 1, UnitPrice = 100 }
                   }
                });

                orderContext.Orders.Add(new Order()
                {
                    Id = 2,
                    CustomerId = 2,
                    OrderDate = DateTime.Now,
                    Total = 2500,
                    Items = new List<OrderItem>() {
                        new OrderItem() { OrderId = 1, ProductId = 1, Quantity = 7, UnitPrice = 10 },
                        new OrderItem() { OrderId = 1, ProductId = 2, Quantity = 6, UnitPrice = 15 },
                        new OrderItem() { OrderId = 2, ProductId = 3, Quantity = 3, UnitPrice = 20 },
                        new OrderItem() { OrderId = 2, ProductId = 2, Quantity = 5, UnitPrice = 50 },
                        new OrderItem() { OrderId = 3, ProductId = 3, Quantity = 1, UnitPrice = 70 }
                   }
                });

                orderContext.SaveChanges();
            }
        }

        public async Task<(bool IsSuccess, IEnumerable<OrderModel> Orders, string ErrorMessage)> GetOrdersAsync(int customerId)
        {
            try
            {
                logger?.LogInformation("Getting Orders Info");
                var orders = await orderContext.Orders.Where(o => o.CustomerId == customerId)
                    .Include(o => o.Items)
                    .ToListAsync();

                if (orders != null && orders.Any())
                {
                    logger?.LogInformation($"{orders.Count} order(s) for Customer Id: {customerId}.");
                    var result = mapper.Map<IEnumerable<DAL.Entities.Order>, IEnumerable<Models.OrderModel>>(orders);
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
