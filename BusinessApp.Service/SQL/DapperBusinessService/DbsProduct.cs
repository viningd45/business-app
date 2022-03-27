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
        public int ArchiveProduct(int productId)
        {
                string sql = @" UPDATE dbo.Product
	                                SET Archived = 1
                                WHERE Id = @ProductId";

                using SqlConnection conn = new SqlConnection(_connectionString);
                return conn.Execute(sql, new { ProductId = productId });
        }

        public int CreateProduct(Product product)
        {
            throw new NotImplementedException();
        }
        public Product GetProduct(int productId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Product> GetProducts(Product filter, bool matchAny = false, bool matchExact = false)
        {
            throw new NotImplementedException();
        }

        public int UpdateCustomer(Customer customer)
        {
            throw new NotImplementedException();
        }

        public int UpdateProduct(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
