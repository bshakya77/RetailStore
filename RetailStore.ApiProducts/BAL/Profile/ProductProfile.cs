using RetailStore.ApiProducts.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RetailStore.ApiProducts.BAL.Profile
{
    public class ProductProfile: AutoMapper.Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, Models.Product>();
        }
    }
}
