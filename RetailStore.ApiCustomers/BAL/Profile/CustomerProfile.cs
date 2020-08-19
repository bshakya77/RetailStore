using RetailStore.ApiCustomers.BAL.Models;
using RetailStore.ApiCustomers.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RetailStore.ApiCustomers.BAL.Profile
{
    public class CustomerProfile: AutoMapper.Profile
    {
        public CustomerProfile()
        {
            CreateMap<Customer, CustomerModel>();
        }
    }
}
