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
        public int CreatePrice(Price price) 
        {
            string sql = @" INSERT INTO dbo.Price
                            (
                                ProductId,
                                StartDate,
                                Amount
                            )
                            VALUES
                            (   @ProductId, -- ProductId - int
                                @StartDate, -- StartDate - datetime
                                @Amount -- Amount - int
                            )
                            ";

            using SqlConnection conn = new SqlConnection(_connectionString);
            return conn.Execute(sql, price);
        }

        public int CreatePrice(int productId, int amount, DateTime? startDate = null)
        {
            if (startDate is null) startDate = DateTime.Now;

            Price price = new Price { ProductId = productId, Amount = amount, StartDate = (DateTime)startDate };
            return this.CreatePrice(price);
        }

        public Price GetPrice(int productId, DateTime? requestDate = null)
        {
            string sql = PRICE_QUERY + " WHERE @RequestDate BETWEEN p.StartDate AND p.EndDate";

            var filter = this.GetFilter(productId, requestDate);

            using SqlConnection conn = new SqlConnection(_connectionString);
            return conn.Query<Price>(sql, filter).FirstOrDefault();
        }
        public IEnumerable<Price> GetPriceHistory(int productId, DateTime from)
        {
            string sql = PRICE_QUERY + @" WHERE p.EndDate > @RequestDate";

            var filter = this.GetFilter(productId, from);

            using SqlConnection conn = new SqlConnection(_connectionString);
            return conn.Query<Price>(sql, filter);
        }

        private object GetFilter(int productId, DateTime? requestDate)
        {
            return new 
            {
                ProductId = productId,
                RequestDate = requestDate ?? DateTime.Now
            };
        }

        const string PRICE_QUERY = @"
                                    ;WITH Prices (ProductId, StartDate, EndDate, Amount) AS 
                                    (
                                    SELECT p.ProductId,
                                           p.StartDate,
	                                       ISNULL(LEAD(p.StartDate) OVER (ORDER BY p.StartDate), GETDATE()) EndDate,
                                           p.Amount
                                    FROM dbo.Price p
                                    WHERE p.ProductId = @ProductId
                                    )
                                    SELECT p.ProductId,
                                           p.StartDate,
                                           p.EndDate,
                                           p.Amount
                                    FROM Prices p 
                                    ";
    }
}
