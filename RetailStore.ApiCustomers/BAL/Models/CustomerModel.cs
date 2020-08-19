using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RetailStore.ApiCustomers.BAL.Models
{
    public class CustomerModel
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerAddress { get; set; }
        public string CustomerContactNo { get; set; }
    }
}
