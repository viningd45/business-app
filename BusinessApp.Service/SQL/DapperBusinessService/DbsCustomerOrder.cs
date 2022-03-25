using BusinessApp.Service.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessApp.Service.SQL.DapperBusinessService
{
    public partial class DapperBusinessService
    {
        public int CreateCustomerOrder(CustomerOrder order) => 0;
        public int GetCustomerOrder(int orderId) => 0;
        public IEnumerable<CustomerOrder> GetCustomerOrders(int customerId, DateTime? orderDate = null) => null;
    }
}
