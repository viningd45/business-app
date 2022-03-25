using BusinessApp.Service.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessApp.Service.SQL.DapperBusinessService
{
    public partial class DapperBusinessService
    {
        public int CreateOrderItem(OrderItem item) => 0;
        public IEnumerable<OrderItem> GetOrderItems(int orderId)
        {
            throw new NotImplementedException();
        }
    }
}
