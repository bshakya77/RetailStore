using RetailStore.ApiOrders.BAL.Models;
using RetailStore.ApiOrders.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RetailStore.ApiOrders.BAL.Profile
{
    public class OrderProfile: AutoMapper.Profile
    {
        public OrderProfile()
        {
            CreateMap<Order, OrderModel>();
            CreateMap<OrderItem, OrderItemModel>();
        }
    }
}
