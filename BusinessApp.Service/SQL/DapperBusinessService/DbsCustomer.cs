using BusinessApp.Service.Extensions;
using BusinessApp.Service.Models;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessApp.Service.SQL.DapperBusinessService
{
    public partial class DapperBusinessService
    {
        public int ArchiveCustomer(int customerId)
        {
            string sql = @"  UPDATE dbo.Customer SET
                                Archived = 1
                            WHERE Id = @Id";

            using SqlConnection conn = new SqlConnection(_connectionString);
            return conn.Execute(sql, new { Id = customerId });
        }

        public int CreateCustomer(Customer customer)
        {
            string sql = @"  INSERT INTO dbo.Customer
                              (
	                               FirstName
                                  ,LastName
                                  ,City
                                  ,State
                                  ,Zip
                                  ,Street
                                  ,Suite
                              )
                              VALUES
                              (
	                               @FirstName
                                  ,@LastName
                                  ,@City
                                  ,@State
                                  ,@Zip
                                  ,@Street
                                  ,@Suite
                              )";

            using SqlConnection conn = new SqlConnection(_connectionString);
            return conn.Execute(sql, customer);
        }



        public Customer GetCustomer(int customerId)
        {
            string sql = @"  SELECT Id
	                              ,FirstName
                                  ,LastName
                                  ,City
                                  ,State
                                  ,Zip
                                  ,Street
                                  ,Suite
                              FROM dbo.Customer
                              WHERE Id = @Id
                            ";

            using SqlConnection conn = new SqlConnection(_connectionString);
            return conn.Query<Customer>(sql, new { Id = customerId }).FirstOrDefault();
        }

        public IEnumerable<Customer> GetCustomers(Customer filter, bool matchAny = false, bool matchExact = false)
        {
            string sql = @"  SELECT Id
	                              ,FirstName
                                  ,LastName
                                  ,City
                                  ,State
                                  ,Zip
                                  ,Street
                                  ,Suite
                              FROM dbo.Customer
                            ";

            List<string> conditions = new List<string>();

            string gate = matchAny ? " OR " : " AND ";

            if (filter.FirstName.HasValue())
                conditions.Add(" FirstName = @FirstName ");
            if (filter.LastName.HasValue())
                conditions.Add(" LastName = @LastName ");
            if (filter.City.HasValue())
                conditions.Add(" City = @City ");
            if (filter.State.HasValue())
                conditions.Add(" State = @State ");
            if (filter.Zip.HasValue)
                conditions.Add(" Zip = @Zip ");
            if (filter.Street.HasValue())
                conditions.Add(" Street = @Street ");
            if (filter.Suite.HasValue())
                conditions.Add(" Suite = @Suite ");
            if (filter.Archived.HasValue)
                conditions.Add(" Archived = @Archived ");

            if (conditions.Any())
                sql += string.Join(gate, conditions.ToArray());

            using SqlConnection conn = new SqlConnection(_connectionString);
            return conn.Query<Customer>(sql, filter);
        }
    }
}
