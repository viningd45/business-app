using BusinessApp.Service.Models;
using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessApp.Service.SQL.DapperBusinessService
{
    public partial class DapperBusinessService
    {
        public int CreateCustomerOrder(CustomerOrder order)
        {
            string sql = @" INSERT INTO dbo.CustomerOrder 
                            (
	                             CustomerId
	                            ,OrderDate
	                            ,PaymentReceived
                            ) VALUES
                            (
	                             @CustomerId
	                            ,@OrderDate
	                            ,@PaymentReceived
                            )";

            using SqlConnection conn = new SqlConnection(_connectionString);
            return conn.Execute(sql, order);
        }
        public CustomerOrder GetCustomerOrder(int orderId)
        {
            CustomerOrder order;
            string sql = @"  SELECT Id
                                  ,CustomerId
                                  ,OrderDate
                                  ,PaymentReceived
                              FROM dbo.CustomerOrder
                              WHERE Id = @OrderId
                            ";

            using SqlConnection conn = new SqlConnection(_connectionString);
            {
                order = conn.Query<CustomerOrder>(sql, new { OrderId = orderId }).FirstOrDefault();  
            }

            order.Items = this.GetOrderItems(orderId);
            return order;
        }
        public IEnumerable<CustomerOrder> GetCustomerOrders(int customerId, DateTime? orderDate = null)
        {
            string sql = @"  SELECT co.Id,
                                    co.CustomerId,
                                    co.OrderDate,
                                    co.PaymentReceived 
                            FROM dbo.CustomerOrder co
                            WHERE co.CustomerId = @CustomerId     
                            AND co.OrderDate > @OrderDate
                        ";

            var filter = new
            { 
                CustomerId = customerId, 
                OrderDate = orderDate ?? DateTime.MinValue 
            };

            using SqlConnection conn = new SqlConnection(_connectionString);
            return conn.Query<CustomerOrder>(sql, filter);
        }
    }
}
