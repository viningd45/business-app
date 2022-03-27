using BusinessApp.Service.Models;
using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessApp.Service.SQL.DapperBusinessService
{
    public partial class DapperBusinessService
    {
        public int CreateOrderItem(OrderItem item)
        {
            string sql = @" INSERT INTO dbo.OrderItem
                            (
                                OrderId,
                                ProductId,
                                ItemCount
                            )
                            VALUES
                            (   @OrderId, -- OrderId - int
                                @ProductId, -- ProductId - int
                                @ItemCount  -- ItemCount - int
                            )";

            using SqlConnection conn = new SqlConnection(_connectionString);
            return conn.Execute(sql, item);
        }

        public IEnumerable<OrderItem> GetOrderItems(int orderId)
        {
            string sql = @"  SELECT oi.OrderId,
                                   oi.ProductId,
                                   oi.ItemCount 
                            FROM dbo.OrderItem oi
                            WHERE oi.OrderId = @OrderId
                            ";

            using SqlConnection conn = new SqlConnection(_connectionString);
            return conn.Query<OrderItem>(sql, new { OrderId = orderId });
        }
    }
}
